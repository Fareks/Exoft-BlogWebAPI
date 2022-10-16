using AutoMapper;
using Business_Logic.DTO.PostLikeDTOs;
using DataLayer.Models;
using DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.PostLikesServices
{
    public class PostLikeServices : IPostLikeService
    {
        readonly IPostLikeRepository _postLikeRepository;
        readonly IPostRepository _postRepository;
        readonly IMapper _mapper;

        public PostLikeServices(IPostLikeRepository postLikeRepository, IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postLikeRepository = postLikeRepository;
            _postRepository = postRepository;
        }
        public async Task DeleteById(Guid id)
        {
            await _postLikeRepository.DeleteById(id);
            await _postRepository.UpdateLikeSnapshot(id);
            await _postLikeRepository.Save();
        }

        public async Task<IEnumerable<PostLikeReadDTO>> GetAllAsync()
        {
            var postLikes = _mapper.Map<List<PostLikeReadDTO>>(await _postLikeRepository.GetAllAsync());
            return postLikes;
        }

        public async Task<PostLikeReadDTO> GetByIdAsync(Guid id)
        {
            var postLike = await _postLikeRepository.GetByIdAsync(id);
            var postLikeDTO = _mapper.Map<PostLikeReadDTO>(postLike);
            return postLikeDTO;
        }

        public async Task<List<PostLikeReadDTO>> GetByPostIdAsync(Guid postId)
        {
            var postLikes = await _postLikeRepository.GetByPostIdAsync(postId);
            var postLikesDTO = _mapper.Map<List<PostLikeReadDTO>>(postLikes);
            return postLikesDTO;
        }

        //public async Task Post(PostLikeCreateDTO newItem)
        //{
        //    var postLike = _mapper.Map<PostLike>(newItem);
        //    postLike.CreatedDate = DateTime.Now;
        //    await _postLikeRepository.Post(postLike);
        //    await _postRepository.UpdateLikeSnapshot(postLike.PostId);
        //    await _postLikeRepository.Save();
        //}

        public async Task<int> ToggleLike(PostLikeCreateDTO newItem)
        {

            var postLike = _mapper.Map<PostLike>(newItem);
            postLike.CreatedDate = DateTime.Now;
            await _postLikeRepository.ToggleLike(postLike);
            await _postLikeRepository.Save();
            var likeCount = await _postRepository.UpdateLikeSnapshot(postLike.PostId);
            return likeCount;

        }
    }
}

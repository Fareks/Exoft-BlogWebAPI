using AutoMapper;
using Business_Logic.DTO;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.PostLikesServices
{
    public class PostLikeServices : IPostLikeService
    {
        IRepository<PostLike> _postLikeRepository;
        IMapper _mapper;

        public PostLikeServices(IRepository<PostLike> postLikeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _postLikeRepository = postLikeRepository;
        }
        public async Task DeleteById(Guid id)
        {
            await _postLikeRepository.DeleteById(id);
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

        public async Task Post(PostLikeCreateDTO newItem)
        {
            newItem.CreatedDate = DateTime.UtcNow;
            var postLike = _mapper.Map<PostLike>(newItem);
            await _postLikeRepository.Post(postLike);
            await _postLikeRepository.Save();
        }
    }
}

using AutoMapper;
using Business_Logic.DTO.PostDTOs;
using Business_Logic.Services.UserServices;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business_Logic.Services.PostServices
{
    public class PostServices : IPostService
    {
        readonly IPostRepository _postRepository;
        readonly IMapper _mapper;
        readonly IAuthService _authService;
        public PostServices(IPostRepository repo, IMapper mapper, IAuthService authService, CancellationToken token = default)
        {
            _mapper = mapper;
            _postRepository = repo;
            _authService = authService;
        }
        public async Task DeleteById(Guid id,CancellationToken token = default)
        {
            await _postRepository.DeleteById(id);
            await _postRepository.Save();
        }

        public async Task<IEnumerable<PostDTO>> GetAll(CancellationToken token = default)
        {
            var posts = _mapper.Map<List<PostDTO>>(await _postRepository.GetAllAsync());
            return posts;
        }

        public async Task<PostDTO> GetById(Guid id,CancellationToken token = default)
        {
            var post = await _postRepository.GetByIdAsync(id);
            var postDTO = _mapper.Map<PostDTO>(post);
            return postDTO;
        }
        public async Task<IEnumerable<PostDTO>> GetAllPostsByUserId(Guid userId,CancellationToken token = default)
        {
            var posts = await _postRepository.GetAllByUserId(userId);
            return (_mapper.Map<List<PostDTO>>(posts));
        }

        //public async Task<IEnumerable<PostDTO>> GetAllLikedPostsByUserId(Guid userId)
        //{
        //    var posts = await _postRepository.GetAllLikedPostsByUserId(userId);
        //    return (_mapper.Map<List<PostDTO>>(posts));
        //}

        public async Task<PostReadDTO> Create(PostCreateDTO newItem,CancellationToken token = default)
        {
            var post = _mapper.Map<Post>(newItem);
            post.UserId = await _authService.GetMyId();
            post.CreatedDate = DateTime.Now;
            await _postRepository.Post(post);
            await _postRepository.Save();
            var postReadDTO = _mapper.Map<PostReadDTO>(post);
            return (postReadDTO);
        }

        public async Task<PostUpdateDTO> Update(PostUpdateDTO postUpdateDTO,CancellationToken token = default)
        {
            var post = await _postRepository.GetByIdAsync(postUpdateDTO.Id);
            var updatedPost = _mapper.Map(postUpdateDTO, post);
            await _postRepository.Update(updatedPost);
            await _postRepository.Save();

            return (postUpdateDTO);
        }
        public async Task ValidatePost(Guid postId, bool isValid,CancellationToken token = default)
        {
            var post =  await _postRepository.GetByIdAsync(postId);
            post.VerifyStatus = isValid;
            await  _postRepository.Save();
        }
        public async Task SetCategory(Guid postId, Guid categoryId,CancellationToken token = default)
        {
            var post = await _postRepository.GetByIdAsync(postId);
            post.CategoryId = categoryId;
            await _postRepository.Save();
        }

        public async Task<List<PostDTO>> GetAllUnverifiedPosts(CancellationToken token = default)
        {
            var posts = _mapper.Map<List<PostDTO>>(await _postRepository.GetAllUnverifiedPosts());
            return posts;
        }

        public async Task<List<PostDTO>> GetPostsByCategoryId(Guid categoryId,CancellationToken token = default)
        {
            var posts = _mapper.Map<List<PostDTO>>(await _postRepository.GetPostsByCategoryId(categoryId));
            return posts;
        }

        public async Task<List<PostDTO>> GetLastPosts(int skip, int take,CancellationToken token = default)
        {
            var posts = _mapper.Map<List<PostDTO>>(await _postRepository.GetLastPosts(skip, take));
            return posts;
        }

        public async Task<IEnumerable<PostDTO>> SearchByContent(string content,CancellationToken token = default)
        {
            var posts = _mapper.Map<List<PostDTO>>(await _postRepository.SearchByContent(content));
            return posts;
        }
    }
}

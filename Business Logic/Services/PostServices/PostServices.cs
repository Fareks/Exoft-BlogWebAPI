using AutoMapper;
using Business_Logic.DTO.PostDTOs;
using Business_Logic.Services.UserServices;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business_Logic.Services.PostServices
{
    public class PostServices : IPostService
    {
        IRepository<Post> _postRepository;
        IMapper _mapper;
        IAuthService _authService;
        public PostServices(IRepository<Post> repo, IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _postRepository = repo;
            _authService = authService;
        }
        public async Task DeleteById(Guid id)
        {
            await _postRepository.DeleteById(id);
            await _postRepository.Save();
        }

        public async Task<IEnumerable<PostDTO>> GetAll()
        {
            var posts = _mapper.Map<List<PostDTO>>(await _postRepository.GetAllAsync());
            return posts;
        }

        public async Task<PostDTO> GetById(Guid id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            var postDTO = _mapper.Map<PostDTO>(post);
            return postDTO;
        }
        public async Task<IEnumerable<PostDTO>> GetAllPostsByUserId(Guid userId)
        {
            var posts = await _postRepository.GetAllAsync();
            var postsByUserId = posts.Where(p => p.UserId == userId);
            return (_mapper.Map<List<PostDTO>>(postsByUserId));
        }
        public async Task<PostDTO> Create(PostCreateDTO newItem)
        {
            var post = _mapper.Map<Post>(newItem);
            post.UserId = await _authService.GetMyId();
            await _postRepository.Post(post);
            await _postRepository.Save();

            return (_mapper.Map<PostDTO>(post));
        }

        public async Task<PostDTO> Update(PostUpdateDTO postUpdateDTO)
        {
            var post = await _postRepository.GetByIdAsync(postUpdateDTO.Id);
            var updatedPost = _mapper.Map(postUpdateDTO, post);
            await _postRepository.Update(updatedPost);
            await _postRepository.Save();

            return (_mapper.Map<PostDTO>(post));
        }
        public async Task ValidatePost(Guid postId, bool isValid)
        {
            var post =  await _postRepository.GetByIdAsync(postId);
            post.VerifyStatus = isValid;
            await  _postRepository.Save();
        }
    }
}

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
        public PostServices(IPostRepository repo, IMapper mapper, IAuthService authService)
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
            var posts = await _postRepository.GetAllByUserId(userId);
            return (_mapper.Map<List<PostDTO>>(posts));
        }
        public async Task<PostCreateDTO> Create(PostCreateDTO newItem)
        {
            var post = _mapper.Map<Post>(newItem);
            post.UserId = await _authService.GetMyId();
            await _postRepository.Post(post);
            await _postRepository.Save();

            return (newItem);
        }

        public async Task<PostUpdateDTO> Update(PostUpdateDTO postUpdateDTO)
        {
            var post = await _postRepository.GetByIdAsync(postUpdateDTO.Id);
            var updatedPost = _mapper.Map(postUpdateDTO, post);
            await _postRepository.Update(updatedPost);
            await _postRepository.Save();

            return (postUpdateDTO);
        }
        public async Task ValidatePost(Guid postId, bool isValid)
        {
            var post =  await _postRepository.GetByIdAsync(postId);
            post.VerifyStatus = isValid;
            await  _postRepository.Save();
        }
    }
}

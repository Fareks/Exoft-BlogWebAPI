using AutoMapper;
using Business_Logic.DTO;
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
        public PostServices(IRepository<Post> repo, IMapper mapper)
        {
            _mapper = mapper;
            _postRepository = repo;
        }
        public async Task DeleteById(Guid id)
        {
            await _postRepository.Delete(id);
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

        public async Task Post(PostCreateDTO newItem)
        {
            var post = _mapper.Map<Post>(newItem);
            await _postRepository.Post(post);
        }

        public async Task Update(PostUpdateDTO item)
        {
            var post = _mapper.Map<Post>(item);
            await _postRepository.Update(post);
        }
    }
}

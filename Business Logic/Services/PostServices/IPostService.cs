using Business_Logic.DTO.PostDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.PostServices
{
    public interface IPostService
    {
        public Task<IEnumerable<PostDTO>> GetAll();
        public Task<PostDTO> GetById(Guid id);
        public Task<IEnumerable<PostDTO>> GetAllPostsByUserId(Guid userId);
        public Task<PostUpdateDTO> Update(PostUpdateDTO item);

        //Must accept id, call repository.Delete(repository.GetById)
        public Task DeleteById(Guid id);
        public Task<PostReadDTO> Create(PostCreateDTO newItem);
        public Task ValidatePost(Guid postId, bool isValid);
        public Task SetCategory(Guid postId, Guid categoryId);
        public Task<List<PostDTO>> GetAllUnverifiedPosts();
    }
}

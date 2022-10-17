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
        public Task<IEnumerable<PostDTO>> GetAll(CancellationToken token = default);
        public Task<PostDTO> GetById(Guid id, CancellationToken token = default);
        public Task<IEnumerable<PostDTO>> GetAllPostsByUserId(Guid userId,CancellationToken token = default);
        public Task<PostUpdateDTO> Update(PostUpdateDTO item,CancellationToken token = default);

        //Must accept id, call repository.Delete(repository.GetById)
        public Task DeleteById(Guid id,CancellationToken token = default);
        public Task<PostReadDTO> Create(PostCreateDTO newItem,CancellationToken token = default);
        public Task ValidatePost(Guid postId, bool isValid,CancellationToken token = default);
        public Task SetCategory(Guid postId, Guid categoryId,CancellationToken token = default);
        public Task<List<PostDTO>> GetAllUnverifiedPosts(CancellationToken token = default);
        public Task<List<PostDTO>> GetPostsByCategoryId(Guid categoryId,CancellationToken token = default);
        public Task<List<PostDTO>> GetLastPosts(int skip, int take,CancellationToken token = default);
        //public Task<IEnumerable<PostDTO>> GetAllLikedPostsByUserId(Guid userId);
        public Task<IEnumerable<PostDTO>> SearchByContent(string content, CancellationToken token = default);
    }
}

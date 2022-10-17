using Business_Logic.DTO.CommentLikeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.CommentLikeServices
{
    public interface ICommentLikeService
    {
        public Task<IEnumerable<CommentLikeReadDTO>> GetAllAsync();
        public Task<CommentLikeReadDTO> GetByIdAsync(Guid id);

        //Must accept id, call repository.Delete(repository.GetById)
        public Task DeleteById(Guid id);
        public Task CreateCommentLike(CommentLikeCreateDTO newItem);
    }
}

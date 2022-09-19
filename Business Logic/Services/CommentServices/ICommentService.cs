using Business_Logic.DTO.CommentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.CommentServices
{
    public interface ICommentService
    {
        public Task<IEnumerable<CommentReadDTO>> GetAllAsync();
        public Task<CommentReadDTO> GetByIdAsync(Guid id);
        public Task Update(CommentUpdateDTO item);

        //Must accept id, call repository.Delete(repository.GetById)
        public Task DeleteById(Guid id);
        public Task Post(CommentCreateDTO newItem);
    }
}

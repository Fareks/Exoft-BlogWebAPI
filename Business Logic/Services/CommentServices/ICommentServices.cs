using Business_Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.CommentServices
{
    public interface ICommentServices
    {
        public Task<IEnumerable<CommentReadDTO>> GetAll();
        public Task<CommentReadDTO> GetById(Guid id);
        public Task Update(CommentUpdateDTO item);
        public Task DeleteById(Guid id);
        public Task Post(CommentCreateDTO newItem);
    }
}

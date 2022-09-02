using Business_Logic.DTO;
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
        public Task Update(PostUpdateDTO item);
        public Task DeleteById(Guid id);
        public Task Create(PostCreateDTO newItem);
    }
}

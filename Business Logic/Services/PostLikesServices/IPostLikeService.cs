using Business_Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.PostLikesServices
{
    public interface IPostLikeService
    {
        public Task<IEnumerable<PostLikeReadDTO>> GetAllAsync();
        public Task<PostLikeReadDTO> GetByIdAsync(Guid id);
        public Task DeleteById(Guid id);
        public Task Post(PostLikeCreateDTO newItem);
    }
}

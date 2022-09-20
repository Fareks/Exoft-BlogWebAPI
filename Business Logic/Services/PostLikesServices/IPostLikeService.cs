using Business_Logic.DTO.PostLikeDTOs;
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

        //Must accept id, call repository.Delete(repository.GetById)
        public Task DeleteById(Guid id);
        public Task Post(PostLikeCreateDTO newItem);
    }
}

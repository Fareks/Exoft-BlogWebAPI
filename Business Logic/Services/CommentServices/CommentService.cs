using AutoMapper;
using Business_Logic.DTO;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.CommentServices
{
    public class CommentService : ICommentServices
    {
        IRepository<Comment> _comRepository;
        IMapper _mapper;

        public CommentService(IRepository<Comment> comRepository, IMapper mapper)
        {
            _comRepository = comRepository;
            _mapper = mapper;
        }
        public async Task DeleteById(Guid id)
        {
            var comment = await _comRepository.GetByIdAsync(id);
            if(comment != null)
            {
                await _comRepository.Delete(id);
            }
            
        }

        public async Task<IEnumerable<CommentReadDTO>> GetAll()
        {
            var comments = await _comRepository.GetAllAsync();
            var commentsDTO = _mapper.Map<List<CommentReadDTO>>(comments);
            return commentsDTO;
        }

        public Task<CommentReadDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Post(CommentCreateDTO newItem)
        {
            throw new NotImplementedException();
        }

        public Task Update(CommentUpdateDTO item)
        {
            throw new NotImplementedException();
        }
    }
}

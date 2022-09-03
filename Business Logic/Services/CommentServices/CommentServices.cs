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
    public class CommentServices : ICommentService
    {
        IRepository<Comment> _comRepository;
        IMapper _mapper;

        public CommentServices(IRepository<Comment> comRepository, IMapper mapper)
        {
            _comRepository = comRepository;
            _mapper = mapper;
        }
        public async Task DeleteById(Guid id)
        {
            await _comRepository.DeleteById(id);
            await _comRepository.Save();    
        }

        public async Task<IEnumerable<CommentReadDTO>> GetAllAsync()
        {
            var comments = await _comRepository.GetAllAsync();
            var commentsDTO = _mapper.Map<List<CommentReadDTO>>(comments);
            return commentsDTO;
        }

        public async Task<CommentReadDTO> GetById(Guid id)
        {
            var comment = await _comRepository.GetByIdAsync(id);
            var commentDTO = _mapper.Map<CommentReadDTO>(comment);
            return commentDTO;
        }

        public async Task Post(CommentCreateDTO newItem)
        {
            var comment = _mapper.Map<Comment>(newItem);
            await _comRepository.Post(comment);
            await _comRepository.Save();
        }

        public async Task Update(CommentUpdateDTO item)
        {
            item.UpdateDate = new DateTimeOffset(DateTime.UtcNow);
            await _comRepository.Update(_mapper.Map<Comment>(item));
        }
    }
}

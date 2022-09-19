using AutoMapper;
using Business_Logic.DTO.CommentDTOs;
using DataLayer.Models;
using DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.CommentServices
{
    public class CommentServices : ICommentService
    {
        IRepository<Comment> _commentRepository;
        IMapper _mapper;

        public CommentServices(IRepository<Comment> comRepository, IMapper mapper)
        {
            _commentRepository = comRepository;
            _mapper = mapper;
        }
        public async Task DeleteById(Guid id)
        {
            await _commentRepository.DeleteById(id);
            await _commentRepository.Save();    
        }

        public async Task<IEnumerable<CommentReadDTO>> GetAllAsync()
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentsDTO = _mapper.Map<List<CommentReadDTO>>(comments);
            return commentsDTO;
        }

        public async Task<CommentReadDTO> GetByIdAsync(Guid id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            var commentDTO = _mapper.Map<CommentReadDTO>(comment);
            return commentDTO;
        }

        public async Task Post(CommentCreateDTO newItem)
        {
            var comment = _mapper.Map<Comment>(newItem);
            await _commentRepository.Post(comment);
            await _commentRepository.Save();
        }

        public async Task Update(CommentUpdateDTO item)
        {
            await _commentRepository.Update(_mapper.Map<Comment>(item));
            await _commentRepository.Save();
        }
    }
}

using AutoMapper;
using Business_Logic.DTO.CommentLikeDTOs;
using DataLayer.Models;
using DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.CommentLikeServices
{
    public class CommentLikeServices : ICommentLikeService
    {
        IRepository<CommentLike> _commentLikeRepository;
        IMapper _mapper;

        public CommentLikeServices(IRepository<CommentLike> commLikeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _commentLikeRepository = commLikeRepository;
        }
        public async Task DeleteById(Guid id)
        {
            await _commentLikeRepository.DeleteById(id);
            await _commentLikeRepository.Save();
        }

        public async Task<IEnumerable<CommentLikeReadDTO>> GetAllAsync()
        {
            var commentLikes = _mapper.Map<List<CommentLikeReadDTO>>(await _commentLikeRepository.GetAllAsync());
            return commentLikes;
        }

        public async Task<CommentLikeReadDTO> GetByIdAsync(Guid id)
        {
            var commentLike = await _commentLikeRepository.GetByIdAsync(id);
            var commentLikesDTO = _mapper.Map<CommentLikeReadDTO>(commentLike);
            return commentLikesDTO;
        }

        public async Task Post(CommentLikeCreateDTO newItem)
        {
            newItem.CreatedDate = DateTime.UtcNow;
            var commentLike = _mapper.Map<CommentLike>(newItem);
            await _commentLikeRepository.Post(commentLike);
            await _commentLikeRepository.Save();
        }
    }
}

using AutoMapper;
using Business_Logic.DTO;
using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.CommentLikeServices
{
    public class CommentLikeServices : ICommentLikeService
    {
        IRepository<CommentLike> _commLikeRepository;
        IMapper _mapper;

        public CommentLikeServices(IRepository<CommentLike> commLikeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _commLikeRepository = commLikeRepository;
        }
        public async Task DeleteById(Guid id)
        {
            await _commLikeRepository.DeleteById(id);
            await _commLikeRepository.Save();
        }

        public async Task<IEnumerable<CommentLikeReadDTO>> GetAllAsync()
        {
            var commentLikes = _mapper.Map<List<CommentLikeReadDTO>>(await _commLikeRepository.GetAllAsync());
            return commentLikes;
        }

        public async Task<CommentLikeReadDTO> GetByIdAsync(Guid id)
        {
            var commentLike = await _commLikeRepository.GetByIdAsync(id);
            var commentLikesDTO = _mapper.Map<CommentLikeReadDTO>(commentLike);
            return commentLikesDTO;
        }

        public async Task Post(CommentLikeCreateDTO newItem)
        {
            newItem.CreatedDate = DateTime.UtcNow;
            var commentLike = _mapper.Map<CommentLike>(newItem);
            await _commLikeRepository.Post(commentLike);
            await _commLikeRepository.Save();
        }
    }
}

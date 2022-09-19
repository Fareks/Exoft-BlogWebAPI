using Business_Logic.DTO.BaseDTOs;
using Business_Logic.DTO.CommentDTOs;
using Business_Logic.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DTO.CommentLikeDTOs
{
    public class CommentLikeDTO : BaseDTO
    {
        public Guid UserId { get; set; }
        public UserDTO User { get; set; }
        public Guid CommentId { get; set; }
        public CommentDTO Comment { get; set; }
    }
}

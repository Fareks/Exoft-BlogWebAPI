using Business_Logic.DTO.BaseDTOs;
using Business_Logic.DTO.PostDTOs;
using Business_Logic.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DTO.CommentDTOs
{
    public class CommentDTO : BaseDTO
    {
        public string CommentContent { get; set; }
        public int LikeSnapshot { get; set; }
        public Guid UserId { get; set; }
        public UserDTO User { get; set; }
        public Guid PostId { get; set; }
        public PostDTO Post { get; set; }
    }
}

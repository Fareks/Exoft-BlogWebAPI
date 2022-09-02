
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DTO
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
    public class CommentReadDTO
    { 
        public Guid Id { get; set; }
        public string CommentContent { get; set; }
        public int LikeSnapshot { get; set; }
        public Guid UserId { get; set; }
        public UserReadDTO User { get; set; }
    }
    public class CommentUpdateDTO : BaseUpdateDTO
    {
        public string CommentContent { get; set; }
        public int LikeSnapshot { get; set; }
    }
    public class CommentCreateDTO : BaseCreateDTO
    {
        public string CommentContent { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DTO
{
    public class PostDTO : BaseDTO
    {
        public string TextContent { get; set; }
        public int LikeSnapshot { get; set; }
        public bool VerifyStatus { get; set; } = false;
        public DateTime Created { get; set; }
        public Guid UserId { get; set; }
        public UserDTO? User { get; set; }
        public ICollection<CommentDTO>? Comments { get; set; }
        public ICollection<PostLikeDTO>? PostLikes { get; set; }
    }
}

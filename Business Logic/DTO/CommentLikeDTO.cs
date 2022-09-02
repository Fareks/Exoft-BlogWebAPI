using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DTO
{
    public class CommentLikeDTO : BaseDTO
    {
        public UserDTO User { get; set; }
        public CommentDTO Comment { get; set; }
    }

    public class CommentLikeCreateDTO : BaseCreateDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CommentId { get; set; }
    }
}

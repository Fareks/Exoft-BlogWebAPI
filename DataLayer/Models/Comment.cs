using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Comment : BaseEntity
    {   
        public string CommentContent { get; set; }
        public int LikeSnapshot { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}

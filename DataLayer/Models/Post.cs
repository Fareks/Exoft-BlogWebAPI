using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string TextContent { get; set; }
        public int LikeSnapshot { get; set; }
        public bool VerifyStatus { get; set; } 
        public Guid UserId { get; set; }
        public User? User { get; set; }

        public ICollection<Comment>? Comments { get; set; }
        public ICollection<PostLike>? PostLikes { get; set; }

    }
}

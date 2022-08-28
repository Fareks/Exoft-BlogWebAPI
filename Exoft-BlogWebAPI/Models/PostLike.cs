using System.ComponentModel.DataAnnotations.Schema;

namespace Exoft_BlogWebAPI.Models
{
    public class PostLike:BaseEntity
    {
        [ForeignKey(nameof(Post))]
        public Guid PostId { get; set; }
        public Post Post { get; set; }


        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}

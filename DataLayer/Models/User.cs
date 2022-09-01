using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class User : BaseEntity
    {
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        [MaxLength(60)]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(20)]
        [MinLength(5)]
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<Post>? Post { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<PostLike>? postLikes { get; set; }
        public ICollection<CommentLike>? commentLikes { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
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
        public byte[] PasswordHash { get; set; }
        public byte [] PasswordSalt { get; set; }
        public string Role { get; set; } = "user";
        public ICollection<Post>? Post { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<PostLike>? postLikes { get; set; }
        public ICollection<CommentLike>? commentLikes { get; set; }
    }
}

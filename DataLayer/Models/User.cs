using Business_Logic.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataLayer.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //public byte[] PasswordHash { get; set; }
        //public byte [] PasswordSalt { get; set; }
        public Roles Role { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime? TokenCreated { get; set; }
        public DateTime? TokenExpires { get; set; }

        public bool IsBanned { get; set; }

        public ICollection<Post>? Post { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<PostLike>? PostLikes { get; set; }
        public ICollection<CommentLike>? CommentLikes { get; set; }
        public UserImage? UserImage { get; set; }
    }
}

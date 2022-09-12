using Business_Logic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business_Logic.DTO
{
    public class UserDTO : BaseDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return (FirstName +" "+ LastName); } set { } }
        public Roles Role { get; set; } = Roles.User;
        //public string Role { get; set; } = "User";

        public string Email { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime? TokenCreated { get; set; }
        public DateTime? TokenExpires { get; set; }

        public bool IsBanned { get; set; }

        public ICollection<PostDTO>? Post { get; set; }
        public ICollection<CommentDTO>? Comments { get; set; }
        public ICollection<PostLikeDTO>? postLikes { get; set; }
        public ICollection<CommentLikeDTO>? commentLikes { get; set; }
    }
    public class UserReadDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class  UserUpdateDTO : BaseUpdateDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
    public class UserCreateDTO : BaseCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [MaxLength(20)]
        [MinLength(5)]
        public string Password { get; set; }
    }

    public class UserLoginDTO
    {
        //public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

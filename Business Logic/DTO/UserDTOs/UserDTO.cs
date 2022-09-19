using Business_Logic.DTO.BaseDTOs;
using Business_Logic.DTO.CommentDTOs;
using Business_Logic.DTO.CommentLikeDTOs;
using Business_Logic.DTO.PostDTOs;
using Business_Logic.DTO.PostLikeDTOs;
using Business_Logic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business_Logic.DTO.UserDTOs
{
    public class UserDTO : BaseDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } set { } }
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
}

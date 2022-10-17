using Business_Logic.Enums;
using DataLayer.Models;
using System.Text.Json.Serialization;

namespace Business_Logic.DTO.UserDTOs
{
    public class UserReadDTO
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string Email { get; set; }
        public Guid Id { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime? TokenCreated { get; set; }
        public DateTime? TokenExpires { get; set; }
        public Roles Role { get; set; }
        public bool IsBanned { get; set; }
        public Guid? UserImageId { get; set; }
        [JsonIgnore]
        public UserImage? UserImage { get; set; }
    }
}

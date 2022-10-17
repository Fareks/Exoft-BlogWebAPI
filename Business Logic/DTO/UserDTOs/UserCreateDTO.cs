using Business_Logic.DTO.BaseDTOs;
using System.ComponentModel.DataAnnotations;

namespace Business_Logic.DTO.UserDTOs
{
    public class UserCreateDTO : BaseCreateDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [MaxLength(20)]
        [MinLength(5)]
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}

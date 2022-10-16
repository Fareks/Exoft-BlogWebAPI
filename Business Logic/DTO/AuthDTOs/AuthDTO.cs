using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DTO.AuthDTOs
{
    public class AuthDTO
    {
        public string? Token { get; set; }
        public Guid? UserId { get; set; }
        public string? RefreshToken { get; set; }
    }
}

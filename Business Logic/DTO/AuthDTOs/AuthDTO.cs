using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DTO.AuthDTOs
{
    public class AuthDTO
    {
        public string? token { get; set; }
        public Guid? userId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.DTO
{
    public class UserDTO : BaseDTO
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return (FirstName +" "+ LastName); } set { } }
        public string Role { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserCreateDTO : BaseDTO
    {

    }
}

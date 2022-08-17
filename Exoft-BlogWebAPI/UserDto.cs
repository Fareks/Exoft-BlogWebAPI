using Exoft_BlogWebAPI.Models;

namespace Exoft_BlogWebAPI
{
    public class UserDto
    {
        public string Name { get; set; }
        public Blog? Blog { get; set; }
    }
}

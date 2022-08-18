using Exoft_BlogWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Services
{
    public interface IUserServices
    {
        public IEnumerable<User> GetAll();
        public User GetById(int id);    
        public void Update(User user);
        public void DeleteById(int id);
        public void PostUser(User newUser);

    }
}

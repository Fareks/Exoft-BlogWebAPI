using Exoft_BlogWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Services
{
    public class UserServices : ICRUDService<User>
    {
        DBContext dbContext;
        public UserServices(DBContext _db)
        {
            dbContext = _db;
        }
        public void DeleteById(int id)
        {
            if (GetById(id) != null)
            {
                dbContext.Users.Remove(GetById(id));
                dbContext.SaveChanges();
            }
               
        }

        public IEnumerable<User> GetAll()
        {
            return dbContext.Users;
        }

        public User GetById(int id)
        {
            return (dbContext.Users.Find(id));
        }

        public void Post(User newItem)
        {
            dbContext.Users.Add(newItem);
            dbContext.SaveChanges();
        }

        public void Update(User Item)
        {
            dbContext.Update(Item);
            dbContext.SaveChanges();
        }
    }
}

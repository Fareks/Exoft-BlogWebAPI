using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business_Logic.Services
{
    public class UserServices : ICRUDService<User>
    {
        AppDbContext dbContext;
        public UserServices(AppDbContext _db)
        {
            dbContext = _db;
        }
        public async Task DeleteById(Guid id)
        {
            if (GetById(id) != null)
            {
                dbContext.Users.Remove(await GetById(id));
                await dbContext.SaveChangesAsync();
            }
               
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetById(Guid id)
        {
            var user  = await dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);
            return (user);
        }

        public async Task Post(User newItem)
        {
           dbContext.Users.AddAsync(newItem);
           await dbContext.SaveChangesAsync();
        }

        public async Task Update(User Item)
        {
            dbContext.Update(Item);
            await dbContext.SaveChangesAsync();
        }
    }
}

using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetByEmailAsync(string email, CancellationToken token = default);
        public Task<User> GetByEmailUsernameAsync(string email, string username,CancellationToken token = default);
    }
}

using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        public Task<List<Post>> GetAllByUserId(Guid userId);
    }
}

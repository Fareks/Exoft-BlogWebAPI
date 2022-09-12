using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IRepository<T>
    {
        public Task<T> GetByIdAsync(Guid id);
        public Task<ICollection<T>> GetAllAsync();
        public Task Post(T item);
        public Task Update(T item);

        //Must accept entities!
        public Task DeleteById(Guid id);
        public Task Save();
    }
}

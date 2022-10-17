using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> GetByIdAsync(Guid id, CancellationToken token = default);
        public Task<ICollection<T>> GetAllAsync(CancellationToken token = default);
        public Task Post(T item,CancellationToken token = default);
        public Task Update(T item,CancellationToken token = default);

        //Must accept entities!
        public Task DeleteById(Guid id,CancellationToken token = default);

        public Task Save(CancellationToken token = default);
    }
}

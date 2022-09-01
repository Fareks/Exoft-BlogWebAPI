using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Business_Logic.Services
{
    public interface IService<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(Guid id);    
        public Task Update(T item);
        public Task DeleteById(Guid id);
        public Task Post(T newItem);

    }
}

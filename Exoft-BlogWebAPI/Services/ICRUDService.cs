using Exoft_BlogWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exoft_BlogWebAPI.Services
{
    public interface ICRUDService<T>
    {
        public IEnumerable<T> GetAll();
        public T GetById(Guid id);    
        public void Update(T item);
        public void DeleteById(Guid id);
        public void Post(T newItem);

    }
}

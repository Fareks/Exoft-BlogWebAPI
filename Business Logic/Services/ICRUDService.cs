using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Business_Logic.Services
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

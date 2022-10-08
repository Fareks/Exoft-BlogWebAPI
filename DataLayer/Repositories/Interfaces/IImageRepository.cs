using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface IImageRepository<T>
    {
        public Task UploadImage(T image);
        public Task<T> GetImage(Guid UserId);
        public Task DeleteImage(T image);
    }
}

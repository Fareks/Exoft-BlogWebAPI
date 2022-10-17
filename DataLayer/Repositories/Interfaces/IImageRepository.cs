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
        public Task UploadImage(T image, CancellationToken token = default);
        public Task<T> GetImage(Guid imageId,CancellationToken token = default);
        public Task DeleteImage(T image,CancellationToken token = default);
        public Task<T> GetImageByOwnerId(Guid userId,CancellationToken token = default);
    }
}

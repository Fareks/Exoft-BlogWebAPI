using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface IUserImageRepository
    {
        public Task UploadImage(UserImage image);
        public Task<UserImage> GetImage(Guid UserId);
    }
}

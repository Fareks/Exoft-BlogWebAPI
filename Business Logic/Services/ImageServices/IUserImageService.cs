using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.ImageServices
{
    public interface IUserImageService
    {
        public Task<UserImage> UploadImage(IFormFile file, Guid userId);
        public Task<UserImage> GetImage(Guid userId);
    }
}

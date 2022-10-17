using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.ImageServices
{
    public interface ICategoryImageService
    {
        public Task<CategoryImage> UploadImage(IFormFile file, Guid categoryId, CancellationToken ctoken = default);
        public Task<CategoryImage> GetImage(Guid categoryId, CancellationToken ctoken = default);
        public Task DeleteImage(Guid categoryId, CancellationToken ctoken = default);
    }
}

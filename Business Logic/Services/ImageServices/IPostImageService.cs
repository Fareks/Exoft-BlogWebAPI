using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.ImageServices
{
    public interface IPostImageService
    {
        public Task<PostImage> UploadImage(IFormFile file, Guid postId, CancellationToken ctoken = default);
        public Task<PostImage> GetImage(Guid postId,CancellationToken ctoken = default);
        public Task DeleteImage(Guid postId,CancellationToken ctoken = default);
    }
}

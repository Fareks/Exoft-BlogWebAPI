using DataLayer.Models;
using DataLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Services.ImageServices
{
    public class UserImageService : IUserImageService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IImageRepository<UserImage> _imageRepository;

        public UserImageService(IWebHostEnvironment hostingEnvironment, IImageRepository<UserImage> imageRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _imageRepository = imageRepository;
        }

        

        public async Task<UserImage> GetImage(Guid imageId)
        {
            return await _imageRepository.GetImage(imageId);
        }

        public  async Task<UserImage> UploadImage(IFormFile file, Guid userId)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            var newFilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + Guid.NewGuid()+ fileInfo.Extension ;
            var path = Path.Combine("", _hostingEnvironment.WebRootPath + @"Images\" + newFilename);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            UserImage image = new UserImage();
            image.ImagePath = path;
            image.UploadDate = DateTime.Now;
            image.UserId = userId;

            var oldImage = await _imageRepository.GetImageByOwnerId(userId);
            if (oldImage != null)
            {
               await _imageRepository.DeleteImage(oldImage);
                File.Delete(oldImage.ImagePath);
            }
            await _imageRepository.UploadImage(image);
            return (image);
        }
        public async Task DeleteImage(Guid userId)
        {
            var image = await _imageRepository.GetImage(userId);
            await _imageRepository.DeleteImage(image);
            File.Delete(image.ImagePath);
        }
    }
}

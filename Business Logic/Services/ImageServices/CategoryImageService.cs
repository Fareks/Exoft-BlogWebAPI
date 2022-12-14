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
    public class CategoryImageService : ICategoryImageService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IImageRepository<CategoryImage> _imageRepository;

        public CategoryImageService(IWebHostEnvironment hostingEnvironment, IImageRepository<CategoryImage> imageRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _imageRepository = imageRepository;
        }

        public async Task<CategoryImage> GetImage(Guid imageId, CancellationToken ctoken = default)
        {
            return await _imageRepository.GetImage(imageId, ctoken);
        }

        public async Task<CategoryImage> UploadImage(IFormFile file, Guid categoryId, CancellationToken ctoken = default)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            var newFilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + Guid.NewGuid() + fileInfo.Extension;
            var path = Path.Combine("", _hostingEnvironment.WebRootPath + @"Images\" + newFilename);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            CategoryImage image = new CategoryImage();
            image.ImagePath = path;
            image.UploadDate = DateTime.Now;
            image.CategoryId = categoryId;

            var oldImage = await _imageRepository.GetImageByOwnerId(categoryId, ctoken);
            if (oldImage != null)
            {
                await _imageRepository.DeleteImage(oldImage, ctoken);
                File.Delete(oldImage.ImagePath);
            }
            await _imageRepository.UploadImage(image, ctoken);
            return (image);
        }

        public async Task DeleteImage(Guid postId, CancellationToken ctoken = default)
        {
            var image = await _imageRepository.GetImage(postId, ctoken);
            await _imageRepository.DeleteImage(image, ctoken);
            File.Delete(image.ImagePath);
        }
    }
}
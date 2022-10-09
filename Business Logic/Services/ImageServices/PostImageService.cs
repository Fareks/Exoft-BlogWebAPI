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
    public class PostImageService : IPostImageService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IImageRepository<PostImage> _postImageRepository;

        public PostImageService(IWebHostEnvironment hostingEnvironment, IImageRepository<PostImage> imageRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _postImageRepository = imageRepository;
        }

        public async Task<PostImage> GetImage(Guid imageId)
        {
            return await _postImageRepository.GetImage(imageId);
        }

        public async Task<PostImage> UploadImage(IFormFile file, Guid postId)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            var newFilename = "Image_" + DateTime.Now.TimeOfDay.Milliseconds + Guid.NewGuid() + fileInfo.Extension;
            var path = Path.Combine("", _hostingEnvironment.WebRootPath + @"Images\" + newFilename);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            PostImage image = new PostImage();
            image.ImagePath = path;
            image.UploadDate = DateTime.Now;
            image.PostId = postId;

            var oldImage = await _postImageRepository.GetImageByOwnerId(postId);
            if (oldImage != null)
            {
                await _postImageRepository.DeleteImage(oldImage);
                File.Delete(oldImage.ImagePath);
            }
            await _postImageRepository.UploadImage(image);
            return (image);
        }

        public async Task DeleteImage(Guid postId)
        {
            var image = await _postImageRepository.GetImage(postId);
            await _postImageRepository.DeleteImage(image);
            File.Delete(image.ImagePath);
        }
    }
}
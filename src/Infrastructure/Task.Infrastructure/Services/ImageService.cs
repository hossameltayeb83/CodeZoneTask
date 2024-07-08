using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Contracts.Infrastructure;

namespace Task.Infrastructure.Services
{
    public class ImageService : IImageService
    {
        private readonly string _path = @"wwwroot\";
        public void DeleteImage(string imagePath)
        {
            var fullPath = @$"{_path}{imagePath}";
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }

        public async System.Threading.Tasks.Task SaveImageAsync(IFormFile image, string imagePath)
        {
            
            var fullPath = @$"{_path}{imagePath}";
            using (FileStream stream = File.Create(fullPath))
            {
                await image.CopyToAsync(stream);
            }
        }

        public async System.Threading.Tasks.Task UpdateImageAsync(IFormFile image, string imagePath)
        {
            var fullPath = @$"{_path}{imagePath}";
            DeleteImage(imagePath);
            if (image != null)
            {
                using (FileStream stream = File.Create(fullPath))
                {
                    await image.CopyToAsync(stream);
                }
            }
        }
    }
}

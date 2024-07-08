using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Contracts.Infrastructure
{
    public interface IImageService
    {
        public System.Threading.Tasks.Task SaveImageAsync(IFormFile image,string imagePath);
        public System.Threading.Tasks.Task UpdateImageAsync(IFormFile image, string imagePath);
        public void DeleteImage(string imagePath);
    }
}

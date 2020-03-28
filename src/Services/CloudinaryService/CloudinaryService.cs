using Core.Services.Rest;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.IO;

namespace Services.CloudinaryService
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly IConfiguration _configuration;
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IConfiguration configuration)
        {
            _configuration = configuration;

            var account = new Account(
                _configuration["Cloudinary:CloudName"],
                _configuration["Cloudinary:ApiKey"],
                _configuration["Cloudinary:ApiSecret"]);

            _cloudinary = new Cloudinary(account);
        }
        public string BuildUrl(string publicId, string crop = "fill", int width = 150, int height = 150)
        {
            return _cloudinary.Api.Url.Secure(true)
                .Transform(new Transformation().Width(width).Height(height).Crop(crop))
                .BuildUrl(publicId);
        }

        public void Delete(string publicId)
        {
            _cloudinary.DeleteResources(publicId);
        }

        public string Store(string file)
        {
            string sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", file);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(sourcePath),
                UniqueFilename = true,
                Folder = "temp/"
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            return uploadResult.PublicId;
        }
    }
}

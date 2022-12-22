namespace ParqueProcesoDesarrollo.Web.Helpers
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public class ImageHelper : IImageHelper
    {
        public async Task<string> UploadImageAsync(IFormFile imageFile, string nameFile, string folder)
        {
            var guid = Guid.NewGuid().ToString();
            var file = $"{nameFile}{guid}.png";
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                $"wwwroot\\images\\{folder}", file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            return $"~/images/{folder}/{file}";
        }

        public string GetProfilePath(string imagePath)
        {
            var fileName = Path.GetFileName(imagePath);
            if (fileName == "_default.jpeg")
            {
                return $"/images/{fileName}";
            }
            else
            {
                return $"/images/users/{fileName}";
            }
        }

        public void DeleteImage(string imagePath)
        {
            var fileName = Path.GetFileName(imagePath);
            File.Delete($"wwwroot\\images\\users\\{fileName}");
        }
    }
}
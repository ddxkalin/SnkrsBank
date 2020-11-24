namespace SnkrsBank.Services.Utils
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;

    using System;
    using System.IO;
    using System.Threading.Tasks;

    public static class FileManager
    {
        public static async Task<string> SaveFile(IHostingEnvironment environment, IFormFile file)
        {
            var uploads = Path.Combine(environment.WebRootPath, "uploads");

            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, Guid.NewGuid().ToString(), file.FileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);


                    return filePath;
                }
            }

            return null;
        }

        public static string GetRelativeFilePath(string absolutePath)
        {
            return Path.Combine(Path.DirectorySeparatorChar.ToString(), "uploads", Path.GetFileName(Path.GetDirectoryName(absolutePath)), Path.GetFileName(absolutePath));
        }
    }
}

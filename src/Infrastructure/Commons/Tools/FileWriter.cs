using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Commons.Tools
{
    public abstract class FileWriter
    {
        protected async Task SerializeFileAsync(IFormFile file, string directory, string filePath)
        {
            CreateDirectoryIfNotExist(directory);

            try
            {
                using (FileStream stream = new(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }  
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateDirectoryIfNotExist(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }
    }
}

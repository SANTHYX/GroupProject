using Application.Commons.Tools;
using Infrastructure.Commons.Helpers;
using Infrastructure.Commons.Tools;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Tools
{
    public class VideoWriter : FileWriter, IVideoWriter
    {
        public async Task<string> SaveFileAsync(IFormFile file)
        {
            ValidateIsFileVideo(file);

            var fileName = $"{Guid.NewGuid().ToString("N")}{ Path.GetExtension(file.FileName) }";
            var directory = DirectoriesStore.MoviesDirectory;
            var pathFile = Path.Combine(directory,fileName);

            await SerializeFileAsync(file, directory, pathFile);

            return fileName;
        }

        private void ValidateIsFileVideo(IFormFile file)
        {
            if (Path.GetExtension(file.FileName) is not ".mp4")
            {
                throw new FormatException($"Cannot serialize file becouse given file is '{Path.GetExtension(file.FileName)}' when should be 'mp4'");
            }
        }
    }
}

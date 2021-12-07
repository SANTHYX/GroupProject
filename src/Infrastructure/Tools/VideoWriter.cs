﻿using Application.Commons.Tools;
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

            var fileName = Guid.NewGuid().ToString("N");
            var directory = Path.Combine(DirectoriesStore.MoviesDirectory,
                $"{ fileName }{ Path.GetExtension(file.FileName) }");

            await SerializeFileAsync(file, directory);

            return fileName;
        }

        private void ValidateIsFileVideo(IFormFile file)
        {
            if (Path.GetExtension(file.FileName) is not ".mp4")
            {
                throw new FormatException($"Cannot serialize file " +
                    $"becouse given file is '{Path.GetExtension(file.FileName)}' when should be 'mp4'");
            }
        }
    }
}
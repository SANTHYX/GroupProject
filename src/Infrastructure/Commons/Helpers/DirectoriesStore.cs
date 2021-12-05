using System;
using System.IO;

namespace Infrastructure.Commons.Helpers
{
    public static class DirectoriesStore
    {
        public static string MoviesDirectory => Path.Combine(FilesDirectory, "Movies");
        public static string FilesDirectory => Path.Combine(InfrastructureDirectory, "Files");
        private static string InfrastructureDirectory
            => Path.Combine(Directory.GetParent(Environment.CurrentDirectory).ToString(), "Infrastructure");
    }
}

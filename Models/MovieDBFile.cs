using System;
using System.IO;
using System.Text.Json;

namespace mscanner.Models
{
    public static class MovieDBFile
    {
        private static object _lock = new object();

        public const string FilePath = "movieDB.json";

        public static void Write(MovieDB movieDB)
        {
            lock (_lock)
            {
                var movieDBFileWrapper = new MovieDBFileWrapper
                {
                    MovieDB = movieDB
                };

                File.WriteAllText(FilePath, JsonSerializer.Serialize(movieDBFileWrapper));
            }
        }
    }

    internal class MovieDBFileWrapper
    {
        public MovieDB MovieDB { get; set; }
    }
}
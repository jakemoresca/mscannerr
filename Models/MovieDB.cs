using System.Collections.Generic;

namespace mscanner.Models
{
    public class MovieDB
    {
        public MovieDB() { }

        public List<ScannedMovie> Collection { get; set; }
    }

    public class ScannedMovie
    {
        public string Title { get; set; }
        public bool Exist { get; set; }
        public string[] Countries { get; set; }
    }
}
namespace mscannerr.Models
{
    public class Movie
    {
        public Movie(string title, string description, int year, string posterUrl, string status)
        {
            Title = title;
            Description = description;
            Year = year;
            PosterUrl = posterUrl;
            Status = status;
        }

        public string Title { get; }
        public string Description { get; }
        public int Year { get; }
        public string PosterUrl { get; }
        public string Status { get; }
    }
}
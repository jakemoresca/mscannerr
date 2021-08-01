namespace mscanner.Models
{
    public class IntegrationSettings
    {
        public MovieSettings MovieSettings { get; set; }
        public SeriesSettings SeriesSettings {get; set;}
    }

    public class MovieSettings 
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; }
        public string CountryFilter { get; set; }
    }

    public class SeriesSettings
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; }
        public string CountryFilter { get; set; }
    }
}
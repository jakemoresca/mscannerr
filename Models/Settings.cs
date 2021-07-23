namespace mscanner.Models
{
    public class Settings
    {
        public Settings() {}

        public Settings(string baseUrl, string apiKey, string host, int port, bool useSsl)
        {
            BaseUrl = baseUrl;
            ApiKey = apiKey;
            Host = host;
            Port = port;
            UseSsl = useSsl;
        }

        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; }
    }
}
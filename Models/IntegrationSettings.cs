namespace mscanner.Models
{
    public class IntegrationSettings
    {
        public IntegrationSettings() {}

        public IntegrationSettings(string baseUrl, string apiKey, string host, int port, bool useSsl, string countryFilter)
        {
            BaseUrl = baseUrl;
            ApiKey = apiKey;
            Host = host;
            Port = port;
            UseSsl = useSsl;
            CountryFilter = countryFilter;
        }

        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; }
        public string CountryFilter {get; set;}
    }
}
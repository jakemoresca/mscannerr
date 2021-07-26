namespace mscannerr.DTOs
{
    public class RegionDataDto
    {
        public RegionDto[] Items { get; set; }
    }

    public class RegionDto
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
namespace SuperApp_UI.Models
{
    public class PlatformDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public string? ImageUrl { get; set; }
    }
}

namespace SuperApp_UI.Models
{
    public class PlanDTO
    {
        public Guid PlansDomainId { get; set; }
        public string PlanName { get; set; }

        public string PlanDescription { get; set; }

        public double Cost { get; set; }

        public int Validity { get; set; }

        public string PlatformIds { get; set; }
        // Add this new property for displaying platform details
        public List<PlatformDTO>? Platforms { get; set; }
    }
}

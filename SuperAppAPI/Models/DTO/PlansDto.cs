namespace SuperAppAPI.Models.DTO
{
    public class PlansDto
    {
        public Guid PlansDomainId { get; set; }
        public string PlanName { get; set; }

        public string PlanDescription { get; set; }

        public double Cost { get; set; }

        public int Validity { get; set; }

        public string PlatformIds { get; set; }

    }
}

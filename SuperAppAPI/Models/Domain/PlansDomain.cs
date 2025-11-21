using System.ComponentModel.DataAnnotations;

namespace SuperAppAPI.Models.Domain
{
    public class PlansDomain
    {
        [Key]
        public Guid PlansDomainId { get; set; }
        public string PlanName { get; set; }

        public string PlanDescription { get; set; }

        public double Cost {  get; set; }

        public int Validity { get; set; }

        public string PlatformIds { get; set; }

    }
}

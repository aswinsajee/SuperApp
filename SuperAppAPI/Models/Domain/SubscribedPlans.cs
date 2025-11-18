namespace SuperAppAPI.Models.Domain
{
    public class SubscribedPlans
    {
        public Guid SubscribedPlansId { get; set; } //Primary key

        public Guid UserId { get; set; } //UserId from authDB [SuperAppAuthDb].[dbo].[AspNetUsers] table //Foreign Key

        public Guid PlansDomainId { get; set; } //Plan ID from Plans table;

        public double Cost { get; set; } //Amount get from the Plan table

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public string PlanName { get; set; }

        public DateTime EndDate { get; set; }

        public int Validity { get; set; }


        //navigational Properties

        public PlansDomain Plans { get; set; }


    }
}

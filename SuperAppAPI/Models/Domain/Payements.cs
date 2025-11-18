namespace SuperAppAPI.Models.Domain
{
    public class Payements
    {
        public int PayementsID { get; set; }

        public Guid PayementMethodsId { get;set; }  //Foreign Key from payementMethod table

        public Guid PlansDomainId { get; set; } //Foreign Key from Plans table

        public double Cost { get; set; } //Cost from the slected plan

        public DateTime PaymentDate { get; set; } //

        public string? Remarks { get; set; }

        public Guid UserId { get; set; }

        //Navigational Properties

        public PayementMethods payementMethods { get; set; }
        public PlansDomain plansDomain { get; set; }


    }
}

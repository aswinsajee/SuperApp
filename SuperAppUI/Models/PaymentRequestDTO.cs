namespace SuperApp_UI.Models
{
    public class PaymentRequestDTO
    {
        public Guid UserId { get; set; }

        public Guid PayementMethodsId { get; set; }
        public Guid PlansDomainId { get; set; }

        public string? Remarks { get; set; }
    }
}

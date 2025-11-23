namespace SuperAppUI.Models
{
    public class PayementRequestDTO
    {
        public Guid UserId { get; set; }

        public Guid PayementMethodsId { get; set; }
        public Guid PlansDomainId { get; set; }

        public string? Remarks { get; set; }
    }
}

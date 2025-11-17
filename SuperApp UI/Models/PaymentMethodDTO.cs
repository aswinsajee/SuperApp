namespace SuperApp_UI.Models
{
    public class PaymentMethodDTO
    {
        public Guid PayementMethodsId { get; set; }
        public string MethodName { get; set; }

        public string? MethodDescription { get; set; }
    }
}

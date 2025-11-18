namespace SuperAppAPI.Models.Domain
{
    public class PayementMethods
    {
        public Guid PayementMethodsId { get; set; }
        public string MethodName { get; set; }

        public string? MethodDescription { get; set; }
    }
}

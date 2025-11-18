namespace SuperAppAPI.Models.DTO
{
    public class PayementDto
    {
        public Guid PayementMethodsId { get; set; }
        public string MethodName { get; set; }

        public string? MethodDescription { get; set; }
    }
}

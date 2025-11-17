namespace SuperAppAPI.Models.DTO
{
    public class LoginResponseDTO
    {
        public string JwtToken { get; set; }
        public Guid UserId { get; set; }
    }
}

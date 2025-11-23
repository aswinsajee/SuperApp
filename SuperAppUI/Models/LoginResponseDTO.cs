using System.Text.Json.Serialization;

namespace SuperAppUI.Models
{
    public class LoginResponseDTO
    {
        
        public string? UserName { get; set; }

        [JsonPropertyName("jwtToken")]
        public string Token { get; set; }

        [JsonPropertyName("userId")]
        public Guid UserId { get; set; }
    }
}

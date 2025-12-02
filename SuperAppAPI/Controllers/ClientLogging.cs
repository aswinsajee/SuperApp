using Microsoft.AspNetCore.Mvc;

namespace SuperAppAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientLoggingController : ControllerBase
    {
        [HttpPost("LogClientError")]
        public IActionResult LogClientError([FromBody] string error)
        {
            var logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            Directory.CreateDirectory(logDirectory);

            var logFile = Path.Combine(logDirectory, "UIErrors.txt");

            var logText =
                $"--------------------------{Environment.NewLine}" +
                $"DATE: {DateTime.Now}{Environment.NewLine}" +
                $"ERROR: {error}{Environment.NewLine}" +
                $"--------------------------{Environment.NewLine}";

            System.IO.File.AppendAllText(logFile, logText);

            return Ok();
        }
    }
}

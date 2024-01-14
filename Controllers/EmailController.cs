using EmailApp.DTOs;
using EmailApp.Services.EmailService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        public IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult SendEmail([FromQuery] EmailBo emailRequest)
        {
            _emailService.SendEmail(emailRequest);

            return Ok();
        }
    }
}

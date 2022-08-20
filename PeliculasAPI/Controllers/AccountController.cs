using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.Services;

namespace PeliculasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        public readonly IEmailService _emailService;
        public AccountController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        [Route("register")]

        public void register(string email)
        {
            _emailService.SendEmail(email,"Welcome New User","Thanks for register dude!");
        }
    }
}

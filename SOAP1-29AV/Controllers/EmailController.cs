using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.IServices;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("api/email")]
    public class EmailController : Controller
    {
        private readonly IPersona _persona;
        private readonly IConfiguration _configuration;

        public EmailController(IPersona persona, IConfiguration configuration)
        {
            _persona = persona;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string correo = _configuration.GetSection("EmailConfig:email").Value;
            string contrasena = _configuration.GetSection("EmailConfig:secret").Value;
            return Ok(_persona.SendMail(correo, contrasena));
        }

        [HttpGet("message")]

        public IActionResult sendMessage()
        {

            return Ok(_persona.sendMessage());
        }




    }
}

using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : Controller
    {
        private readonly IPersona _persona;

        public EmailController (IPersona persona)
        {
            _persona = persona;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_persona.SendMail());
        }
    }
}

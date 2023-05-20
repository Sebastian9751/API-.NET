using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("personas")]
    public class PersonasController : Controller
    {
        private readonly IPersona _persona;

        public PersonasController(IPersona persona)
        {
            _persona = persona;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_persona.ObtenerLista());
        }

        [HttpGet("empleados")]

        public IActionResult getPesona()
        {

            return Ok(_persona.ObtenerEmpleado());
        }

    }
}

using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("persona")]
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

        [HttpGet("empleado")]

        public IActionResult getPesona()
        {

            return Ok(_persona.ObtenerEmpleado());
        }


       


    }
}

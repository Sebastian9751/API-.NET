using Domain;
using Domain.Entities;
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

        [HttpPost("create")]
        public IActionResult create([FromBody] PersonaVM empleado)        {
            return Ok(_persona.CrearPersonService(empleado));
        }

        [HttpPost("login")]
        public IActionResult login([FromBody] LoginVM loginData)
        {
            bool authenticated = _persona.IsAuthenticated(loginData);
            return Ok(authenticated ? "Usuario valido" : "usuario no valido");
        }

    }
}

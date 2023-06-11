using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using System.Net;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("api/persona")]
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

        [HttpGet("items")]

        public IActionResult getPesona()
        {

            return Ok(_persona.ObtenerEmpleado());
        }
        [HttpGet("itemsById")]

        public IActionResult getPesonaById(int id)
        {

            return Ok(_persona.ObtenerEmpleadosById(id));
        }



        [HttpPost("create")]
        public IActionResult PostEmpleados(Persona empleado)
        {
            if (empleado == null)
            {
                return BadRequest("El objeto Empleado es nulo");
            }

           
            _persona.GuardarEmpleados(empleado);

         return StatusCode((int)HttpStatusCode.Created, "Empleado creado exitosamente");
        }

        [HttpPost("login")]

        public IActionResult userLogin([FromBody] LoginVM loginData)
        {
            string res = _persona.login(loginData.email, loginData.password);
            return Ok(res);
        }

        [HttpGet("itemsFechaProxima")]
        public IActionResult getPesonaItem()
        {

            return Ok(_persona.ObtenerEmpleado());
        }

    }
}

using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using System.Net;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("Empleados")]
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

        [HttpGet("empleadosItems")]

        public IActionResult getPesona()
        {

            return Ok(_persona.ObtenerEmpleado());
        }
        [HttpGet("EmpladoItemsFechaProxima")]
        public IActionResult getPesonaItem()
        {

            return Ok(_persona.ObtenerEmpleadoItem());
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
    }
}

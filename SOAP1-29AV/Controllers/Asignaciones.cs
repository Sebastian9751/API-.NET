using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("api/asignacion")]
    public class Asignaciones : Controller
    {

        private readonly IPersona _persona;

        public Asignaciones(IPersona persona)
        {
            _persona = persona;
        }

        [HttpDelete("delete")]
        public IActionResult Index(int id)
        {
            return Ok(_persona.DeleteAsignaciones(id));
        }

        [HttpDelete("deleteAll")]
        public IActionResult DeleteByEmpleado(int id)
        {
            return Ok(_persona.DeleteAsignacionesByEmpleado(id));
        }


    }
}

using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using System.Net;

namespace SOAP1_29AV.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController : Controller
    {
        private readonly IPersona _persona;
        public ItemsController(IPersona persona)
        {
            _persona = persona;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_persona.ObtenerItemsDisponibles());
        }


        [HttpPost("create")]
        public IActionResult PostEmpleados(Items item)
        {
            if (item == null)
            {
                return BadRequest("El objeto Item es nulo");
            }


            _persona.GuardarItem (item);

            return StatusCode((int)HttpStatusCode.Created, "Item creado exitosamente");
        }

        [HttpPost("asignar")]
        public IActionResult AsignarItem(ItemsVM item)
        {
            if (item == null)
            {
                return BadRequest("El objeto Item es nulo");
            }


            _persona.AsignarItem(item);

            return StatusCode((int)HttpStatusCode.Created, "Item creado exitosamente");
        }

        [HttpPut("StatusItem")]
        public IActionResult SetStatusItem(bool status, int id_item)
        {
            if (status == null || id_item== null)
            {
                return BadRequest("El campo es nulo");
            }


            _persona.SetStatusItem(status,id_item) ;

            return StatusCode((int)HttpStatusCode.Created, "Item actualizado exitosamente");
        }



    }
}

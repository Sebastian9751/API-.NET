using Microsoft.AspNetCore.Mvc;
using Service.IServices;

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
    }
}

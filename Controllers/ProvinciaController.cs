using BackEnd_Trabajadores.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Trabajadores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly ProvinciaService _service;

        public ProvinciaController(ProvinciaService service)
        {
            _service = service;
        }

        [HttpGet("listar")]
        public IActionResult GetAllDepartamento()
        {
            var lista = _service.getAll();
            return lista != null ? Ok(lista) : NotFound();
        }
    }
}

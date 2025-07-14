using BackEnd_Trabajadores.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Trabajadores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistritoController : ControllerBase
    {
        private readonly DistritoService _service;

        public DistritoController(DistritoService service)
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

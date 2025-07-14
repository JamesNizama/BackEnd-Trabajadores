using BackEnd_Trabajadores.DTO;
using BackEnd_Trabajadores.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Trabajadores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadorController : ControllerBase
    {
        private readonly TrabajadorService _service;

        public TrabajadorController(TrabajadorService service)
        {
            _service = service;
        }

        [HttpGet("listar")]
        public IActionResult GetAllDepartamento()
        {
            var lista = _service.getAll();
            return lista != null ? Ok(lista) : NotFound();
        }

        [HttpPost("crear")]
        public IActionResult Crear([FromBody] TrabajadorDTO dto)
        {
            var result = _service.CrearTrabajador(dto);
            return Ok(result);
        }

        [HttpPut("actualizar")]
        public IActionResult Actualizar([FromBody] TrabajadorDTO dto)
        {
            var result = _service.ActualizarTrabajador(dto);
            return Ok(result);
        }

        [HttpDelete("eliminar/{id}")]
        public IActionResult Eliminar(int id)
        {
            var result = _service.EliminarTrabajador(id);
            return Ok(result);
        }
    }
}

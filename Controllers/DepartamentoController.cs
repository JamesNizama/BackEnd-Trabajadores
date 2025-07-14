using AutoMapper;
using BackEnd_Trabajadores.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Trabajadores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {

        private readonly DepartamentoService _service;

        public DepartamentoController(DepartamentoService service)
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

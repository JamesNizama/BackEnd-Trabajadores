using AutoMapper;
using BackEnd_Trabajadores.DTO;
using Microsoft.Extensions.Configuration;

namespace BackEnd_Trabajadores.Service
{
    public class DepartamentoService
    {
        private readonly string _cnBD;
        private readonly IMapper _mapper;

        public DepartamentoService(IConfiguration configuration, IMapper mapper)
        {
            _cnBD = configuration.GetConnectionString("Conexion");
            _mapper = mapper;
        }

        public List<DepartamentoDTO> getAll()
        {
            var data = new Data.DepartamentoDA(_cnBD).listarUsp();
            return _mapper.Map<List<DepartamentoDTO>>(data);
        }
    }
}

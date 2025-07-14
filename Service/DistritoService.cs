using AutoMapper;
using BackEnd_Trabajadores.DTO;

namespace BackEnd_Trabajadores.Service
{
    public class DistritoService
    {
        private readonly string _cnBD;
        private readonly IMapper _mapper;

        public DistritoService(IConfiguration configuration, IMapper mapper)
        {
            _cnBD = configuration.GetConnectionString("Conexion");
            _mapper = mapper;
        }

        public List<DistritoDTO> getAll()
        {
            var data = new Data.DistritoDA(_cnBD).listarUsp();
            return _mapper.Map<List<DistritoDTO>>(data);
        }
    }
}

using AutoMapper;
using BackEnd_Trabajadores.DTO;

namespace BackEnd_Trabajadores.Service
{
    public class ProvinciaService
    {
        private readonly string _cnBD;
        private readonly IMapper _mapper;

        public ProvinciaService(IConfiguration configuration, IMapper mapper)
        {
            _cnBD = configuration.GetConnectionString("Conexion");
            _mapper = mapper;
        }

        public List<ProvinciaDTO> getAll()
        {
            var data = new Data.ProvinciaDA(_cnBD).listarUsp();
            return _mapper.Map<List<ProvinciaDTO>>(data);
        }
    }
}

using AutoMapper;
using BackEnd_Trabajadores.DTO;

namespace BackEnd_Trabajadores.Service
{
    public class TrabajadorService
    {
        private readonly string _cnBD;
        private readonly IMapper _mapper;

        public TrabajadorService(IConfiguration configuration, IMapper mapper)
        {
            _cnBD = configuration.GetConnectionString("Conexion");
            _mapper = mapper;
        }

        public List<TrabajadorDTO> getAll()
        {
            var data = new Data.TrabajadorDA(_cnBD).listarUsp();
            return _mapper.Map<List<TrabajadorDTO>>(data);
        }
    }
}

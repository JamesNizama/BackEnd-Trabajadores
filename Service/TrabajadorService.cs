using AutoMapper;
using BackEnd_Trabajadores.DTO;
using static Dapper.SqlMapper;


namespace BackEnd_Trabajadores.Service
{
    public class TrabajadorService
    {
        private readonly Data.TrabajadorDA _objData;
        private readonly string _cnBD;
        private readonly IMapper _mapper;

        public TrabajadorService(IConfiguration configuration, IMapper mapper)
        {
            _cnBD = configuration.GetConnectionString("Conexion");
            _mapper = mapper;
            _objData = new Data.TrabajadorDA(_cnBD);
        }

        public List<TrabajadorDTO> getAll()
        {
            var data = new Data.TrabajadorDA(_cnBD).listarTrabajador();
            return _mapper.Map<List<TrabajadorDTO>>(data);
        }

        public DTO.Result<bool> CrearTrabajador(DTO.TrabajadorDTO dto)
        {
            var result = new DTO.Result<bool>();

            var trabajadorEntity = _mapper.Map<Models.Entities.Trabajador>(dto);

            _objData.CrearTrabajador(trabajadorEntity);

            result.value = true;
            result.errorCodigo = "OK";
            result.errorMensaje = "Trabajador creado correctamente.";
            return result;
        }



        public DTO.Result<bool> ActualizarTrabajador(DTO.TrabajadorDTO dto)
        {
            var result = new DTO.Result<bool>();

            var trabajadorEntity = _mapper.Map<Models.Entities.Trabajador>(dto);

            _objData.ActualizarTrabajador(trabajadorEntity);

            result.value = true;
            result.errorCodigo = "OK";
            result.errorMensaje = "Trabajador actualizado correctamente.";
            return result;
        }

        public DTO.Result<bool> EliminarTrabajador(int id)
        {
            var result = new DTO.Result<bool>();

            _objData.EliminarTrabajador(id);

            result.value = true;
            result.errorCodigo = "OK";
            result.errorMensaje = "Trabajador eliminado correctamente.";
            return result;
        }


    }
}

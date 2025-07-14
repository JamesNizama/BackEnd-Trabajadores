using AutoMapper;
using BackEnd_Trabajadores.DTO;

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

        public DTO.Result<string> EliminarTrabajador(DTO.TrabajadorDTO dto)
        {
            var result = new DTO.Result<string>();

            try
            {
                if (dto == null || dto.Id <= 0)
                {
                    result.value = null;
                    result.errorCodigo = "INVALID_INPUT";
                    result.errorMensaje = "ID de trabajador inválido.";
                    return result;
                }

                var entity = _mapper.Map<Models.Entities.Trabajador>(dto);
                string mensaje = _objData.EliminarTrabajador(entity);

                result.value = mensaje;
                result.errorCodigo = "OK";
                result.errorMensaje = "Se eliminó correctamente.";
            }
            catch (Exception ex)
            {
                result.value = null;
                result.errorCodigo = "ERROR";
                result.errorMensaje = ex.Message;
            }

            return result;
        }

    }
}

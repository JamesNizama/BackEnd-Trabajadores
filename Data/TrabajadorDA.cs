using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using static Dapper.SqlMapper;
using BackEnd_Trabajadores.Models.Entities;

namespace BackEnd_Trabajadores.Data
{
    public class TrabajadorDA
    {
        private readonly string cnBD = "";
        private string sqlQuery = "";
        private readonly string bdEsquema = "dbo.";


        public TrabajadorDA(string cnBD)
        {
            this.cnBD = cnBD;
        }


        public List<Models.Entities.Trabajador> listarTrabajador()
        {
            sqlQuery = bdEsquema + "SP_LISTAR_TRABAJADORES";

            using (SqlConnection sqlCn = new SqlConnection(this.cnBD))
            {
                var lista = sqlCn.Query<Models.Entities.Trabajador>(sqlQuery, commandType: CommandType.StoredProcedure).ToList();
                return lista;
            }
        }

        public void CrearTrabajador(Models.Entities.Trabajador trabajador)
        {
            string sqlInsert = bdEsquema + "SP_CREAR_TRABAJADOR";

            using (SqlConnection sqlCn = new SqlConnection(this.cnBD))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@TipoDocumento", trabajador.TipoDocumento, DbType.String);
                parametros.Add("@NumeroDocumento", trabajador.NumeroDocumento, DbType.String);
                parametros.Add("@Nombres", trabajador.Nombres, DbType.String);
                parametros.Add("@Sexo", trabajador.Sexo, DbType.String);
                parametros.Add("@IdDepartamento", trabajador.IdDepartamento, DbType.Int32);
                parametros.Add("@IdProvincia", trabajador.IdProvincia, DbType.Int32);
                parametros.Add("@IdDistrito", trabajador.IdDistrito, DbType.Int32);
                sqlCn.Execute(sqlInsert, parametros, commandType: CommandType.StoredProcedure);

            }
        }

        public string ActualizarTrabajador(Models.Entities.Trabajador trabajador)
        {
            string sqlModificar = bdEsquema + "SP_ACTUALIZAR_TRABAJADOR";
            using (SqlConnection sqlCn = new SqlConnection(this.cnBD))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", trabajador.Id, DbType.Int32);
                parametros.Add("@TipoDocumento", trabajador.TipoDocumento, DbType.String);
                parametros.Add("@NumeroDocumento", trabajador.NumeroDocumento, DbType.String);
                parametros.Add("@Nombres", trabajador.Nombres, DbType.String);
                parametros.Add("@Sexo", trabajador.Sexo, DbType.String);
                parametros.Add("@IdDepartamento", trabajador.IdDepartamento, DbType.Int32);
                parametros.Add("@IdProvincia", trabajador.IdProvincia, DbType.Int32);
                parametros.Add("@IdDistrito", trabajador.IdDistrito, DbType.Int32);

                sqlCn.Execute(sqlModificar, parametros, commandType: CommandType.StoredProcedure);

                return "Trabajador actualizado correctamente";
            }
        }

        public string EliminarTrabajador(int id)
        {
            string sqlEliminar = bdEsquema + "SP_ELIMINAR_TRABAJADOR";
            using (SqlConnection sqlCn = new SqlConnection(this.cnBD))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", id, DbType.Int32);

                int filasAfectadas = sqlCn.Execute(sqlEliminar, parametros, commandType: CommandType.StoredProcedure);

                if (filasAfectadas > 0)
                {
                    return "Trabajador eliminado correctamente";
                }
                else
                {
                    return "No se encontró el trabajador con el id proporcionado.";
                }
            }
        }
    }
}

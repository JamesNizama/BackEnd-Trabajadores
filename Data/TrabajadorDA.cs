using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace BackEnd_Trabajadores.Data
{
    public class TrabajadorDA
    {
        private readonly string cnBD = "";
        private string sqlQuery = "";
        private readonly string bdEsquema = "dbo.";
        private readonly string bdProcedure = "";


        public TrabajadorDA(string cnBD)
        {
            this.cnBD = cnBD;
            bdProcedure = bdEsquema + "SP_LISTAR_TRABAJADORES";
        }


        public List<Models.Entities.Trabajador> listarUsp()
        {
            sqlQuery = bdProcedure;

            using (SqlConnection sqlCn = new SqlConnection(this.cnBD))
            {
                var lista = sqlCn.Query<Models.Entities.Trabajador>(sqlQuery, commandType: CommandType.StoredProcedure).ToList();
                return lista;
            }
        }
    }
}

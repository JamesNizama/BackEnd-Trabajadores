using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace BackEnd_Trabajadores.Data
{
    public class DistritoDA
    {
        private readonly string cnBD = "";
        private string sqlQuery = "";
        private readonly string bdEsquema = "dbo.";
        private readonly string bdProcedure = "";

        public DistritoDA(string cnBD)
        {
            this.cnBD = cnBD;
            bdProcedure = bdEsquema + "SP_LISTAR_DISTRITO";
        }


        public List<Models.Entities.Distrito> listarUsp()
        {
            sqlQuery = bdProcedure;

            using (SqlConnection sqlCn = new SqlConnection(this.cnBD))
            {
                var lista = sqlCn.Query<Models.Entities.Distrito>(sqlQuery, commandType: CommandType.StoredProcedure).ToList();
                return lista;
            }
        }
    }
}

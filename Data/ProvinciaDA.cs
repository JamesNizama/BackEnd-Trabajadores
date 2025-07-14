using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace BackEnd_Trabajadores.Data
{
    public class ProvinciaDA
    {
        private readonly string cnBD = "";
        private string sqlQuery = "";
        private readonly string bdEsquema = "dbo.";
        private readonly string bdProcedure = "";


        public ProvinciaDA(string cnBD)
        {
            this.cnBD = cnBD;
            bdProcedure = bdEsquema + "SP_LISTAR_PROVINCIA";
        }


        public List<Models.Entities.Provincia> listarUsp()
        {
            sqlQuery = bdProcedure;

            using (SqlConnection sqlCn = new SqlConnection(this.cnBD))
            {
                var lista = sqlCn.Query<Models.Entities.Provincia>(sqlQuery, commandType: CommandType.StoredProcedure).ToList();
                return lista;
            }
        }
    }
}

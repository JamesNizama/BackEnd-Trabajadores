using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace BackEnd_Trabajadores.Data
{
    public class DepartamentoDA
    {
        private readonly string cnBD = "";
        private string sqlQuery = "";
        private readonly string bdEsquema = "dbo.";
        private readonly string bdProcedure = "";


        public DepartamentoDA(string cnBD)
        {
            this.cnBD = cnBD;
            bdProcedure = bdEsquema + "SP_LISTAR_DEPARTAMENTO";
        }


        public List<Models.Entities.Departamento> listarUsp()
        {
            sqlQuery = bdProcedure;

            using (SqlConnection sqlCn = new SqlConnection(this.cnBD))
            {
                var lista = sqlCn.Query<Models.Entities.Departamento>(sqlQuery, commandType: CommandType.StoredProcedure).ToList();
                return lista;
            }
        }
    }
}

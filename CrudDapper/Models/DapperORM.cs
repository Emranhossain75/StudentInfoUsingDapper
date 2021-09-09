using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudDapper.Models
{
    public static class DapperORM
    {
        private static string connectionstring = @"Data source = .;Initial catalog=DapperDb; integrated Security = True;";
        public static void Executewithoutreturn(string procedureName,DynamicParameters param= null)
        {
            using(SqlConnection sqlbd = new SqlConnection(connectionstring))
            {
                sqlbd.Open();
                sqlbd.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        public static T ExecuteReturnScalar<T> (string procedureName, DynamicParameters param= null)
        {
            using (SqlConnection sqlbd = new SqlConnection(connectionstring))
            {
                sqlbd.Open();
               return(T) Convert.ChangeType(sqlbd.Execute(procedureName, param, commandType: 
                   CommandType.StoredProcedure),typeof(T));
            }
        }

        public static IEnumerable<T>ReturnList<T>(string procedureName, DynamicParameters param=null)
        {
            using (SqlConnection sqlbd = new SqlConnection(connectionstring))
            {
                sqlbd.Open();
                return sqlbd.Query<T>(procedureName, param, commandType:
                    CommandType.StoredProcedure);
            }
        }

    }
}
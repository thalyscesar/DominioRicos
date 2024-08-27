using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data
{
    public class PostgresDB : FactoryConnection
    {
        public IDbConnection Create()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.PostgreSqlDialect();

            NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder();
            sb.Host = "localhost";
            sb.Username = "postgres";
            sb.Password = "postgres";
            sb.Database = "dd";
            sb.Port = 5432;
            sb.Timeout = 60;

            var conexao = new NpgsqlConnection(sb.ConnectionString);
            try
            {
                conexao.Open();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao conectar no banco.", ex);
            }
            return conexao;
        }
    }

    public interface FactoryConnection 
    {
        IDbConnection Create();
    }  
}

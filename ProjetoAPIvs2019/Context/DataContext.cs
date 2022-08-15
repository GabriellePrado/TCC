using API_TCC.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.Context
{
    public class DataContext : IDisposable
    {

        public IDbConnection Connection { get; }

        public DataContext(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration
                     .GetConnectionString("Connection"));
            Connection.Open();
        }
        public void Dispose() => Connection?.Dispose();
    }
}

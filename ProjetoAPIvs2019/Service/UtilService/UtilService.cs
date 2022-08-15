using Dapper;
using Microsoft.EntityFrameworkCore;
using ProjetoAPIvs2019.Context;
using ProjetoAPIvs2019.Service.Interfaces;
using ProjetoVendas.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.Service.UtilService
{
    public class UtilService : IUtilService
    {
        private DataContext _db;
        public UtilService(DataContext dbSession)
        {
            _db = dbSession;

        }

        public UtilService()
        {
        }

        public async Task<bool> ValidacaoIdAsync(string table, int id)
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string command = $"select * from {table} Where Id = {id}";
                    var result = await conn.ExecuteAsync(sql: command);
                    if (result >= 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}

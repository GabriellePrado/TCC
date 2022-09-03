using Dapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPIvs2019.Context;
using ProjetoAPIvs2019.DTO;
using ProjetoAPIvs2019.Model;
using ProjetoAPIvs2019.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProjetoAPIvs2019.Service
{
    public class LoginService : ILoginService
    {
        private DataContext _db;

        const string baseSql = @"SELECT *
                                  FROM [dbo].[TbPrestador]";
        public LoginService(DataContext dbSession)
        {
            _db = dbSession;
        }
        public async Task<string> CadastrarAsync(ResponsavelDTO obj)
        {
            using (var conn = _db.Connection)
            {
                int senha = Int32.Parse(obj.NumeroDocumento.Substring(obj.NumeroDocumento.Length, 4));
                var command = $"INSERT INTO TbUsuarios values ('{obj.NumeroDocumento}', {senha} )";
                var result = await conn.ExecuteAsync(sql: command);

                if (result == 1)
                {
                    return "Sucesso";
                }
                else
                {
                    return "Falhou";
                }
            }
        }

        public async Task<string> AtualizarAsync(string login, string senha)
        {
            using (var conn = _db.Connection)
            {
                var command = $"UPDATE TbUsuarios SET senha = {senha}' WHERE login = '{login}')";
                var result = await conn.ExecuteAsync(sql: command);

                if (result == 1)
                {
                    return "Sucesso";
                }
                else
                {
                    return "Falhou";
                }
            }
        }
        public Task<string> DeletarAsync(string login, int senha)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> ValidarLogin(string login, string senha)
        {
            using (var conn = _db.Connection)
            {
                var command = baseSql + $"WHERE login = '{login}' AND senha = '{senha}'";
                var result = await conn.ExecuteAsync(sql: command);

                if (result == 1)
                {
                    return "Sucesso";
                }
                else
                {
                    return "Falhou";
                }
            }
        }
    }
}

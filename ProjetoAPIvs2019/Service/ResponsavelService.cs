using API_TCC.Model;
using Dapper;
using Microsoft.EntityFrameworkCore;
using ProjetoAPIvs2019.Context;
using ProjetoAPIvs2019.Service.Interfaces;
using ProjetoVendas.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.Service
{
    public class ResponsavelService : IResponsavelService
    {
        private DataContext _db;

        const string baseSql = @"SELECT *
                                  FROM [dbo].[TbResponsavel]
                                  WHERE 1 = 1 ";

        public ResponsavelService(DataContext dbSession)
        {
            _db = dbSession;
        }

        public async Task<List<Responsavel>> BuscarAsync()
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM TbResponsavel";
                List<Responsavel> tarefas = (await conn.QueryAsync<Responsavel>(sql: query)).ToList();
                return tarefas;
            }
        }

        public async Task<int> CadastrarAsync(Responsavel obj)
        {
            using (var conn = _db.Connection)
            {
                string command = @"INSERT INTO TbResponsavel(Alterar campos)
    		VALUES(@Descricao, @IsCompleta)";
                var result = await conn.ExecuteAsync(sql: command);
                //resultado em 0 ou 1;
                return result;
            }
        }

        public async Task<int> DeletarAsync(int id)
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string command = @"DELETE FROM TbResponsavel WHERE Id = @id";
                    var resultado = await conn.ExecuteAsync(sql: command, param: new { id });
                    return resultado;
                }
            }
            catch (DbUpdateException e)
            {
                throw new IntegridadeExcecao("Não foi possível deletar\n" + e.Message);
            }
        }

        public async Task<int> AtualizarAsync(Responsavel obj)
        {
           
            try
            {
                using (var conn = _db.Connection)
                {
                    string command = @"UPDATE TbResponsavel SET IsCompleta = @IsCompleta WHERE Id = @Id";
                    var result = await conn.ExecuteAsync(sql: command);
                    return result;
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<Responsavel> BuscarId(int? id)
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string query = "SELECT * FROM TbResponsavel WHERE Id = @id";
                    Responsavel resp = await conn.QueryFirstOrDefaultAsync<Responsavel>
                        (sql: query, param: new { id });
                    return resp;
                }

            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
        }

        
    }
}

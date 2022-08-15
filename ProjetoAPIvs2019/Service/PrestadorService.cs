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
    public class PrestadorService : IPrestadorService
    {

        private DataContext _db;

        const string baseSql = @"SELECT *
                                  FROM [dbo].[Tb_Prestador]";

        public PrestadorService(DataContext dbSession)
        {
            _db = dbSession;
        }

        public async Task<int> CadastrarAsync(Prestador obj)
        {
            try
            {
                using (var conn = _db.Connection)
                {

                    string command = $"INSERT INTO Tb_Prestador values ('{obj.NomePrestador}', '{obj.Sobrenome}', " +
                        $"{obj.tipoDocumento}, '{obj.NumeroDocumento}', {obj.funcao}";
                    var result = await conn.ExecuteAsync(sql: command);
                    //resultado em 0 ou 1;
                    return result;
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<IEnumerable<Prestador>> AtualizarAsync(Prestador obj)
        {
            try
            {
                using (var conn = _db.Connection)
                {

                    string command = $"UPDATE Tb_Prestador SET Nome = '{obj.NomePrestador}', Sobrenome = '{obj.Sobrenome}', TipoDocumento = {((int)obj.tipoDocumento)}, " +
                        $"NumeroDocumento = '{obj.NumeroDocumento}', FuncaoPrestador = {obj.funcao} WHERE IdDependente = {obj.Id}";
                    var result = await conn.QueryAsync<Prestador>(sql: command);

                    return result;

                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }


        public async Task<List<Prestador>> BuscarAsync()
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string query = "SELECT * FROM Tb_Prestador";
                    List<Prestador> tarefas = (await conn.QueryAsync<Prestador>(sql: query)).ToList();
                    return tarefas;
                }
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<Prestador> BuscarId(int? id)
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string query = $"SELECT * FROM Tb_Prestador WHERE IdPrestador = {id}";
                    Prestador resp = await conn.QueryFirstOrDefaultAsync<Prestador>
                        (sql: query, param: new { id });
                    return resp;
                }

            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<string> DeletarAsync(int id)
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string command = @"DELETE FROM Tb_Prestador WHERE IdPrestador = @id";
                    var resultado = await conn.ExecuteAsync(sql: command, param: new { id });
                    return "Deletado com sucesso";
                }
            }
            catch (DbUpdateException e)
            {
                throw new IntegridadeExcecao("Não foi possível deletar\n" + e.Message);
            }
        }
    }
}

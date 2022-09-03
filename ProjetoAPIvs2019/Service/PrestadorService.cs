using API_TCC.Model;
using Dapper;
using Microsoft.EntityFrameworkCore;
using ProjetoAPIvs2019.Context;
using ProjetoAPIvs2019.DTO;
using ProjetoAPIvs2019.Service.Interfaces;
using ProjetoVendas.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.Service
{
    public class PrestadorService : IGenericaInterface<PrestadorDTO, Prestador>
    {

        private DataContext _db;

        const string baseSql = @"SELECT *
                                  FROM [dbo].[TbPrestador]";

        public PrestadorService(DataContext dbSession)
        {
            _db = dbSession;
        }

        public async Task<string> CadastrarAsync(PrestadorDTO obj)
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    // Obrigatóriamente tem que ser CNH 
                    string command = $"INSERT INTO TbPrestador values ('{obj.NomePrestador}', '{obj.Sobrenome}', " +
                        $"{(int)obj.tipoDocumento}, '{obj.NumeroDocumento}', {(int)obj.funcao})";
                    var result = await conn.ExecuteAsync(sql: command);
                    //resultado em 0 ou 1;
                    return "Cadastrado com Sucesso";
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<string> AtualizarAsync(Prestador obj)
        {
            try
            {
                using (var conn = _db.Connection)
                {

                    string command = $"UPDATE TbPrestador SET Nome = '{obj.NomePrestador}', Sobrenome = '{obj.Sobrenome}', TipoDocumento = {((int)obj.tipoDocumento)}, " +
                        $"NumeroDocumento = '{obj.NumeroDocumento}', FuncaoPrestador = {obj.funcao} WHERE IdDependente = {obj.Id}";
                    var result = await conn.QueryAsync<Prestador>(sql: command);

                    return "Atualizado com sucesso";

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
                    string query = "SELECT * FROM TbPrestador";
                    List<Prestador> tarefas = (await conn.QueryAsync<Prestador>(sql: query)).ToList();
                    return tarefas;
                }
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<Prestador> BuscarId(int id)
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string query = $"SELECT * FROM TbPrestador WHERE IdPrestador = {id}";
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
                    string command = @"DELETE FROM TbPrestador WHERE IdPrestador = @id";
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

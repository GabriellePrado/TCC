using API_TCC.Model;
using API_TCC.Model.Enum;
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
    public class DependenteService : IDependenteService
    {

        private DataContext _db;

        const string baseSql = @"SELECT *
                                  FROM [dbo].[Tb_Dependente]";

        // UtilService util = new UtilService();
        private IUtilService util;

        public DependenteService(DataContext dbSession)
        {
            _db = dbSession;

        }

        public async Task<int> CadastrarAsync(Dependente obj)
        {
            try
            {
                using (var conn = _db.Connection)
                {

                    string command = $"INSERT INTO Tb_Dependente values ('{obj.Nome}', '{obj.Sobrenome}', '{obj.DataNascimento}', '{obj.NomeResponsavel}', " +
                        $"{obj.TipoDocumento}, '{obj.NumeroDocumento}', {obj.TelefonesContatoEmergencia}, '{obj.Endereco}', {obj.Cep})";
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

        public async Task<IEnumerable<Dependente>> AtualizarAsync(Dependente obj)
        {

            try
            {
                using (var conn = _db.Connection)
                {

                    string command = $"UPDATE Tb_Dependente SET Nome = '{obj.Nome}', Sobrenome = '{obj.Sobrenome}', DataNascimento = '{obj.DataNascimento}', NomeResponsavel = '{obj.NomeResponsavel}'," +
                       $"TipoDocumento = {((int)obj.TipoDocumento)},NumeroDocumento = '{obj.NumeroDocumento}', TelefonesContatoEmergencia = {obj.TelefonesContatoEmergencia}, Endereco= '{obj.Endereco}', Cep = {obj.Cep}  WHERE IdDependente = {obj.Id}";
                    var result = await conn.QueryAsync<Dependente>(sql: command);

                    return result;

                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<List<Dependente>> BuscarAsync()
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string query = "SELECT * FROM Tb_Dependente";
                    List<Dependente> tarefas = (await conn.QueryAsync<Dependente>(sql: query)).ToList();
                    return tarefas;
                }
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
        }
    
    public async Task<Dependente> BuscarId(int id)
    {
        try
        {
            using (var conn = _db.Connection)
            {
                string query = $"SELECT * FROM Tb_Dependente WHERE IdDependente = {id}";
                Dependente resp = await conn.QueryFirstOrDefaultAsync<Dependente>
                    (sql: query, param: new { id });
                return resp;
            }

        }
        catch (DbUpdateConcurrencyException e)
        {

            throw new DbConcurrencyException(e.Message);
        }
    }

    public async Task<int> DeletarAsync(int id)
    {
        try
        {
            using (var conn = _db.Connection)
            {
                string command = @"DELETE FROM Tb_Dependente WHERE IdDependente = @id";
                var resultado = await conn.ExecuteAsync(sql: command, param: new { id });
                return resultado;
            }
        }
        catch (DbUpdateException e)
        {
            throw new IntegridadeExcecao("Não foi possível deletar\n" + e.Message);
        }
    }
}
}

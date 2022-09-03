using API_TCC.Model;
using API_TCC.Model.Enum;
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
    public class DependenteService : IGenericaInterface<DependenteDTO, Dependente>
    {

        private DataContext _db;

        const string baseSql = @"SELECT *
                                  FROM [dbo].[TbDependente]";

        // UtilService util = new UtilService();
        private IUtilService util;

        public DependenteService(DataContext dbSession)
        {
            _db = dbSession;

        }

        public async Task<string> CadastrarAsync(DTO.DependenteDTO obj)
        {
            try
            {
                using (var conn = _db.Connection)
                {

                    //pegar o IdResponsavel do usuario que está logado.
                    string command = $"INSERT INTO TbDependente values ('{obj.Nome}', '{obj.Sobrenome}', '{obj.DataNascimento}', '{obj.IdResponsavel}', " +
                        $"{obj.TipoDocumento}, '{obj.NumeroDocumento}', {obj.TelefonesContatoEmergencia}, '{obj.Endereco}', {obj.Cep})";
                    var result = await conn.ExecuteAsync(sql: command);
                    //resultado em 0 ou 1;
                    if( result == 1)
                    {
                        return "Sucesso";
                    }
                    else
                    {
                        return "Falhou";
                    }
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<string> AtualizarAsync(Dependente obj)
        {

            try
            {
                using (var conn = _db.Connection)
                {

                    string command = $"UPDATE TbDependente SET Nome = '{obj.Nome}', Sobrenome = '{obj.Sobrenome}', DataNascimento = '{obj.DataNascimento}', NomeResponsavel = '{obj.IdResponsavel}'," +
                       $"TipoDocumento = {((int)obj.TipoDocumento)},NumeroDocumento = '{obj.NumeroDocumento}', TelefonesContatoEmergencia = {obj.TelefonesContatoEmergencia}, Endereco= '{obj.Endereco}', Cep = {obj.Cep}  WHERE IdDependente = {obj.Id}";
                    var result = await conn.QueryAsync<Dependente>(sql: command);

                    return "Sucesso";

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
                    string query = "SELECT * FROM TbDependente";
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
                string query = $"SELECT * FROM TbDependente WHERE IdDependente = {id}";
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

    public async Task<string> DeletarAsync(int id)
    {
        try
        {
            using (var conn = _db.Connection)
            {
                string command = @"DELETE FROM TbDependente WHERE IdDependente = @id";
                var resultado = await conn.ExecuteAsync(sql: command, param: new { id });
                return "Deletado com Sucesso";
            }
        }
        catch (DbUpdateException e)
        {
            throw new IntegridadeExcecao("Não foi possível deletar\n" + e.Message);
        }
    }
}
}

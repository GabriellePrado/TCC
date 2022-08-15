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
    public class ResponsavelService : IGenericaInterface<ResponsavelDTO, Responsavel>
    {
        private DataContext _db;

        const string baseSql = @"SELECT *
                                  FROM [dbo].[Tb_Responsavel]";

        public ResponsavelService(DataContext dbSession)
        {
            _db = dbSession;
        }

        public async Task<string> CadastrarAsync(ResponsavelDTO obj)
        {
            try
            {
                using (var conn = _db.Connection)
                {

                    string command = $"INSERT INTO Tb_Responsavel values ('{obj.Nome}', '{obj.Sobrenome}', '{obj.Email}', " +
                        $"{obj.Tipodocumento}, '{obj.NumeroDocumento}', {obj.TelefonesContatoEmergencia}, '{obj.Endereco}', {obj.Cep}, {obj.Dependentes})";
                    var result = await conn.ExecuteAsync(sql: command);
                    //resultado em 0 ou 1;
                    return "Sucesso";
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<string> AtualizarAsync(Responsavel obj)
        {
            try
            {
                using (var conn = _db.Connection)
                {

                    string command = $"UPDATE Tb_Responsavel SET Nome = '{obj.Nome}', Sobrenome = '{obj.Sobrenome}', Email = '{obj.Email}', TipoDocumento = {((int)obj.Tipodocumento)}, " +
                        $"NumeroDocumento = '{obj.NumeroDocumento}', TelefonesContatoEmergencia = {obj.TelefonesContatoEmergencia}, Endereco= '{obj.Endereco}', Cep = {obj.Cep}, Dependente = {obj.Dependentes} WHERE IdResponsavel = {obj.Id}";
                    var result = await conn.QueryAsync<Responsavel>(sql: command);

                    return "Sucesso";

                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }


        public async Task<List<Responsavel>> BuscarAsync()
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string query = "SELECT * FROM Tb_Responsavel";
                    List<Responsavel> tarefas = (await conn.QueryAsync<Responsavel>(sql: query)).ToList();
                    return tarefas;
                }
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<Responsavel> BuscarId(int id)
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string query = $"SELECT * FROM Tb_Responsavel WHERE IdResponsavel = {id}";
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

        public async Task<string> DeletarAsync(int id)
        {
            try
            {
                using (var conn = _db.Connection)
                {
                    string command = @"DELETE FROM Tb_Responsavel WHERE IdResponsavel = @id";
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

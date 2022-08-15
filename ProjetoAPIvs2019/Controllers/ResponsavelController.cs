using API_TCC.Model;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPIvs2019.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.Controllers
{
    [Route("api/Responsavel")]
    [ApiController]
    public class ResponsavelController : ControllerBase
    {
        private readonly IResponsavelService _repositorio;
        public ResponsavelController(IResponsavelService tarefaRepo)
        {
            _repositorio = tarefaRepo;
        }
        [HttpGet]
        [Route("Buscar-Responsaveis")]
        public async Task<IActionResult> BuscarAsync()
        {
            var result = await _repositorio.BuscarAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("Buscar{id}")]
        public async Task<IActionResult> BuscarId(int id)
        {
            var tarefa = await _repositorio.BuscarId(id);
            return Ok(tarefa);
        }

        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(Responsavel responsavel)
        {
            var result = await _repositorio.CadastrarAsync(responsavel);
            return Ok(result);
        }
        [HttpPost]
        [Route("Atualizar")]
        public async Task<IActionResult> Atualizar(Responsavel responsavel)
        {
            var result = await _repositorio.AtualizarAsync(responsavel);
            return Ok(result);
        }
        [HttpDelete]
        [Route("Remover")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var resultado = await _repositorio.DeletarAsync(id);
            return Ok(resultado);
        }
    }
}

using API_TCC.Model;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPIvs2019.DTO;
using ProjetoAPIvs2019.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.Controllers
{
    [ApiController]
    [Route("api/Dependente")]
    public class DependenteController : ControllerBase
    {
        private readonly IGenericaInterface<DependenteDTO, Dependente> _repositorio;
        public DependenteController(IGenericaInterface<DependenteDTO, Dependente> tarefaRepo)
        {
            _repositorio = tarefaRepo;
        }
        [HttpGet]
        [Route("Buscar-Dependentes")]
        public async Task<IActionResult> BuscarAsync()
        {
            var result = await _repositorio.BuscarAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("Buscar-Dependente{id}")]
        public async Task<IActionResult> BuscarId(int id)
        {
            var tarefa = await _repositorio.BuscarId(id);
            return Ok(tarefa);
        }

        [HttpPost]
        [Route("Cadastrar-Dependentes")]
        public async Task<IActionResult> Cadastrar([FromBody] DependenteDTO dependente)
        {
            var result = await _repositorio.CadastrarAsync(dependente);
            return Ok(result);
        }
        [HttpPost]
        [Route("Atualizar-Dependentes")]
        public async Task<IActionResult> AtualizarAsync(Dependente dependente)
        {
            var result = await _repositorio.AtualizarAsync(dependente);
            return Ok(result);
        }
        [HttpDelete]
        [Route("Remover-Dependentes")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var resultado = await _repositorio.DeletarAsync(id);
            return Ok(resultado);
        }
    }
}

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
    [Route("api/Prestador")]
    public class PrestadorController : ControllerBase
    {
        private readonly IGenericaInterface<PrestadorDTO, Prestador> _repositorio;
        public PrestadorController(IGenericaInterface<PrestadorDTO, Prestador> tarefaRepo)
        {
            _repositorio = tarefaRepo;
        }
        [HttpGet]
        [Route("Buscar-Prestador")]
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
        public async Task<IActionResult> Cadastrar(PrestadorDTO prestador)
        {
            var result = await _repositorio.CadastrarAsync(prestador);
            return Ok(result);
        }
        [HttpPost]
        [Route("Atualizar")]
        public async Task<IActionResult> AtualizarAsync(Prestador prestador)
        {
            var result = await _repositorio.AtualizarAsync(prestador);
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

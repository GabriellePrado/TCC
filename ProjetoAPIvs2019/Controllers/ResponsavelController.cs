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
    [Route("api/Responsavel")]
    [ApiController]
    public class ResponsavelController : ControllerBase
    {
        private readonly IGenericaInterface<ResponsavelDTO, Responsavel> _repositorio;
        private readonly ILoginService _repositorioLogin;
        public ResponsavelController(IGenericaInterface<ResponsavelDTO, Responsavel> tarefaRepo)
        {
            _repositorio = tarefaRepo;
        }
        [HttpGet]
        [Route("Buscar-Responsavel")]
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
        [Route("Cadastrar-Responsavel")]
        public async Task<IActionResult> Cadastrar(ResponsavelDTO responsavel)
        {
            var retornoCadastroUsuario = await _repositorio.CadastrarAsync(responsavel);
            //Cadastra junto o login
            var retornoCadastroLogin = await _repositorioLogin.CadastrarAsync(responsavel);
      
            // fazer futura validação com status code 
            return Ok(retornoCadastroUsuario);
        }
        [HttpPost]
        [Route("Atualizar-Responsavel")]
        public async Task<IActionResult> Atualizar(Responsavel responsavel)
        {
            var result = await _repositorio.AtualizarAsync(responsavel);
            return Ok(result);
        }
        [HttpDelete]
        [Route("Remover-Responsavel")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var resultado = await _repositorio.DeletarAsync(id);
            return Ok(resultado);
        }
    }
}

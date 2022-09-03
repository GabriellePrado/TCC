using API_TCC.Model;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPIvs2019.DTO;
using ProjetoAPIvs2019.Model;
using ProjetoAPIvs2019.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.Controllers
{
    [ApiController]
    [Route("api/Login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _repositorioLogin;
        public LoginController(ILoginService _repositorio)
        {
            _repositorio = _repositorioLogin;
        }
        [HttpGet]
        [Route("Validacao")]
        public async Task<IActionResult> ValidaLogin(string login, string senha)
        {
            var result = await _repositorioLogin.ValidarLogin(login, senha);
            return Ok(result);
        }
    }
}

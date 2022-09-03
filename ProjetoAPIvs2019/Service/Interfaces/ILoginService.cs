using ProjetoAPIvs2019.DTO;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.Service.Interfaces
{
    public interface ILoginService
    {

        Task<string> CadastrarAsync(ResponsavelDTO obj);
        Task<string> AtualizarAsync(string login, string senha);
        Task<string> DeletarAsync(string login, int senha);
        Task<string> ValidarLogin(string login, string senha);
    }
}

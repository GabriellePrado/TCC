using API_TCC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.Service.Interfaces
{
    public interface IResponsavelService
    {
       Task<List<Responsavel>> BuscarAsync();

        Task<int> CadastrarAsync(Responsavel obj);

        Task<int> DeletarAsync(int id);

        Task<int> AtualizarAsync(Responsavel obj);

        Task<Responsavel> BuscarId(int? id);



    }
}

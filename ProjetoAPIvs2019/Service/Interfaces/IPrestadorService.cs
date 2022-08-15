using API_TCC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.Service.Interfaces
{
    public interface IPrestadorService
    {

        Task<int> CadastrarAsync(Prestador obj);
        Task<IEnumerable<Prestador>> AtualizarAsync(Prestador obj);
        Task<List<Prestador>> BuscarAsync();
        Task<Prestador> BuscarId(int? id);
        Task<int> DeletarAsync(int id);



    }
}

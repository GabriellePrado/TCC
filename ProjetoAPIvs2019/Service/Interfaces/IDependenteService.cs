using API_TCC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.Service.Interfaces
{
    public interface IDependenteService
    {
        Task<List<Dependente>> BuscarAsync();

        Task<int> CadastrarAsync(Dependente obj);

        Task<int> DeletarAsync(int id);

        Task<IEnumerable<Dependente>> AtualizarAsync(Dependente obj);

        Task<Dependente> BuscarId(int id);
    }
}

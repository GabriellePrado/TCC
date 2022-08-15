using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.Service.Interfaces
{
    public interface IGenericaInterface<ClassDTO, Class> where ClassDTO : class
    {

        Task<string> CadastrarAsync(ClassDTO obj);
        Task<string> AtualizarAsync(Class obj);
        Task<List<Class>> BuscarAsync();
        Task<Class> BuscarId(int id);
        Task<string> DeletarAsync(int id);

    }
}

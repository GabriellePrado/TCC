using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.Service.Interfaces
{
    public interface IUtilService
    {
        Task<bool> ValidacaoIdAsync(string table, int id);
    }
}

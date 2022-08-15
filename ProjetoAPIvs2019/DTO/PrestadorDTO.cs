using API_TCC.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.DTO
{
    public class PrestadorDTO
    {
        public string NomePrestador { get; set; }
        public string Sobrenome { get; set; }

        public Documento tipoDocumento { get; set; }

        public int NumeroDocumento { get; set; }

        public FuncaoPrestador funcao { get; set; }

    }
}

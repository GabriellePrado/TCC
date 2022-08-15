using API_TCC.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.DTO
{
    public class DependenteDTO
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DateTime DataNascimento { get; set; }

        //pegar o IdResponsavel do usuario que está logado.
        public int IdResponsavel { get; set; }

        public Documento TipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public int TelefonesContatoEmergencia { get; set; }

        // buscar pelo CEP e preencher campos - 
        public string Endereco { get; set; }
        public int Cep { get; set; }

    }
}

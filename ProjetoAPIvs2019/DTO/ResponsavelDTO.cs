using API_TCC.Model.Enum;
using API_TCC.Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPIvs2019.DTO
{
    public class ResponsavelDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }

        public Documento Tipodocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public int TelefonesContatoEmergencia { get; set; }
        public Endereco Endereco { get; set; }
        // no swagger o CEP está aparecendo 2 vezes pois na classe de Endereço já tem cep, porém o cep digitado pela usuaria que vai preencher os outros campos 
        public int Cep { get; set; }
        public int Dependentes { get; set; }
    }
}

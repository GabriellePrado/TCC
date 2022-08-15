using API_TCC.Model.Enum;
using API_TCC.Model.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TCC.Model
{
    public class Responsavel
    {
        public int Id { get; set; }
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
       

        public Responsavel()
        {
        }

        public Responsavel(string nome, string sobrenome, string email, Documento tipodocumento, string numeroDocumento, int telefonesContatoEmergencia, Endereco endereco, int cep, int dependentes)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Tipodocumento = tipodocumento;
            NumeroDocumento = numeroDocumento;
            TelefonesContatoEmergencia = telefonesContatoEmergencia;
            Endereco = endereco;
            Cep = cep;
            Dependentes = dependentes;
        }
    }
}

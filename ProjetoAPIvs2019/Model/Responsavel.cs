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

        public int Tipodocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public int TelefonesContatoEmergencia { get; set; }
        Endereco Endereco { get; set; }
        public int Cep { get; set; }
        public List<Dependente> Dependentes { get; set; }
       

        public Responsavel()
        {
        }

        public Responsavel(int id, string nome, string sobrenome, string email, int tipodocumento, string numeroDocumento, int telefonesContatoEmergencia, Endereco endereco, int cep, List<Dependente> dependentes)
        {
            Id = id;
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

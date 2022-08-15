using API_TCC.Model.Enum;
using API_TCC.Model.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TCC.Model
{
    public class Dependente
    {
        public int Id { get; set; }
     

        public string Nome { get; set; }

        public string  Sobrenome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string NomeResponsavel { get; set; }

        public Documento TipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public int TelefonesContatoEmergencia { get; set; }

        // buscar pelo CEP e preencher campos - 
        public string Endereco { get; set; }
        public int Cep { get; set; }

        public Dependente(int id, string nome, string sobrenome, DateTime dataNascimento, string nomeResponsavel, Documento tipoDocumento, string numeroDocumento, int telefonesContatoEmergencia, string endereco, int cep)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            NomeResponsavel = nomeResponsavel;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            TelefonesContatoEmergencia = telefonesContatoEmergencia;
            Endereco = endereco;
            Cep = cep;
        }

        public Dependente()
        {
        }


    }
}

using API_TCC.Model.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TCC.Model
{
    public class Prestador
    {

        public int Id { get; set; }

 
        public string NomePrestador { get; set; }
        public string Sobrenome { get; set; }

        public Documento tipoDocumento { get; set; }
    
        public int NumeroDocumento { get; set; }
      
        public FuncaoPrestador funcao { get; set; }

        public Prestador(int id, string nomePrestador, string sobrenome, Documento tipoDocumento, int numeroDocumento, FuncaoPrestador funcao)
        {
            Id = id;
            NomePrestador = nomePrestador;
            Sobrenome = sobrenome;
            this.tipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            this.funcao = funcao;
        }

        public Prestador()
        {
        }
    }
}

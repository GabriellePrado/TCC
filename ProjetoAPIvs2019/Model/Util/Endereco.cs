namespace API_TCC.Model.Util
{
    public class Endereco
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        private int Cep { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }

        private Responsavel responsavel;
        public Endereco()
        {
        }

        public Endereco(string rua, string bairro,  int numero, string complemento, string cidade)
        {
            Rua = rua;
            Bairro = bairro;
            Cep = responsavel.Cep;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
        }
    }
}

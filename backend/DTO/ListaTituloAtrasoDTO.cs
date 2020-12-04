namespace TituloEmAtraso.DTO
{
    public class ListaTituloAtrasoDTO
    {
        public ListaTituloAtrasoDTO()
        {

        }

        public int NumeroTitulo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int QuantidadeParcelas { get; set; }
        public double ValorOriginal { get; set; }
        public double DiasAtraso { get; set; }
        public double ValorAtualizado { get; set; }

    }
}

namespace PedidosAPI.Application.ViewModel
{
    public class ProdutoViewModel
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }

        public ProdutoViewModel(string nome, int quantidade, double preco)
        {
            this.Nome = nome;
            this.Quantidade = quantidade;
            this.Preco = preco;
        }
    }
}

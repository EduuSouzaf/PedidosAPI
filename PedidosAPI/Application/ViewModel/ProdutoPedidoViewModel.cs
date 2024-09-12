namespace PedidosAPI.Application.ViewModel
{
    public class ProdutoPedidoViewModel
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public bool Status { get; set; }

        public ProdutoPedidoViewModel(int idPedido, int idProduto, string nome, int quantidade, double valor, bool status)
        {
            this.IdPedido = idPedido;
            this.IdProduto = idProduto;
            this.Nome = nome;
            this.Quantidade = quantidade;
            this.Valor = valor;
            this.Status = status;
        }
    }
}

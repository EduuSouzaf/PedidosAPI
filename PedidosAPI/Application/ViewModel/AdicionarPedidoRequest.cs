namespace PedidosAPI.Application.ViewModel
{
    public class AdicionarPedidoRequest
    {
        public PedidoViewModel Pedido { get; set; }
        public List<ProdutoPedidoViewModel> Produtos { get; set; }

    }
}

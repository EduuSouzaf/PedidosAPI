namespace PedidosAPI.Domain.Entities.Pedido
{
    public interface IProdutoPedidoRepository
    {
        bool Adicionar(List<ProdutoPedido> produtoPedidos);
        List<ProdutoPedido> Listar(int pageNumber, int pageQuantity);
        Pedido ObterPorId(int id);
        void Remover(int idPedido, int idProduto);
    }
}

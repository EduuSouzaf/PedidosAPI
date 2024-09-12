namespace PedidosAPI.Domain.Entities.Pedido
{
    public interface IPedidoRepository
    {
        bool Adicionar(Pedido pedido);
        List<Pedido> Listar(int pageNumber, int pageQuantity);
        Pedido ObterPorId(int id);
        void Atualizar(Pedido pedido);
    }
}

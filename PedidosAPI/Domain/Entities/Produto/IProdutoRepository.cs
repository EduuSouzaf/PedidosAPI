namespace PedidosAPI.Domain.Entities.Produto
{
    public interface IProdutoRepository
    {
        void Adicionar(Produto produto);
        List<Produto> Listar(int pageNumber, int pageQuantity);
        Produto ObterPorId(int id);
        bool VerificarSeProdutoExiste(int idProduto);
    }
}

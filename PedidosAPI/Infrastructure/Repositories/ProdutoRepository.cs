using PedidosAPI.Domain.Entities.Produto;

namespace PedidosAPI.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public List<Produto> Listar(int pageNumber, int pageQuantity)
        {
            return _context.Produtos.Skip(pageNumber * pageQuantity).Take(pageQuantity).ToList();
        }

        public Produto ObterPorId(int id)
        {
            return _context.Produtos.Find(id);
        }
        public bool VerificarSeProdutoExiste(int idProduto)
        {
            return _context.Produtos.Any(p => p.Id == idProduto);
        }
    }
}

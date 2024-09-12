using Microsoft.EntityFrameworkCore;
using PedidosAPI.Domain.Entities.Pedido;

namespace PedidosAPI.Infrastructure.Repositories
{
    public class ProdutoPedidoRepository : IProdutoPedidoRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public bool Adicionar(List<ProdutoPedido> produtoPedidos)
        {
            try
            {
                if (produtoPedidos == null || !produtoPedidos.Any())
                {
                    throw new ArgumentException("A lista de produtos pedidos é nula ou vazia.");
                }

                foreach (var produtoPedido in produtoPedidos)
                {
                    if (produtoPedido == null)
                    {
                        throw new ArgumentException("Um dos itens de produto pedido é nulo.");
                    }

                    if (produtoPedido.Id > 0)
                    {
                        _context.Entry(produtoPedido).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.ProdutosPedidos.Add(produtoPedido);
                    }
                }

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar produtos ao pedido: " + ex.Message, ex);
            }
        }


        public List<ProdutoPedido> Listar(int pageNumber, int pageQuantity)
        {
            return _context.ProdutosPedidos
                .Skip((pageNumber - 1) * pageQuantity)
                .Take(pageQuantity)
                .ToList();
        }

        public Pedido ObterPorId(int id)
        {
            return _context.Pedidos
                .Include(p => p.Itens)
                .FirstOrDefault(p => p.Id == id);
        }
        public void Remover(int idPedido, int idProduto)
        {
            var produtoPedido = _context.ProdutosPedidos
                .FirstOrDefault(pp => pp.IdPedido == idPedido && pp.IdProduto == idProduto);

            if (produtoPedido != null)
            {
                _context.ProdutosPedidos.Remove(produtoPedido);
                _context.SaveChanges();
            }
        }
    }
}

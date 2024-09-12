using Microsoft.EntityFrameworkCore;
using PedidosAPI.Domain.Entities.Pedido;

namespace PedidosAPI.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public bool Adicionar(Pedido pedido)
        {
            try
            {
                if (pedido.Id > 0)
                {
                    _context.Entry(pedido).State = EntityState.Modified;
                }
                else
                {
                    _context.Pedidos.Add(pedido);
                }

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar o pedido" + ex.Message);
            }
        }

        public List<Pedido> Listar(int pageNumber, int pageQuantity)
        {
            return _context.Pedidos.Skip(pageNumber * pageQuantity).Take(pageQuantity).ToList();
        }

        public Pedido ObterPorId(int id)
        {
            var pedido = _context.Pedidos.Find(id);

            if (pedido == null)
            {
                throw new KeyNotFoundException("Pedido não encontrado.");
            }

            return pedido;
        }
        public void Atualizar(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
        }
    }
}

using PedidosAPI.Domain.Entities.Pedido;
using PedidosAPI.Domain.Entities.Produto;
using PedidosAPI.Enum;
using PedidosAPI.Infrastructure.Repositories;
using PedidosAPI.ValueObjects;

namespace PedidosAPI.Services
{
    public class PedidoServices
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoPedidoRepository _produtoPedidoRepository;

        public PedidoServices(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, IProdutoPedidoRepository produtoPedidoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
            _pedidoRepository = pedidoRepository ?? throw new ArgumentNullException(nameof(pedidoRepository));
            _produtoPedidoRepository = produtoPedidoRepository;
        }

        public bool VerificarProdutosExistem(List<int> idsProdutos)
        {
            return idsProdutos.All(id => _produtoRepository.VerificarSeProdutoExiste(id));
        }

        public bool CancelarPedido(int idPedido)
        {
            var pedido = _pedidoRepository.ObterPorId(idPedido);
            if (pedido == null)
            {
                throw new ArgumentException("Pedido não encontrado.");
            }

            if (pedido.Status == EnumStatusPedido.Cancelado)
            {
                throw new InvalidOperationException("O pedido já está cancelado.");
            }

            pedido.Status = EnumStatusPedido.Cancelado;
            _pedidoRepository.Atualizar(pedido);

            return true;
        }
        public bool FecharPedido(int idPedido)
        {
            var pedido = _pedidoRepository.ObterPorId(idPedido);
            if (pedido == null)
            {
                throw new ArgumentException("Pedido não encontrado.");
            }

            if (pedido.Status == EnumStatusPedido.Fechado)
            {
                throw new InvalidOperationException("O pedido já está fechado.");
            }

            var produtos = _produtoPedidoRepository.Listar(0, int.MaxValue)
                            .Where(p => p.IdPedido == idPedido);

            if (!produtos.Any())
            {
                throw new InvalidOperationException("O pedido não pode ser fechado pois não contém produtos.");
            }

            pedido.Status = EnumStatusPedido.Fechado;
            _pedidoRepository.Atualizar(pedido);

            return true;
        }
        public void RemoverProdutoDoPedido(int idPedido, int idProduto)
        {
            var produtoPedido = _produtoPedidoRepository
                .Listar(0, int.MaxValue)
                .FirstOrDefault(pp => pp.IdPedido == idPedido && pp.IdProduto == idProduto);

            if (produtoPedido == null)
            {
                throw new ArgumentException("Item do pedido não encontrado.");
            }

            _produtoPedidoRepository.Remover(idPedido, idProduto);
        }
    }
}

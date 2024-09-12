using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Application.Services;
using PedidosAPI.Application.ViewModel;
using PedidosAPI.Domain.Entities.Pedido;
using PedidosAPI.Enum;
using PedidosAPI.Services;
using PedidosAPI.ValueObjects;

namespace PedidosAPI.Controllers
{
    [ApiController]
    [Route("api/v1/pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoPedidoRepository _produtoPedidoRepository;
        private readonly ParceiroService _parceiroService;
        private readonly PedidoServices _pedidoService;

        public PedidoController(IPedidoRepository pedidoRepository, IProdutoPedidoRepository produtoPedidoRepository, ParceiroService parceiroService, PedidoServices pedidoService)
        {
            _pedidoRepository = pedidoRepository ?? throw new ArgumentNullException(nameof(pedidoRepository));
            _produtoPedidoRepository = produtoPedidoRepository ?? throw new ArgumentNullException(nameof(produtoPedidoRepository));
            _parceiroService = parceiroService ?? throw new ArgumentNullException(nameof(parceiroService));
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] AdicionarPedidoRequest request)
        {
            if (request.Pedido == null || request.Produtos == null)
            {
                return BadRequest("Dados inválidos.");
            }

            if (!_parceiroService.VerificarSeParceiroExiste(request.Pedido.IdParceiro))
            {
                return BadRequest("Parceiro não cadastrado.");
            }

            var idsProdutos = request.Produtos.Select(p => p.IdProduto).Distinct().ToList();
            if (!_pedidoService.VerificarProdutosExistem(idsProdutos))
            {
                return BadRequest("Um ou mais produtos não cadastrados.");
            }

            var status = new StatusPedido(request.Pedido.Status);
            var tipoPedido = new TipoPedido(request.Pedido.TipoPedido);
            var pedido = new Pedido(
                request.Pedido.IdParceiro,
                request.Pedido.TipoPedido,
                request.Pedido.Status,
                request.Pedido.TotalPedido
            );

            var produtoPedidos = request.Produtos.Select(t =>
                new ProdutoPedido(
                    pedido.Id,
                    t.IdProduto,
                    t.Nome,
                    t.Quantidade,
                    t.Valor,
                    t.Status
                )
            ).ToList();

            if (_pedidoRepository.Adicionar(pedido))
            {
                // Atualiza o idPedido em cada produto com o id do pedido gerado
                foreach (var produtoPedido in produtoPedidos)
                {
                    produtoPedido.IdPedido = pedido.Id;
                }

                if (_produtoPedidoRepository.Adicionar(produtoPedidos))
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(500, "Falha ao adicionar produtos.");
                }
            }
            else
            {
                return StatusCode(500, "Falha ao adicionar o pedido.");
            }
        }

        [HttpGet]
        public IActionResult Listar(int pageNumber, int pageQuantity)
        {
            var pedidos = _pedidoRepository.Listar(pageNumber, pageQuantity);
            var produtoPedidos = _produtoPedidoRepository.Listar(pageNumber, pageQuantity);

            foreach (var pedido in pedidos)
            {
                pedido.Itens = produtoPedidos.Where(p => p.IdPedido == pedido.Id).ToList();
            }

            return Ok(pedidos);
        }
        [HttpPut("cancelar/{id}")]
        public IActionResult CancelarPedido(int id)
        {
            try
            {
                _pedidoService.CancelarPedido(id);
                return Ok("Pedido cancelado com sucesso.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }

        [HttpPut("fechar/{id}")]
        public IActionResult FecharPedido(int id)
        {
            try
            {
                _pedidoService.FecharPedido(id);
                return Ok("Pedido fechado com sucesso.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }
        }

        [HttpDelete("{idPedido}/item/{idProduto}")]
        public IActionResult RemoverItem(int idPedido, int idProduto)
        {
            try
            {
                _pedidoService.RemoverProdutoDoPedido(idPedido, idProduto);
                return Ok("Item removido com sucesso.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}

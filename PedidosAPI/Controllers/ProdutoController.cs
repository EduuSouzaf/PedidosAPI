using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Application.ViewModel;
using PedidosAPI.Domain.Entities.Produto;
using PedidosAPI.ValueObjects;

namespace PedidosAPI.Controllers
{
    [ApiController]
    [Route("api/v1/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        }

        [HttpPost]
        public IActionResult Adicionar(ProdutoViewModel produtoView)
        {
            var nome = new Nome(produtoView.Nome);
            var produto = new Produto(produtoView.Nome,
                                      produtoView.Quantidade,
                                      produtoView.Preco);
            _produtoRepository.Adicionar(produto);
            return Ok();
        }

        [HttpGet]
        public IActionResult Listar(int pageNumber, int pageQuantity)
        {
            var produtos = _produtoRepository.Listar(pageNumber, pageQuantity);
            return Ok(produtos);
        }
    }
}

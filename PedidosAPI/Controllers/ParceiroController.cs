using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Application.ViewModel;
using PedidosAPI.Domain.Entities.Parceiro;
using PedidosAPI.ValueObjects;

namespace PedidosAPI.Controllers
{
    [ApiController]
    [Route("api/v1/parceiro")]
    public class ParceiroController : ControllerBase
    {
        private readonly IParceiroRepository _parceiroRepository;

        public ParceiroController(IParceiroRepository parceiroRepository)
        {
            _parceiroRepository = parceiroRepository ?? throw new ArgumentNullException(nameof(parceiroRepository));
        }

        //[Authorize]
        [HttpPost]
        public IActionResult Adicionar(ParceiroViewModel parceiroView)
        {
            try
            {
                var email = new Email(parceiroView.Email);
                var telefone = new Telefone(parceiroView.Telefone);
                var nome = new NomePessoa(parceiroView.Nome);
                var parceiro = new Parceiro(nome,
                                            email,
                                            telefone,
                                            parceiroView.Status);
                _parceiroRepository.Adicionar(parceiro);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }


        [HttpGet]
        public IActionResult Listar(int pageNumber, int pageQuantity)
        {
            //throw new Exception("Teste");
            var parceiros = _parceiroRepository.Listar(pageNumber, pageQuantity);
            return Ok(parceiros);
        }
    }
}

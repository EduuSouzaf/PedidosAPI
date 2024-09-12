using Microsoft.AspNetCore.Mvc;
using PedidosAPI.Application.Services;
using PedidosAPI.Domain.Entities.Parceiro;

namespace PedidosAPI.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "manager" && password == "1234")
            {
                var token = TokenServices.GenerateToken(new Parceiro());

                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}

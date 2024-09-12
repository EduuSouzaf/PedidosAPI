using Microsoft.IdentityModel.Tokens;
using PedidosAPI.Domain.Entities.Parceiro;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PedidosAPI.Application.Services
{
    public class TokenServices
    {
        public static object GenerateToken(Parceiro parceiro)
        {
            var key = Encoding.ASCII.GetBytes(Key.Secret);
            var tokrnConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("parceiro", parceiro.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokrnConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new
            {
                token = tokenString
            };
        }
    }
}

using gerenciamentoDeBiblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace gerenciamentoDeBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            if(login.Login == "admin" && login.Senha == "admin")
            {
                var token = GerarTokemJWT();
                return Ok(new { token });
            }

            return BadRequest(new { mensagem = "Credenciais inválidas. Por favor, verifique seu nome de usuário e senha"});
        }

        private string GerarTokemJWT()
        {
            string chaveSecreta = "5c7b28c2-f53d-4ebd-a8f4-d7f536e1d3ea";

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("login", "admin"),
                new Claim("nome", "Administrador do Sistema")
            };

            var token = new JwtSecurityToken(
                issuer: "ferreira_costa",
                audience: "biblioteca",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credencial
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

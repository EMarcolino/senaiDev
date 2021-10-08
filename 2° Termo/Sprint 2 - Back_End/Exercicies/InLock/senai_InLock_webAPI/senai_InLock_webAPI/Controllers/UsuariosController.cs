using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_InLock_webAPI.Domains;
using senai_InLock_webAPI.Interfaces;
using senai_InLock_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace senai_InLock_webAPI.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Usuarios
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    // Controller responsável pelos endpoints (URLs) referentes aos usuários
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _usuarioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de estúdios com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um usuário através de seu id
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="usuarioDomain"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idJogo}")]
        public IActionResult Put(int idUsuario, UsuarioDomain usuarioDomain)
        {
            try
            {
                _usuarioRepository.AtualizarUrl(idUsuario, usuarioDomain);
                return Ok(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um jogo pelo seu id
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idJogo}")]
        public IActionResult Delete(int idUsuario)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarId(idUsuario);

            if (usuarioBuscado != null)
            {
                try
                {
                    _usuarioRepository.Delete(idUsuario);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound("Nenhum jogo foi encontrado!");

        }

        /// <summary>
        /// Faz a autenticação do usuário
        /// </summary>
        /// <param name="login">objeto com os dados de e-mail e senha</param>
        /// <returns>Um status code e, em caso de sucesso, os dados do usuário buscado</returns>
        [HttpPost("Login")]
        public IActionResult Login(UsuarioDomain login)
        {
            // Busca o usuário pelo e-mail e senha
            UsuarioDomain usuarioBuscado = _usuarioRepository.Login(login.email, login.senha);

            // Caso não encontre nenhum usuário com o e-mail e senha informados
            if (usuarioBuscado == null)
            {
                // retorna NotFound com uma mensagem personalizada
                return NotFound("E-mail ou senha inválidos!");
            }

            // Caso encontre, prossegue para a criação do token

            // Define os dados que serão fornecidos no token - Payload
            var claims = new[]
            {
                // Formato da Claim = TipoDaClaim, ValorDaClaim
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString())
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gerar o token
            var token = new JwtSecurityToken(
                issuer: "inLock.webAPI",                // emissor do token
                audience: "inLock.webAPI",              // destinatário do token
                claims: claims,                         // dados definidos acima (linha 59)
                expires: DateTime.Now.AddMinutes(30),   // tempo de expiração
                signingCredentials: creds               // credenciais do token
            );

            // Retorna um status code 200 - Ok com o token criado
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}

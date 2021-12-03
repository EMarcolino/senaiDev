using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_SpMedicalGroup_webAPI.Domains;
using senai_SpMedicalGroup_webAPI.Interfaces;
using senai_SpMedicalGroup_webAPI.Repositories;
using senai_SpMedicalGroup_webAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_SpMedicalGroup_webAPI.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints (URLs) referentes ao Login
    /// </summary>

    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Login
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]       
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _usuarioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="login">Objeto login que contém o e-mail e a senha do usuário</param>
        /// <returns>Retorna um token com as informações do usuário</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                //
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                //
                if (usuarioBuscado == null)
                {
                    return BadRequest("Email ou Senha inválidos!");
                }
                    //
                    var myClaims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
                    };
                    
                    //
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SpMedGroup-Autentication-Key"));
                    
                    //
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    //
                    var myToken = new JwtSecurityToken(
                            issuer: "SpMedicalGroup.webAPI",
                            audience: "SpMedicalGroup.webAPI",
                            claims: myClaims,
                            expires: DateTime.Now.AddMinutes(45),
                            signingCredentials: creds
                     );

                    return Ok(new
                    {
                        //
                        token = new JwtSecurityTokenHandler().WriteToken(myToken)
                    });                
            }
            catch (Exception ex)
            {

                return BadRequest(ex); 
            }           
           
        }
    }
}

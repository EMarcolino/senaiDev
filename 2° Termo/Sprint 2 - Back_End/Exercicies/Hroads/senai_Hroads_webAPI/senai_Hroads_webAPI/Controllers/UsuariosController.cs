using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_Hroads_webAPI.Domains;
using senai_Hroads_webAPI.Interfaces;
using senai_Hroads_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    // Controlador responsável pelos endponts (URLs) referentes a Usuarios

    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _usuarioRepository que irá receber todos os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.ListarUsuarios());
        }

        /// <summary>
        /// Busca um usuario por seu id
        /// </summary>
        /// <param name="idUsuario">id do usuario que será buscado</param>
        /// <returns>Um usuario buscada</returns>
        [HttpGet("{idUsuario}")]
        public IActionResult BuscarUsuario(int idUsuario)
        {
            return Ok(_usuarioRepository.BuscarPorId(idUsuario));
        }

        /// <summary>
        /// Cadastra uma novo usuario 
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que possui as informações que serão cadastrada</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            //Faz a chamada para o método .Cadastrar enviando as informações de cadastro para o banco 
            _usuarioRepository.Cadastrar(novoUsuario);

            //Retorna um Status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza as informações de um usuario 
        /// </summary>
        /// <param name="idUsuario">Id do usuario que será atualizada</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações que serão atualizadas</param>
        /// <returns></returns>
        [HttpPut("{idUsuario}")]
        public IActionResult Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            //Faz a chamada para o método .Atualizar enviando as novas informações para o banco
            _usuarioRepository.Atualizar(idUsuario, usuarioAtualizado);

            //Retorna um status code 204 - No Content
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="idUsuario">Id do usuario que será cadastrado</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(int idUsuario)
        {
            //Faz a chamada para o método .Deletar enviando as informações para o banco
            _usuarioRepository.Deletar(idUsuario);

            //Retorna um status code 204 - No Content 
            return StatusCode(204);
        }
    }
}

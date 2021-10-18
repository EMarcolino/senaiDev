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

    // Controlador responsável pelos endponts (URLs) referentes a Tipo de Usuario 
    public class TipoUsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _classeRepository que irá receber todos os métodos definidos na interface IClasseRepository
        /// </summary>
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }
        public TipoUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos as classes
        /// </summary>
        /// <returns>Uma lista de classes com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoUsuarioRepository.ListarTipoUsuario());
        }

        /// <summary>
        /// Busca uma classe por seu id
        /// </summary>
        /// <param name="idClasse">id que será buscado</param>
        /// <returns>Uma classe buscada</returns>
        [HttpGet("{idTipoUsuario}")]
        public IActionResult BuscarClasse(int idTipoUsuario)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(idTipoUsuario));
        }

        /// <summary>
        /// Cadastra uma nova classe de personagem
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novaClasse que possui as informações que serão cadastrada</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario novoTipoUsuario)
        {
            //Faz a chamada para o método .Cadastrar enviando as informações de cadastro para o banco 
            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);

            //Retorna um Status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza as informações de uma classe de personagem 
        /// </summary>
        /// <param name="idTipoUsuario">Id da classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto com as novas informações que serão atualizadas</param>
        /// <returns></returns>
        [HttpPut("{idTipoUsuario}")]
        public IActionResult Atualizar(int idTipoUsuario, TipoUsuario classeAtualizada)
        {
            //Faz a chamada para o método .Atualizar enviando as novas informações para o banco
            _tipoUsuarioRepository.Atualizar(idTipoUsuario, classeAtualizada);

            //Retorna um status code 204 - No Content
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta uma classe de personagem existente
        /// </summary>
        /// <param name="idTipoUsuario">Id da classe que será cadastrada</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(int idTipoUsuario)
        {
            //Faz a chamada para o método .Deletar enviando as informações para o banco
            _tipoUsuarioRepository.Deletar(idTipoUsuario);

            //Retorna um status code 204 - No Content 
            return StatusCode(204);
        }
    }
}

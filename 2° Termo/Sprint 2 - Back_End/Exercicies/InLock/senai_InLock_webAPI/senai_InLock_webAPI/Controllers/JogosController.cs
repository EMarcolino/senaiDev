using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_InLock_webAPI.Domains;
using senai_InLock_webAPI.Interfaces;
using senai_InLock_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Usuarios
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    // Define que apenas usuários autenticados podem acessar aos métodos
    [Authorize]

    // Controller responsável pelos endpoints (URLs) referentes aos jogos
    public class JogosController : ControllerBase
    {
        /// <summary>
        /// Objeto _jogoRepository que irá receber todos os métodos definidos na interface IJogoRepository
        /// </summary>
        private IJogoRepository _jogoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _usuarioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_jogoRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo com as informações</param>
        /// <returns>Retorna um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um jogo através de seu id
        /// </summary>
        /// <param name="idJogo"></param>
        /// <param name="jogoDomain"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idJogo}")]
        public IActionResult Put(int idJogo, JogoDomain jogoDomain)
        {
            try
            {
                _jogoRepository.AtualizarUrl(idJogo, jogoDomain);
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
        /// <param name="idJogo"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idJogo}")]
        public IActionResult Delete(int idJogo)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(idJogo);

            if (jogoBuscado != null)
            {
                try
                {
                    _jogoRepository.Deletar(idJogo);
                    return StatusCode(204);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound("Nenhum jogo foi encontrado!");

        }
    }
}

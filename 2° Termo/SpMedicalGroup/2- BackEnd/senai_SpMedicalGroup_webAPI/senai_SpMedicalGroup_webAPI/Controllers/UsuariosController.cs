using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_SpMedicalGroup_webAPI.Domains;
using senai_SpMedicalGroup_webAPI.Interfaces;
using senai_SpMedicalGroup_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedicalGroup_webAPI.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints (URLs) referentes aos Usuários
    /// </summary>
    /// 
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Usuarios
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    //[Authorize(Roles = "1")]
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
        /// Lista todos os Usuários
        /// </summary>
        /// <returns>Uma lista Usuários e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método .ListarUsuarios
                // Retorna um status code 200 - Ok
                return Ok(_usuarioRepository.ListarUsuarios());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um Usuário através do seu Id
        /// </summary>
        /// <param name="idUsuario">Id do Usuário que será buscado</param>
        /// <returns>Um Usuário buscado e um status code 200 - Ok</returns>
        [HttpGet("{idUsuario}")]
        public IActionResult GetById(int idUsuario)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método .BuscarUsuarioPorId
                // Retorna um status code 200 - Ok
                return Ok(_usuarioRepository.BuscarUsuarioPorId(idUsuario));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo Usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
                // Faz a chamada para o método .CadastrarUsuario, enviando as informações para o banco de dados 
                _usuarioRepository.CadastrarUsuario(novoUsuario);

                // Retorna um status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um Usuário existente
        /// </summary>
        /// <param name="idUsuario">Id do Usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{idUsuario}")]
        public IActionResult Put(int idUsuario, Usuario usuarioAtualizado)
        {
            try
            {
                // Faz a chamada para o método .AtualizarUsuario, enviando as informações para o banco de dados
                _usuarioRepository.AtualizarUsuario(idUsuario, usuarioAtualizado);

                // Retorna um status code 204 - No Content
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um Usuário existente
        /// </summary>
        /// <param name="idUsuario">Id do Usuário que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{idUsuario}")]
        public IActionResult Delete(int idUsuario)
        {
            try
            {
                // Faz a chamada para o método .DeletarUsuario, enviando as informações para o banco de dados
                _usuarioRepository.DeletarUsuario(idUsuario);

                // Retorna um status code 204 - No Content
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

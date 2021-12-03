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
    /// Controller responsável pelos endpoints (URLs) referentes aos Tipos de Usuários
    /// </summary>
    /// 
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/TipoUsuarios
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    //[Authorize(Roles = "1")]
    public class TipoUsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto _tipoUsuarioRepository que irá receber todos os métodos definidos na interface ITipoUsuarioRepository
        /// </summary>
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _tipoUsuarioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public TipoUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os Tipos de Usuários
        /// </summary>
        /// <returns>Uma lista de Tipos de Usuários e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método .ListarTipoUsuarios
                return Ok(_tipoUsuarioRepository.ListarTipoUsuarios());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um Tipo de Usuário através do seu Id
        /// </summary>
        /// <param name="idTipoUsuario">Id do Tipo de Usuário que será buscado</param>
        /// <returns>Um Tipo de Usuário buscado e um status code 200 - Ok</returns>
        [HttpGet("{idUsuario}")]
        public IActionResult GetById(int idTipoUsuario)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método .BuscarTipoUsuarioPorId
                // Retorna um status code 200 - Ok
                return Ok(_tipoUsuarioRepository.BuscarTipoUsuarioPorId(idTipoUsuario));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
        
        /// <summary>
        /// Cadastra um novo Tipo de Usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoUsuario que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUsuario)
        {
            try
            {
                // Faz a chamada para o método .CadastrarTipoUsuario, enviando as informações para o banco de dados 
                _tipoUsuarioRepository.CadastrarTipoUsuario(novoTipoUsuario);

                // Retorna um status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um Tipo de Usuário existente
        /// </summary>
        /// <param name="idTipoUsuario">Id do Tipo de Usuário que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{idUsuario}")]
        public IActionResult Put(int idTipoUsuario, TipoUsuario tipoUsuarioAtualizado)
        {
            try
            {
                // Faz a chamada para o método .AtualizarTipoUsuario, enviando as informações para o banco de dados
                _tipoUsuarioRepository.AtualizarTipoUsuario(idTipoUsuario, tipoUsuarioAtualizado);

                // Retorna um status code 204 - No Content
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um Tipo de Usuário existente
        /// </summary>
        /// <param name="idTipoUsuario">Id do Tipo de Usuário que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{idUsuario}")]
        public IActionResult Delete(int idTipoUsuario)
        {
            try
            {
                // Faz a chamada para o método .DeletarTipoUsuario, enviando as informações para o banco de dados
                _tipoUsuarioRepository.DeletarTipoUsuario(idTipoUsuario);

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

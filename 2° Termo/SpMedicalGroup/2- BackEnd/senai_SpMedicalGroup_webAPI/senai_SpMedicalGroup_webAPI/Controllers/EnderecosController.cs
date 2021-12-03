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
    /// Controller responsável pelos endpoints (URLs) referentes aos Endereços
    /// </summary>
    /// 
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Enderecos
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    //[Authorize(Roles = "1")]
    public class EnderecosController : ControllerBase
    {
        /// <summary>
        /// Objeto _enderecoRepository que irá receber todos os métodos definidos na interface IEnderecoRepository
        /// </summary>
        private IEnderecoRepository _enderecoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _enderecoRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public EnderecosController()
        {
            _enderecoRepository = new EnderecoRepository();
        }

        /// <summary>
        /// Lista todos os Endereços
        /// </summary>
        /// <returns>Uma lista Endereços e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método .ListarEnderecos
                // Retorna um status code 200 - Ok
                return Ok(_enderecoRepository.ListarEnderecos());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um Endereço através do seu Id
        /// </summary>
        /// <param name="idEndereco">Id do Endereço que será buscado</param>
        /// <returns>Um Endereço buscado e um status code 200 - Ok</returns>
        [HttpGet("{idUsuario}")]
        public IActionResult GetById(int idEndereco)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método .BuscarEnderecoPorId
                // Retorna um status code 200 - Ok
                return Ok(_enderecoRepository.BuscarEnderecoPorId(idEndereco));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo Endereço
        /// </summary>
        /// <param name="novoEndereco">Objeto novoEndereco que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Endereco novoEndereco)
        {
            try
            {
                // Faz a chamada para o método .CadastrarEndereco, enviando as informações para o banco de dados 
                _enderecoRepository.CadastrarEndereco(novoEndereco);

                // Retorna um status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um Endereço existente
        /// </summary>
        /// <param name="idEndereco">Id do Endereço que será atualizado</param>
        /// <param name="enderecoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{idUsuario}")]
        public IActionResult Put(int idEndereco, Endereco enderecoAtualizado)
        {
            try
            {
                // Faz a chamada para o método .AtualizarEndereco, enviando as informações para o banco de dados
                _enderecoRepository.AtualizarEndereco(idEndereco, enderecoAtualizado);

                // Retorna um status code 204 - No Content
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um Endereço existente
        /// </summary>
        /// <param name="idEndereco">Id do Endereço que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{idUsuario}")]
        public IActionResult Delete(int idEndereco)
        {
            try
            {
                // Faz a chamada para o método .DeletarEndereco, enviando as informações para o banco de dados
                _enderecoRepository.DeletarEndereco(idEndereco);

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

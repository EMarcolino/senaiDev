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
    /// Controller responsável pelos endpoints (URLs) referentes as Situacões
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Situacaos
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    //[Authorize(Roles = "1")]
    public class SituacaosController : ControllerBase
    {
        /// <summary>
        /// Objeto _situacaoRepository que irá receber todos os métodos definidos na interface ISituacaoRepository
        /// </summary>
        private ISituacaoRepository _situacaoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _situacaoRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public SituacaosController()
        {
            _situacaoRepository = new SituacaoRepository();
        }

        /// <summary>
        /// Lista todas as Situacões
        /// </summary>
        /// <returns>Uma lista de Situacões e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método .ListarSituacoes
                // Retorna um status code 200 - Ok
                return Ok(_situacaoRepository.ListarSituacoes());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca uma Situação através do seu Id
        /// </summary>
        /// <param name="idSituacao">Id da Situação que será buscada</param>
        /// <returns>Uma Situação buscada e um status code 200 - Ok</returns>
        [HttpGet("{idSituacao}")]
        public IActionResult GetById(int idSituacao)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método .BuscarSituacaoPorId
                // Retorna um status code 200 - Ok
                return Ok(_situacaoRepository.BuscarSituacaoPorId(idSituacao));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra uma nova Situação
        /// </summary>
        /// <param name="novaSituacao">Objeto novaSituacao que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Situacao novaSituacao)
        {
            try
            {
                // Faz a chamada para o método .CadastrarSituacao, enviando as informações para o banco de dados 
                _situacaoRepository.CadastrarSituacao(novaSituacao);

                // Retorna um status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza uma Situação existente
        /// </summary>
        /// <param name="idSituacao">Id da Situação que será atualizada</param>
        /// <param name="situacaoAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{idSituacao}")]
        public IActionResult Put(int idSituacao, Situacao situacaoAtualizada)
        {
            try
            {
                // Faz a chamada para o método .AtualizarSituacao, enviando as informações para o banco de dados
                _situacaoRepository.AtualizarSituacao(idSituacao, situacaoAtualizada);

                // Retorna um status code 204 - No Content
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma Situacao existente
        /// </summary>
        /// <param name="idSituacao">Id da Situacao que será deletada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{idSituacao}")]
        public IActionResult Delete(int idSituacao)
        {
            try
            {
                // Faz a chamada para o método .DeletarSituacao, enviando as informações para o banco de dados
                _situacaoRepository.DeletarSituacao(idSituacao);

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

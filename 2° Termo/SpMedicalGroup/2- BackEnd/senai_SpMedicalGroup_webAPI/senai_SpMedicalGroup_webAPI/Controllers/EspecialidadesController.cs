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
    /// Controller responsável pelos endpoints (URLs) referentes aos Especialidades
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Especialidades
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    //[Authorize(Roles = "1")]
    public class EspecialidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _especialidadeRepository que irá receber todos os métodos definidos na interface IEspecialidadeRepository
        /// </summary>
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _especialidadeRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public EspecialidadesController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Lista todas as Especialidade
        /// </summary>
        /// <returns>Uma lista de Especialidade e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método .ListarEspecialidades
                // Retorna um status code 200 - Ok
                return Ok(_especialidadeRepository.ListarEspecialidades());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca uma Especialidade através do seu Id
        /// </summary>
        /// <param name="idEspecialidade">Id da Especialidade que será buscada</param>
        /// <returns>Uma Especialidade buscada e um status code 200 - Ok</returns>
        [HttpGet("{idEspecialidade}")]
        public IActionResult GetById(int idEspecialidade)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método .BuscarEspecialidadePorId
                // Retorna um status code 200 - Ok
                return Ok(_especialidadeRepository.BuscarEspecialidadePorId(idEspecialidade));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra uma nova Especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Objeto novaEspecialidade que será cadastrada</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Especialidade novaEspecialidade)
        {
            try
            {
                // Faz a chamada para o método .CadastrarEspecialidade, enviando as informações para o banco de dados 
                _especialidadeRepository.CadastrarEspecialidade(novaEspecialidade);

                // Retorna um status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza uma Especialidade existente
        /// </summary>
        /// <param name="idEspecialidade">Id da Especialidade que será atualizada</param>
        /// <param name="especialidadeAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{idEspecialidade}")]
        public IActionResult Put(int idEspecialidade, Especialidade especialidadeAtualizada)
        {
            try
            {
                // Faz a chamada para o método .AtualizarEspecialidade, enviando as informações para o banco de dados
                _especialidadeRepository.AtualizarEspecialidade(idEspecialidade, especialidadeAtualizada);

                // Retorna um status code 204 - No Content
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma Especialidade existente
        /// </summary>
        /// <param name="idEspecialidade">Id da Especialidade que será deletada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{idEspecialidade}")]
        public IActionResult Delete(int idEspecialidade)
        {
            try
            {
                // Faz a chamada para o método .DeletarEspecialidade, enviando as informações para o banco de dados
                _especialidadeRepository.DeletarEspecialidade(idEspecialidade);

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

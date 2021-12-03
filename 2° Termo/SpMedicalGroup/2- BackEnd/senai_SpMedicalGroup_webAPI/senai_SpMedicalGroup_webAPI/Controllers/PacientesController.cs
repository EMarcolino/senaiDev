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
    /// Controller responsável pelos endpoints (URLs) referentes aos Pacientes
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Pacientes
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    //[Authorize(Roles = "1")]
    public class PacientesController : ControllerBase
    {
        /// <summary>
        /// Objeto _pacienteRepository que irá receber todos os métodos definidos na interface IPacienteRepository
        /// </summary>
        private IPacienteRepository _pacienteRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _pacienteRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public PacientesController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Lista todas os Pacientes
        /// </summary>
        /// <returns>Uma lista de Pacientes e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método .ListarPacientes
                // Retorna um status code 200 - Ok
                return Ok(_pacienteRepository.ListarPacientes());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um Paciente através do seu Id
        /// </summary>
        /// <param name="idPaciente">Id do Paciente que será buscado</param>
        /// <returns>Um Paciente buscado e um status code 200 - Ok</returns>
        [HttpGet("{idPaciente}")]
        public IActionResult GetById(int idPaciente)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método .BuscarPacientePorId
                // Retorna um status code 200 - Ok
                return Ok(_pacienteRepository.BuscarPacientePorId(idPaciente));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo Paciente
        /// </summary>
        /// <param name="novoPaciente">Objeto novoPaciente que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Paciente novoPaciente)
        {
            try
            {
                // Faz a chamada para o método .CadastrarPaciente, enviando as informações para o banco de dados 
                _pacienteRepository.CadastrarPaciente(novoPaciente);

                // Retorna um status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um Paciente existente
        /// </summary>
        /// <param name="idPaciente">Id do Paciente que será atualizado</param>
        /// <param name="pacienteAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{idPaciente}")]
        public IActionResult Put(int idPaciente, Paciente pacienteAtualizado)
        {
            try
            {
                // Faz a chamada para o método .AtualizarPaciente, enviando as informações para o banco de dados
                _pacienteRepository.AtualizarPaciente(idPaciente, pacienteAtualizado);

                // Retorna um status code 204 - No Content
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um Paciente existente
        /// </summary>
        /// <param name="idPaciente">Id do Paciente que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{idPaciente}")]
        public IActionResult Delete(int idPaciente)
        {
            try
            {
                // Faz a chamada para o método .DeletarPaciente, enviando as informações para o banco de dados
                _pacienteRepository.DeletarPaciente(idPaciente);

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

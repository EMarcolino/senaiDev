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
    /// Controller responsável pelos endpoints (URLs) referentes aos Médicos
    /// </summary>
     
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Medicos
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    //[Authorize(Roles = "1")]
    public class MedicosController : ControllerBase
    {
        /// <summary>
        /// Objeto _medicoRepository que irá receber todos os métodos definidos na interface IMedicoRepository
        /// </summary>
        private IMedicoRepository _medicoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _medicoRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Lista todos(as) os Médicos(as)
        /// </summary>
        /// <returns>Uma lista de Médicos(as) e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método .ListarMedicos
                // Retorna um status code 200 - Ok
                return Ok(_medicoRepository.ListarMedicos());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um Médico(a) através do seu Id
        /// </summary>
        /// <param name="idMedico">Id do(a) Médico(a) que será buscado(a)</param>
        /// <returns>Um Médico(a) buscado e um status code 200 - Ok</returns>
        [HttpGet("{idMedico}")]
        public IActionResult GetById(int idMedico)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método .BuscarMedicoPorId
                // Retorna um status code 200 - Ok
                return Ok(_medicoRepository.BuscarMedicoPorId(idMedico));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo Médico
        /// </summary>
        /// <param name="novoMedico">Objeto novoMedico que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Medico novoMedico)
        {
            try
            {
                // Faz a chamada para o método .CadastrarMedico, enviando as informações para o banco de dados 
                _medicoRepository.CadastrarMedico(novoMedico);

                // Retorna um status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um(a) Médico(a) existente
        /// </summary>
        /// <param name="idMedico">Id do(a) Médico(a) que será atualizado(a)</param>
        /// <param name="medicoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{idMedico}")]
        public IActionResult Put(int idMedico, Medico medicoAtualizado)
        {
            try
            {
                // Faz a chamada para o método .AtualizarMedico, enviando as informações para o banco de dados
                _medicoRepository.AtualizarMedico(idMedico, medicoAtualizado);

                // Retorna um status code 204 - No Content
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um(a) Médico(a) existente
        /// </summary>
        /// <param name="idMedico">Id do(a) Médico(a) que será deletado(a)</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{idMedico}")]
        public IActionResult Delete(int idMedico)
        {
            try
            {
                // Faz a chamada para o método .DeletarMedico, enviando as informações para o banco de dados
                _medicoRepository.DeletarMedico(idMedico);

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

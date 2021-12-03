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
    /// Controller responsável pelos endpoints (URLs) referentes aos Clínicas
    /// </summary>
     
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Clinicas
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    //[Authorize(Roles = "1")]
    public class ClinicasController : ControllerBase
    {
        /// <summary>
        /// Objeto _clinicaRepository que irá receber todos os métodos definidos na interface IClinicaRepository
        /// </summary>
        private IClinicaRepository _clinicaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _clinicaRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Lista todas as Clínicas
        /// </summary>
        /// <returns>Uma lista de Clínicas e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método .ListarClinicas
                // Retorna um status code 200 - Ok
                return Ok(_clinicaRepository.ListarClinicas());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca uma Clínica através do seu Id
        /// </summary>
        /// <param name="idClinica">Id da Clínica que será buscada</param>
        /// <returns>Um Clínica buscado e um status code 200 - Ok</returns>
        [HttpGet("{idClinica}")]
        public IActionResult GetById(int idClinica)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método .BuscarClinicaPorId
                // Retorna um status code 200 - Ok
                return Ok(_clinicaRepository.BuscarClinicaPorId(idClinica));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra uma nova Clínica
        /// </summary>
        /// <param name="novaClinica">Objeto novaClinica que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            try
            {
                // Faz a chamada para o método .CadastrarClinica, enviando as informações para o banco de dados 
                _clinicaRepository.CadastrarClinica(novaClinica);

                // Retorna um status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza uma Clínica existente
        /// </summary>
        /// <param name="idClinica">Id da Clínica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{idClinica}")]
        public IActionResult Put(int idClinica, Clinica clinicaAtualizada)
        {
            try
            {
                // Faz a chamada para o método .AtualizarClinica, enviando as informações para o banco de dados
                _clinicaRepository.AtualizarClinica(idClinica, clinicaAtualizada);

                // Retorna um status code 204 - No Content
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma Clínica existente
        /// </summary>
        /// <param name="idClinica">Id da Clínica que será deletada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{idClinica}")]
        public IActionResult Delete(int idClinica)
        {
            try
            {
                // Faz a chamada para o método .DeletarClinica, enviando as informações para o banco de dados
                _clinicaRepository.DeletarClinica(idClinica);

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

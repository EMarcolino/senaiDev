using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_SpMedicalGroup_webAPI.Domains;
using senai_SpMedicalGroup_webAPI.Interfaces;
using senai_SpMedicalGroup_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedicalGroup_webAPI.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints (URLs) referentes aos Consultas
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Consultas
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    // Define que somente o administrador pode acessar os métodos
    //[Authorize(Roles = "1")]
    public class ConsultasController : ControllerBase
    {
        /// <summary>
        /// Objeto _consultaRepository que irá receber todos os métodos definidos na interface IConsultumRepository
        /// </summary>
        private IConsultumRepository _consultaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _consultaRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public ConsultasController()
        {
            _consultaRepository = new ConsultumRepository();
        }

        /*[Authorize(Roles = "2")]
        [HttpGet("consultasMedico")]
        public IActionResult ListarConsltasMedico()
        {
            try
            {
                //
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                //int idUsuario = 8;
                //             
                return Ok(_consultaRepository.ListarConsultasMedico(idUsuario));                
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    error
                });
            }
        }

        [Authorize(Roles = "2")]
        [HttpGet("consultasPaciente")]
        public  IActionResult ListarConsltasPaciente()
        {
            try
            {
                //
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                //int idUsuario = 3;
                //
                return Ok(_consultaRepository.ListarConsultasPaciente(idUsuario));                                                                     
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    error
                });                    
            }                
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2,3")]
        [HttpGet("minhasConsultas")]
        public IActionResult ListarMinhasConsltas()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                if (_consultaRepository.ListarConsultasPaciente(idUsuario) != null)
                {
                    return Ok(_consultaRepository.ListarConsultasPaciente(idUsuario));
                }

                return Ok(_consultaRepository.ListarConsultasMedico(idUsuario));

            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    error
                });
            }
        }

        /// <summary>
        /// Lista todas as Consultas
        /// </summary>
        /// <returns>Uma lista de Consultas e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método .ListarConsultas
                // Retorna um status code 200 - Ok
                return Ok(_consultaRepository.ListarConsultas());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca uma Consulta através do seu Id
        /// </summary>
        /// <param name="idConsulta">Id da Consulta que será buscada</param>
        /// <returns>Uma Consulta buscada e um status code 200 - Ok</returns>
        [HttpGet("{idConsulta}")]
        public IActionResult GetById(int idConsulta)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método .BuscarConsultaPorId
                // Retorna um status code 200 - Ok
                return Ok(_consultaRepository.BuscarConsultaPorId(idConsulta));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra uma nova Consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto novaConsulta que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Consultum novaConsulta)
        {
            try
            {
                // Faz a chamada para o método .CadastrarConsulta, enviando as informações para o banco de dados 
                _consultaRepository.CadastrarConsulta(novaConsulta);

                // Retorna um status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza uma Consulta existente
        /// </summary>
        /// <param name="idConsulta">Id da Consulta que será atualizada</param>
        /// <param name="ConsultaAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{idConsulta}")]
        public IActionResult Put(int idConsulta, Consultum ConsultaAtualizada)
        {
            try
            {
                // Faz a chamada para o método .AtualizarConsulta, enviando as informações para o banco de dados
                _consultaRepository.AtualizarConsulta(idConsulta, ConsultaAtualizada);

                // Retorna um status code 204 - No Content
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma Consulta existente
        /// </summary>
        /// <param name="idConsulta">Id da Consulta que será deletada</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{idConsulta}")]
        public IActionResult Delete(int idConsulta)
        {
            try
            {
                // Faz a chamada para o método .DeletarConsulta, enviando as informações para o banco de dados
                _consultaRepository.DeletarConsulta(idConsulta);

                // Retorna um status code 204 - No Content
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Método responsável por responder o status das consultas Agendada, Cancelada, Aguardando
        /// </summary>
        /// <param name="idConsulta"></param>
        /// <param name="statusConsulta"></param>
        /// <returns></returns>
        [HttpPatch("{idConsulta}")]
        public IActionResult AprovarRecusar(int idConsulta, Consultum statusConsulta)
        {
            try
            {
                _consultaRepository.AprovarRecusar(idConsulta, Convert.ToInt32(statusConsulta));
                //
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_locadoraRental_webAPI.Domains;
using senai_locadoraRental_webAPI.Interfaces;
using senai_locadoraRental_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controlador responsável pelo endpoint (URL's)  referente aos alugueis
/// </summary>
namespace senai_locadoraRental_webAPI.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota/endpoint de uma requisição será no formato dominio/api/nomeController. Ex: http://localhost:5000/api/Alugueis
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    public class AlugueisController : ControllerBase
    {

        /// <summary>
        /// Objeto que irá receber todos os objetos definidos na interface
        /// </summary>
        private IAluguelRepository _AluguelRepository { get; set; }

        /// <summary>
        /// Instancia um objeto _AlugueisRepository para que haja a referencia dos métodos no repositório  
        /// </summary>
        public AlugueisController()
        {
            _AluguelRepository = new AluguelRepository();
        }


        [HttpGet]
        //IActionResult = Resultado de uma ação
        //Get = nome escolhido para o metodo que retorna aluguel
        public IActionResult Get()
        {
            //Lista de alugueis
            //Se conecta com o repositorio

            //Cria uma lista nomeada de listarAlugueis para receber os dados
            List<AluguelDomain> listarAlugueis = _AluguelRepository.ListarTodos();

            //Retorna Status Code 200(ok), com a lista de alugueis 
            return Ok(listarAlugueis);
        }


        /// <summary>
        /// Busca um aluguel utilizando o seu id como parâmetro
        /// </summary>
        /// <param name="idAluguel">O id que será buscado</param>
        /// <returns>O objeto aluguel que  foi buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int idAluguel)
        {
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarporId(idAluguel);

            if (aluguelBuscado == null)
            {
                return NotFound("Nenhum Cliente enconctrardo!");
            }
            return Ok(aluguelBuscado);
        }


        /// <summary>
        /// Cadastra um novo Aluguel
        /// </summary>
        /// <param name="novoAluguel">Objeto novoAluguel que será recebido na requisição</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        //IActionResult = Resultado de uma ação
        //Post = nome escolhido para o metodo que Cadastra alugueis
        public IActionResult Post(AluguelDomain novoAluguel)
        {
            //Faz a chamada para o método .Cadastrar()
            _AluguelRepository.Cadastrar(novoAluguel);

            //Retorna um Status code 201 - Created
            return StatusCode(201);
        }


        /// <summary>
        /// Atualiza um aluguel pelo id
        /// </summary>
        /// <param name="id">Do aluguel que será atualizado</param>
        /// <param name="aluguelAtualizado">Objeto aluguel que será atualizado</param>
        /// <returns>Um aluguel atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, AluguelDomain aluguelAtualizado)
        {
            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarporId(id);

            if (aluguelBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Aluguel não encontrado",
                        error = true
                    });
            }
            try
            {
                _AluguelRepository.AtualizaIdUrl(id, aluguelAtualizado);

                return NoContent();
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }


        [HttpPut]
        public IActionResult UpdateBody(AluguelDomain aluguelAtualizado)
        {
            if (aluguelAtualizado.idAluguel != null || aluguelAtualizado.idAluguel == 0)
            {
                return BadRequest
                    (
                        new
                        {
                            mansagemErro = "Veiculo não informado"
                        }
                    );
            }

            AluguelDomain aluguelBuscado = _AluguelRepository.BuscarporId(aluguelAtualizado.idAluguel);
            if (aluguelBuscado != null)
            {
                try
                {
                    _AluguelRepository.AtualizaIdCorpo(aluguelAtualizado);

                    return NoContent();
                }
                catch (Exception ex)
                {

                    return BadRequest(ex);
                }
            }
            return NotFound
            (

                new
                {
                    mansagemErro = "Veiculo não encontrado!",
                    codErro = true
                }
           );
        }


    /// <summary>
    /// Deleta um Cliente específico existente 
    /// </summary>
    /// <param name="id">O id do Cliente que será deletado</param>
    /// <returns>Um Status Code 204 - No Content</returns>
    /// ex: http://localhost:5000/api/aluguel/excluir/10
    [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _AluguelRepository.Deletar(id);

            //Retorna um Status Code 204 - No Content
            return StatusCode(204);
        }
    }
}

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
/// Controlador responsável pelo endpoint (URL's)  referente aos veículos
/// </summary>
namespace senai_locadoraRental_webAPI.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota/endpoint de uma requisição será no formato dominio/api/nomeController. Ex: http://localhost:5000/api/veiculos
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]
    
    public class VeiculosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os objetos definidos na interface
        /// </summary>
        private IVeiculoRepository _VeiculoRepository { get; set; }

        /// <summary>
        /// Instancia um objeto _VeiculosRepository para que haja a referencia dos métodos no repositório  
        /// </summary>
        public VeiculosController()
        {
            _VeiculoRepository = new VeiculoRepository(); 
        }

        [HttpGet]
        //IActionResult = Resultado de uma ação
        //Get = nome escolhido para o metodo que retorna veiculo
        public IActionResult Get()
        {
            //Lista de veiculos
            //Se conecta com o repositorio

            //Cria uma lista nomeada de listarVeiculos para receber os dados
            List<VeiculoDomain> listarVeiculos = _VeiculoRepository.ListarTodos();

            //Retorna Status Code 200(ok), com a lista de veiculos 
            return Ok(listarVeiculos);
        }

        /// <summary>
        /// Busca um veículo utilizando o seu id como parâmetro
        /// </summary>
        /// <param name="idVeiculo">O id que será buscado</param>
        /// <returns>O objeto veículo que  foi buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int idVeiculo)
        {
            VeiculoDomain veiculoBuscado = _VeiculoRepository.BuscarPorId(idVeiculo);

            if (veiculoBuscado == null)
            {
                return NotFound("Nenhum Veículo enconctrardo!");
            }
            return Ok(veiculoBuscado);
        }


        /// <summary>
        /// Atualiza um veiculo pelo id
        /// </summary>
        /// <param name="id">Do veículo que será atualizado</param>
        /// <param name="veiculoAtualizado">Objeto veículo que será atualizado</param>
        /// <returns>Um veículo atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, VeiculoDomain veiculoAtualizado)
        {
            VeiculoDomain veiculoBuscado = _VeiculoRepository.BuscarPorId(id);

            if (veiculoBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Veiculo não encontrado",
                        error = true
                    });
            }
            try
            {
                _VeiculoRepository.AtualizarIdUrl(id, veiculoAtualizado);

                return NoContent();
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }


        [HttpPut]
        public IActionResult UpdateBody(VeiculoDomain veiculoAtualizado)
        {
            if (veiculoAtualizado.idVeiculo != null || veiculoAtualizado.idVeiculo == 0)
            {
                return BadRequest
                    (
                        new
                        {
                            mansagemErro = "Veiculo não informado"
                        }
                    );
            }

            VeiculoDomain veiculoBuscado = _VeiculoRepository.BuscarPorId(veiculoAtualizado.idVeiculo);
            if (veiculoBuscado != null)
            {
                try
                {
                    _VeiculoRepository.AtualizarIdCorpo(veiculoAtualizado);

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
        /// Cadastra um novo Cliente
        /// </summary>
        /// <param name="novoCliente">Objeto novoCliente que será recebido na requisição</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        //IActionResult = Resultado de uma ação
        //Post = nome escolhido para o metodo que Cadastra veiculo
        public IActionResult Post(VeiculoDomain novoCliente)
        {
            //Faz a chamada para o método .Cadastrar()
            _VeiculoRepository.Cadastrar(novoCliente);

            //Retorna um Status code 201 - Created
            return StatusCode(201);
        }


        /// <summary>
        /// Deleta um Cliente específico existente 
        /// </summary>
        /// <param name="id">O id do Cliente que será deletado</param>
        /// <returns>Um Status Code 204 - No Content</returns>
        /// ex: http://localhost:5000/api/veiculos/excluir/10
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _VeiculoRepository.Deletar(id);

            //Retorna um Status Code 204 - No Content
            return StatusCode(204);
        }

    }
}

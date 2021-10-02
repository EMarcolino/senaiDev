using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_locadoraRental_webAPI.Domains;
using senai_locadoraRental_webAPI.Interfaces;
using senai_locadoraRental_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_locadoraRental_webAPI.Controllers
{
    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota/endpoint de uma requisição será no formato dominio/api/nomeController. Ex: http://localhost:5000/api/veiculos
    [Route("api/[controller]")]

    //Define que é um controlador de API
    [ApiController]

    public class ClientesController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os objetos definidos na interface
        /// </summary>
        private IClienteRepository _ClienteRepository { get; set; }

        /// <summary>
        /// Instancia um objeto _ClientesRepository para que haja a referencia dos métodos no repositório  
        /// </summary>
        public ClientesController()
        {
            _ClienteRepository = new ClienteRepository();
        }

        [HttpGet]
        //IActionResult = Resultado de uma ação
        //Get = nome escolhido para o metodo que retorna cliente
        public IActionResult Get()
        {
            //Lista de veiculos
            //Se conecta com o repositorio

            //Cria uma lista nomeada de listarClientes para receber os dados
            List<ClienteDomain> listarClientes = _ClienteRepository.ListarTodos();

            //Retorna Status Code 200(ok), com a lista de cliente 
            return Ok(listarClientes);
        }


        /// <summary>
        /// Busca um cliente utilizando o seu id como parâmetro
        /// </summary>
        /// <param name="idCliente">O id que será buscado</param>
        /// <returns>O objeto cliente que  foi buscado</returns>
        [HttpGet("{id}")]        
        public IActionResult GetById(int idCliente)
        {
            ClienteDomain clienteBuscado = _ClienteRepository.BuscarPorId(idCliente);

            if(clienteBuscado == null) 
            {
                return NotFound("Nenhum Cliente enconctrardo!");
            }
            return Ok(clienteBuscado);
        }


        
        /// <summary>
        /// Cadastra um Cliente
        /// </summary>
        /// <param name="novoCliente">Objeto novoCliente que será recebido na requisição</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        //IActionResult = Resultado de uma ação
        //Post = nome escolhido para o metodo que Cadastra cliente
        public IActionResult Post(ClienteDomain novoCliente)
        {
            //Faz a chamada para o método .Cadastrar()
            _ClienteRepository.Cadastrar(novoCliente);

            //Retorna um Status code 201 - Created
            return StatusCode(201);
        }


        /// <summary>
        /// Atualiza um Cliente pela URL
        /// </summary>
        /// <param name="id">Do cliente que será atualizado</param>
        /// <param name="clienteAtualizado">Objeto cliente que será atualizado</param>
        /// <returns>Um cliente atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateById (int id, ClienteDomain clienteAtualizado)
        {
            ClienteDomain clienteBuscado = _ClienteRepository.BuscarPorId(id);

            if (clienteBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Cliente não encontrado",
                        error = true
                    });
            }
            try
            {
                _ClienteRepository.AtualizarIdUrl(id, clienteAtualizado);

                return NoContent();
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clienteAtualizado"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateBody(ClienteDomain clienteAtualizado)
        {
            if (clienteAtualizado.idCliente != null || clienteAtualizado.idCliente == 0)
            {
                return BadRequest
                    (
                        new
                        {
                            mansagemErro = "Veiculo não informado"
                        }
                    );
            }

            ClienteDomain veiculoBuscado = _ClienteRepository.BuscarPorId(clienteAtualizado.idCliente);
            if (veiculoBuscado != null)
            {
                try
                {
                    _ClienteRepository.AtualizarIdCorpo(clienteAtualizado);

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
        /// ex: http://localhost:5000/api/clientes/excluir/10
        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _ClienteRepository.Deletar(id);

            //Retorna um Status Code 204 - No Content
            return StatusCode(204);
        }
    }
}

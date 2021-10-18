using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_Hroads_webAPI.Domains;
using senai_Hroads_webAPI.Interfaces;
using senai_Hroads_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    // Controlador responsável pelos endponts (URLs) referentes a Tipo de Habilidades dos personagens
    public class TipoHabilidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _classeRepository que irá receber todos os métodos definidos na interface ITipoHabilidadeRepository
        /// </summary>
        private ITipoHabilidadeRepository _tipoHabilidadeRepository { get; set; }
        public TipoHabilidadesController()
        {
            _tipoHabilidadeRepository = new TipoHabilidadeRepository();
        }

        /// <summary>
        /// Lista todos os tipos de habilidades
        /// </summary>
        /// <returns>Uma lista de tipos de habilidades com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoHabilidadeRepository.ListarTipoHabilidade());
        }

        /// <summary>
        /// Busca um tipo de habilidade por seu id
        /// </summary>
        /// <param name="idTipoHabilidade">id que será buscado</param>
        /// <returns>Uma classe buscada</returns>
        [HttpGet("{idTipoUsuario}")]
        public IActionResult BuscarTipoHabilidade(int idTipoHabilidade)
        {
            return Ok(_tipoHabilidadeRepository.BuscarPorId(idTipoHabilidade));
        }

        /// <summary>
        /// Cadastra um novo tipo de habilidade 
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto novoTipoHabilidade que possui as informações que serão cadastrada</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            //Faz a chamada para o método .Cadastrar enviando as informações de cadastro para o banco 
            _tipoHabilidadeRepository.Cadastrar(novoTipoHabilidade);

            //Retorna um Status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza as informações de um tipo de habilidade 
        /// </summary>
        /// <param name="idTipoHabilidade">Id do tipo de habilidade que será atualizada</param>
        /// <param name="tipoHabilidadeAtualizada">Objeto com as novas informações que serão atualizadas</param>
        /// <returns></returns>
        [HttpPut("{idTipoUsuario}")]
        public IActionResult Atualizar(int idTipoHabilidade, TipoHabilidade tipoHabilidadeAtualizada)
        {
            //Faz a chamada para o método .Atualizar enviando as novas informações para o banco
            _tipoHabilidadeRepository.Atualizar(idTipoHabilidade, tipoHabilidadeAtualizada);

            //Retorna um status code 204 - No Content
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um tipo de habilidade existente
        /// </summary>
        /// <param name="idTipoHabilidade">Id do tipo de habilidade que será cadastrada</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(int idTipoHabilidade)
        {
            //Faz a chamada para o método .Deletar enviando as informações para o banco
            _tipoHabilidadeRepository.Deletar(idTipoHabilidade);

            //Retorna um status code 204 - No Content 
            return StatusCode(204);
        }
    }
}

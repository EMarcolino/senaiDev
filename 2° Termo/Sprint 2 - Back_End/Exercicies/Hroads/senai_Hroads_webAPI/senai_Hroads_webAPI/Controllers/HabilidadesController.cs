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

    // Controlador responsável pelos endponts (URLs) referentes a Habilidades do personagem
    public class HabilidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _habilidadeRepository que irá receber todos os métodos definidos na interface IHabilidadeRepository
        /// </summary>
        private IHabilidadeRepository _habilidadeRepository { get; set; }
        public HabilidadesController()
        {
            _habilidadeRepository = new HabilidadeRepository();
        }

        /// <summary>
        /// Lista todos as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_habilidadeRepository.ListarHabilidades());
        }

        /// <summary>
        /// Busca uma habilidade por seu id
        /// </summary>
        /// <param name="idHabilidade">id que será buscado</param>
        /// <returns>Uma habilidade buscada</returns>
        [HttpGet("{idHabilidade}")]
        public IActionResult BuscarClasse(int idHabilidade)
        {
            return Ok(_habilidadeRepository.BuscarPorId(idHabilidade));
        }

        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaHabilidade que possui as informações que serão cadastrada</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Habilidade novaHabilidade)
        {
            //Faz a chamada para o método .Cadastrar enviando as informações de cadastro para o banco 
            _habilidadeRepository.Cadastrar(novaHabilidade);

            //Retorna um Status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza as informações de uma habilidade 
        /// </summary>
        /// <param name="idHabilidade">Id da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto com as novas informações que serão atualizadas</param>
        /// <returns></returns>
        [HttpPut("{idHabilidade}")]
        public IActionResult Atualizar(int idHabilidade, Habilidade habilidadeAtualizada)
        {
            //Faz a chamada para o método .Atualizar enviando as novas informações para o banco
            _habilidadeRepository.Atualizar(idHabilidade, habilidadeAtualizada);

            //Retorna um status code 204 - No Content
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta uma habilidade existente
        /// </summary>
        /// <param name="idHabilidade">Id da habilidade que será cadastrada</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(int idHabilidade)
        {
            //Faz a chamada para o método .Deletar enviando as informações para o banco
            _habilidadeRepository.Deletar(idHabilidade);

            //Retorna um status code 204 - No Content 
            return StatusCode(204);
        }
    }
}

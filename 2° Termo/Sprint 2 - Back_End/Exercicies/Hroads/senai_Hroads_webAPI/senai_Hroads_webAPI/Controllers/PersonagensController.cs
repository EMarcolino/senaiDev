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

    // Controlador responsável pelos endponts (URLs) referentes a Personagem
    public class PersonagensController : ControllerBase
    {
        /// <summary>
        /// Objeto _personagemRepository que irá receber todos os métodos definidos na interface IPersonagemRepository
        /// </summary>
        private IPersonagemRepository _personagemRepository { get; set; }
        public PersonagensController()
        {
            _personagemRepository = new PersonagemRepository();
        }

        /// <summary>
        /// Lista todos as personagens
        /// </summary>
        /// <returns>Uma lista de personagens com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_personagemRepository.ListarPersonagens());
        }

        /// <summary>
        /// Busca uma personagem por seu id
        /// </summary>
        /// <param name="idPersonagem">id que será buscado</param>
        /// <returns>Uma personagem buscado</returns>
        [HttpGet("{idPersonagem}")]
        public IActionResult BuscarPersonagem(int idPersonagem)
        {
            return Ok(_personagemRepository.BuscarPorId(idPersonagem));
        }

        /// <summary>
        /// Cadastra um novo ersonagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto novoPersonagem que possui as informações que serão cadastrada</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Personagem novoPersonagem)
        {
            //Faz a chamada para o método .Cadastrar enviando as informações de cadastro para o banco 
            _personagemRepository.Cadastrar(novoPersonagem);

            //Retorna um Status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza as informações de um personagem 
        /// </summary>
        /// <param name="idPersonagem">Id do personagem que será atualizado</param>
        /// <param name="personagemAtualizada">Objeto com as novas informações que serão atualizadas</param>
        /// <returns></returns>
        [HttpPut("{idPersonagem}")]
        public IActionResult Atualizar(int idPersonagem, Personagem personagemAtualizada)
        {
            //Faz a chamada para o método .Atualizar enviando as novas informações para o banco
            _personagemRepository.Atualizar(idPersonagem, personagemAtualizada);

            //Retorna um status code 204 - No Content
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta um personagem existente
        /// </summary>
        /// <param name="idPersonagem">Id da personagem que será cadastrado</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(int idPersonagem)
        {
            //Faz a chamada para o método .Deletar enviando as informações para o banco
            _personagemRepository.Deletar(idPersonagem);

            //Retorna um status code 204 - No Content 
            return StatusCode(204);
        }
    }
}

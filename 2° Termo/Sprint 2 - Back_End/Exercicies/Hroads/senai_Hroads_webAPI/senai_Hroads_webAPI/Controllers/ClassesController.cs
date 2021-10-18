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

    // Controlador responsável pelos endponts (URLs) referentes a classes de personagem
    public class ClassesController : ControllerBase
    {
        /// <summary>
        /// Objeto _classeRepository que irá receber todos os métodos definidos na interface IClasseRepository
        /// </summary>
        private IClasseRepository _classeRepository { get; set; }
        public ClassesController()
        {
            _classeRepository = new ClasseRepository();
        }

        /// <summary>
        /// Lista todos as classes
        /// </summary>
        /// <returns>Uma lista de classes com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_classeRepository.ListarClasses());
        }

        /// <summary>
        /// Busca uma classe por seu id
        /// </summary>
        /// <param name="idClasse">id que será buscado</param>
        /// <returns>Uma classe buscada</returns>
        [HttpGet("{idClasse}")]
        public IActionResult BuscarClasse(int idClasse)
        {
            return Ok(_classeRepository.BuscarPorId(idClasse));
        }

        /// <summary>
        /// Cadastra uma nova classe de personagem
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse que possui as informações que serão cadastrada</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Classe novaClasse) 
        {
            //Faz a chamada para o método .Cadastrar enviando as informações de cadastro para o banco 
            _classeRepository.Cadastrar(novaClasse);

            //Retorna um Status code 201 - Created
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza as informações de uma classe de personagem 
        /// </summary>
        /// <param name="idClasse">Id da classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto com as novas informações que serão atualizadas</param>
        /// <returns></returns>
        [HttpPut("{idClasse}")]
        public IActionResult Atualizar (int idClasse, Classe classeAtualizada)
        {
            //Faz a chamada para o método .Atualizar enviando as novas informações para o banco
            _classeRepository.Atualizar(idClasse, classeAtualizada);

            //Retorna um status code 204 - No Content
            return StatusCode(204);
        }

        /// <summary>
        /// Deleta uma classe de personagem existente
        /// </summary>
        /// <param name="idClasse">Id da classe que será cadastrada</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(int idClasse)
        {
            //Faz a chamada para o método .Deletar enviando as informações para o banco
            _classeRepository.Deletar(idClasse);

            //Retorna um status code 204 - No Content 
            return StatusCode(204);
        }
            

    }
}

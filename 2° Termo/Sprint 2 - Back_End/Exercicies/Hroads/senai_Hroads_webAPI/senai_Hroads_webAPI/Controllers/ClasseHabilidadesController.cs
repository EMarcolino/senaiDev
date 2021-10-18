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
    [Route("api/[controller]")]
    [ApiController]

    // Controlador responsável pelos endponts (URLs) referentes a classes de personagem
    public class ClasseHabilidadesController : ControllerBase
    {
        /// <summary>
        /// Objeto _classeRepository que irá receber todos os métodos definidos na interface IClasseRepository
        /// </summary>
        private IClasseHabilidadeRepository _classeHabilidadeRepository { get; set; }
        public ClasseHabilidadesController()
        {
            _classeHabilidadeRepository = new ClasseHabilidadeRepository();
        }

        /// <summary>
        /// Lista todos as classes
        /// </summary>
        /// <returns>Uma lista de classes com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_classeHabilidadeRepository.ListarTodos());
        }
                
    }
}

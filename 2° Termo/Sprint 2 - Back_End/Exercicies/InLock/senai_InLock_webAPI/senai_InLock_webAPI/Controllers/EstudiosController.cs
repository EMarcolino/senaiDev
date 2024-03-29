﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_InLock_webAPI.Interfaces;
using senai_InLock_webAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Usuarios
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    // Define que apenas usuários autenticados podem acessar aos métodos
    [Authorize]

    // Controller responsável pelos endpoints (URLs) referentes aos estúdios
    public class EstudiosController : ControllerBase
    {
        /// <summary>
        /// Objeto _estudioRepository que irá receber todos os métodos definidos na interface IEstudioRepository
        /// </summary>
        private IEstudioRepository _estudioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _estudioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios com um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_estudioRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        /// <summary>
        /// Lista todos os estúdios
        /// </summary>
        /// <returns>Uma lista de estúdios com um status code 200 - Ok</returns>
        [HttpGet("Estudio_E_Jogos")]
        public IActionResult ListarEstudiosJogos()
        {
            try
            {
                return Ok(_estudioRepository.ListarEstudiosJogos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

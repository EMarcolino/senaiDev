using senai_Hroads_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Interfaces
{
    interface IClasseHabilidadeRepository
    {
        /// <summary>
        /// Lista todas as classes com suas habilidades correspondentes
        /// </summary>
        /// <returns>Uma lista com todas as classes e habilidades correspondentes</returns>
        List<ClasseHabilidade> ListarTodos();



    }
}

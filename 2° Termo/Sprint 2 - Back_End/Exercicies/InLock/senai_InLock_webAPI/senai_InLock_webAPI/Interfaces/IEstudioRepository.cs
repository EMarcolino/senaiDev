using senai_InLock_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI.Interfaces
{
    interface IEstudioRepository
    {
        /// <summary>
        /// Lista todos os estudios
        /// </summary>
        /// <returns></returns>
        List<EstudioDomain> ListarTodos();

        /// <summary>
        /// Lista todos os estúdios com suas respectivas listas de jogos
        /// </summary>
        /// <returns>Uma lista de estúdios com seus jogos</returns>
        List<EstudioDomain> ListarEstudiosJogos();
    }
}

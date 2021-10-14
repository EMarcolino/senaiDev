using senai_Hroads_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Interfaces
{
    interface IHabilidadeRepository
    {

        /// <summary>
        /// Lista todas as hibilidades cadastradas
        /// </summary>
        /// <returns>Uma lista de habilidades</returns>
        List<Habilidade> ListarHabilidades();

        /// <summary>
        /// Busca uma habilidade através de seu id
        /// </summary>
        /// <param name="idHabilidade">Id da habilidade que será buscada</param>
        /// <returns>Uma habilidade</returns>
        Habilidade BuscarPorId(int idHabilidade);

        /// <summary>
        /// Cadastra uma nova habilidade 
        /// </summary>
        /// <param name="novaHabilidade">Objeto novaHabilidade com as novas informações cadastradas</param>
        void Cadastrar(Habilidade novaHabilidade);

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="idHabilidade">id sa habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto habilidadeAtualizada com as novas informações</param>
        void Atualizar(int idHabilidade, Habilidade habilidadeAtualizada);

        /// <summary>
        /// Deleta uma abilidade através de seu Id 
        /// </summary>
        /// <param name="idHabilidade">Id da habilidade que será deletada</param>
        void Deletar(int idHabilidade);

    }
}

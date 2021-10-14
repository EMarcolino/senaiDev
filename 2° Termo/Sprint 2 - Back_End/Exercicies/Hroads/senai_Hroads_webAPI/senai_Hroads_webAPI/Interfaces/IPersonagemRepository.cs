using senai_Hroads_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Interfaces
{
    interface IPersonagemRepository
    {
        /// <summary>
        /// Lista todos do personagens 
        /// </summary>
        /// <returns>Uma lista de personagens</returns>
        List<Personagem> ListarPersonagens();

        /// <summary>
        /// Busca um personagem por seu id
        /// </summary>
        /// <param name="idPersonagem">Id do personagem buscado</param>
        /// <returns>Um personagem buscado</returns>
        Personagem BuscarPorId(int idPersonagem);

        /// <summary>
        /// Cadastra um novo personagem 
        /// </summary>
        /// <param name="novoPersonagem">Objeto novoPersonagem com as novas informações</param>
        void Cadastrar(Personagem novoPersonagem);

        /// <summary>
        /// Atualiza as informações de um perdonagem por seu id
        /// </summary>
        /// <param name="idPersonagem">Id do personagem que será atualizado</param>
        /// <param name="personagemAtualizado">Objeto personagemAtualizado com as novas informações</param>
        void Atualizar(int idPersonagem, Personagem personagemAtualizado);

        /// <summary>
        /// Deleta um personagem
        /// </summary>
        /// <param name="idPersonagem">Id do personagem que será deletado</param>
        void Deletar(int idPersonagem);

    }
}

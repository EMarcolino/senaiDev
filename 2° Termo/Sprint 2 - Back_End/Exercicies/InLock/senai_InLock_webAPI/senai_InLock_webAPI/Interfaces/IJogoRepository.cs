using senai_InLock_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório JopgoRepository
    /// </summary>
    interface IJogoRepository
    {
        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Busca um jogo através do ID
        /// </summary>
        /// <param name="id">ID do jogo que será buscado</param>
        /// <returns>Um jogo buscado</returns>
        JogoDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="id">Id do jogo que será atualizado</param>
        /// <param name="jogoAtualizado">Objeto com as novas informações</param>
        void AtualizarUrl(int id, JogoDomain jogoAtualizado);

        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="id">ID do jogo que será deletado</param>
        void Deletar(int id);
    }
}


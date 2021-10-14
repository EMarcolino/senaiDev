using senai_Hroads_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Tipos de Usuarios
        /// </summary>
        /// <returns>Uma lista com todos os Tipos de Usuarios</returns>
        List<TipoUsuario> ListarTipoHabilidade();

        /// <summary>
        /// Busca um tipo de usuario por seu id
        /// </summary>
        /// <param name="idTipoUsuario">Id do tipo de usuario buscado</param>
        /// <returns>O tipo de usuario buscado</returns>
        TipoUsuario BuscarPorId(int idTipoUsuario);

        /// <summary>
        /// Cadastra um novo tipo de usuario 
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario com as novas informações</param>
        void Cadastrar(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza as informações de um tipo de usuario por seu id
        /// </summary>
        /// <param name="idTipoUsuario">Id do tipo de usuario que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto tipoUsuarioAtualizado com as novas informações</param>
        void Atualizar(int idTipoUsuario, TipoUsuario tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um tipo de usuario
        /// </summary>
        /// <param name="idTipoUsuario">Id do tipo de usuario que será deletado</param>
        void Deletar(int idTipoUsuario);
    }
}

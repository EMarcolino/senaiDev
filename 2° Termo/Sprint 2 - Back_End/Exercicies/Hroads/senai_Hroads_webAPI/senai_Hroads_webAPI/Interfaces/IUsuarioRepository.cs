using senai_Hroads_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Uma lista com todos os Usuarios</returns>
        List<Usuario> ListarTipoHabilidade();

        /// <summary>
        /// Busca um tipo de usuario por seu id
        /// </summary>
        /// <param name="idUsuario">Id do Usuario buscado</param>
        /// <returns>O usuario buscado</returns>
        Usuario BuscarPorId(int idUsuario);

        /// <summary>
        /// Cadastra um novo usuario 
        /// </summary>
        /// <param name="novotipoUsuario">Objeto novoUsuario com as novas informações</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza as informações de um usuario por seu id
        /// </summary>
        /// <param name="idTipoUsuario">Id do usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado com as novas informações</param>
        void Atualizar(int idTipoUsuario, Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="idUsuario">Id de um usuario que será deletado</param>
        void Deletar(int idUsuario);
    }
}

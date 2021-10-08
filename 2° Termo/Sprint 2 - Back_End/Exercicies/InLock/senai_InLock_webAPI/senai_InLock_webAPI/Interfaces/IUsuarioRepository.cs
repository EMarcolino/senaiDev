using senai_InLock_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">e-mail do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto do tipo Usuario que foi buscado</returns>
        UsuarioDomain Login(string email, string senha);

        void Delete(int idUsuario);

        void Cadastrar(UsuarioDomain novoUsuario);

        void AtualizarUrl(int idUsuario, UsuarioDomain usuarioAtualizado);

        UsuarioDomain BuscarId(int idUsuario);

        List<UsuarioDomain> ListarTodos();


    }
}

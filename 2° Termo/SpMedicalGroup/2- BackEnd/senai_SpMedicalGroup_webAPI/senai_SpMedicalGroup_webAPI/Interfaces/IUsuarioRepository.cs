using senai_SpMedicalGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedicalGroup_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável por informar os métodos ao repositório UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo Usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        void CadastrarUsuario(Usuario novoUsuario);

        /// <summary>
        /// Lista todos os Usuários
        /// </summary>
        /// <returns>Uma lista com os Usuários cadastrados</returns>
        List<Usuario> ListarUsuarios();

        /// <summary>
        /// Busca um Usuário específico por seu id
        /// </summary>
        /// <param name="id">Id do Usuários que está sendo buscado</param>
        /// <returns>Um Usuário buscado</returns>
        Usuario BuscarUsuarioPorId(int id);

        /// <summary>
        /// Atualiza um Usuário 
        /// </summary>
        /// <param name="id">Id do Usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado que contém as atualizações</param>
        void AtualizarUsuario(int id, Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um Usuário
        /// </summary>
        /// <param name="id">Id do Usuário que será deletado</param>
        void DeletarUsuario(int id);

        /// <summary>
        /// Valida o ususário 
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Um objeto do tipo Usuario que foi encontrado</returns>
        Usuario Login(string email, string senha);
    }
}

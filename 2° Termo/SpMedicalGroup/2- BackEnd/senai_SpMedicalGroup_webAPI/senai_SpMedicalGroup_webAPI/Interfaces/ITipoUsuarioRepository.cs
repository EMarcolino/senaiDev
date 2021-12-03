using senai_SpMedicalGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedicalGroup_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável por informar os métodos ao repositório TipoUsuarioRepository
    /// </summary>
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado</param>
        void CadastrarTipoUsuario(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Uma lista com os tipos de usuários cadastrados</returns>
        List<TipoUsuario> ListarTipoUsuarios();

        /// <summary>
        /// Busca um tipo de usuário específico por seu id
        /// </summary>
        /// <param name="id">Id do tipo de usuário que está sendo buscado</param>
        /// <returns>Um tipo de usuário buscado</returns>
        TipoUsuario BuscarTipoUsuarioPorId(int id);

        /// <summary>
        /// Atualiza um tipo de usuário 
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto tipoUsuarioAtualizado que contém as atualizações</param>
        void AtualizarTipoUsuario(int id, TipoUsuario tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um tipo de usuário 
        /// </summary>
        /// <param name="id">Id do tipo de usuário que será deletado</param>
        void DeletarTipoUsuario(int id);
    }
}

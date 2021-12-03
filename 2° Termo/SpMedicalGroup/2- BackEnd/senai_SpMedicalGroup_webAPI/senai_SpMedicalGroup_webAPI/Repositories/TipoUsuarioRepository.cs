using senai_SpMedicalGroup_webAPI.Contexts;
using senai_SpMedicalGroup_webAPI.Domains;
using senai_SpMedicalGroup_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedicalGroup_webAPI.Repositories
{
    /// <summary>
    /// Classe responsável por declarar a implementação dos métodos para TipoUsuarioController
    /// </summary>
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Atualiza um Tipo de Usuário existente
        /// </summary>
        /// <param name="id">Id do Tipo de Usuário que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto com as novas informações</param>
        public void AtualizarTipoUsuario(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            //Busca um tipo de usuário através de seu ID
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            //Verifica se o nome/titulo do tipo de usuário foi informado
            if (tipoUsuarioAtualizado.NomeTipoUsuario != null)
            {
                //Atribui os novos valores aos campos existentes
                tipoUsuarioBuscado.NomeTipoUsuario = tipoUsuarioAtualizado.NomeTipoUsuario;
            }

            //Atualiza o tipo de usuário que foi buscado
            ctx.TipoUsuarios.Update(tipoUsuarioBuscado);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Tipo de Usuário por seu id
        /// </summary>
        /// <param name="id">Id do Tipo de Usuário que está sendo buscado</param>
        /// <returns>Um tipo de usuário buscado</returns>
        public TipoUsuario BuscarTipoUsuarioPorId(int id)
        {
            //Retorna o primeiro tipo de usuário encontrado, para o ID informado
            return ctx.TipoUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo Tipo de Usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado</param>
        public void CadastrarTipoUsuario(TipoUsuario novoTipoUsuario)
        {
            //Adiciona ao objeto novoTipoUsuario as informações cadastradas
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Tipo de Usuário existente 
        /// </summary>
        /// <param name="id">Id do Tipo de Usuário que será deletado</param>
        public void DeletarTipoUsuario(int id)
        {
            //Busca um tipo de usuário através de seu id
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            //Remove um tipo de usuário através de seu id
            ctx.TipoUsuarios.Remove(tipoUsuarioBuscado);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Tipos de Usuários
        /// </summary>
        /// <returns>Uma lista de Tipos de Usuários</returns>
        public List<TipoUsuario> ListarTipoUsuarios()
        {
            //Retorna uma lista com todas as informações dos tipos de usuários
            return ctx.TipoUsuarios.ToList();
        }
    }
}

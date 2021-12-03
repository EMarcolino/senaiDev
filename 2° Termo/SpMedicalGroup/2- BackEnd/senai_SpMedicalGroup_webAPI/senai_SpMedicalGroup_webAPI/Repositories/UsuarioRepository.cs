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
    /// Classe responsável por declarar a implementação dos métodos para UsuarioController
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Atualiza um Usuário existente
        /// </summary>
        /// <param name="id">Id do Usuário que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        public void AtualizarUsuario(int id, Usuario usuarioAtualizado)
        {
            //Busca um usuário através de seu ID
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            //Verifica se o nome do usuário foi informado
            if (usuarioAtualizado.NomeUsuario != null)
            {
                //Atribui os novos valores aos campos existentes
                usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
            }

            //Verifica se o email do usuário foi informado
            if (usuarioAtualizado.Email != null)
            {
                //Atribui os novos valores aos campos existentes
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            //Verifica se a senha do usuário foi informada
            if (usuarioAtualizado.Senha != null)
            {
                //Atribui os novos valores aos campos existentes
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            //Atualiza o usuário que foi buscado
            ctx.Usuarios.Update(usuarioBuscado);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Usuário por seu id
        /// </summary>
        /// <param name="id">Id do Usuário que está sendo buscado</param>
        /// <returns>Um usuário buscado</returns>
        public Usuario BuscarUsuarioPorId(int id)
        {
            //Retorna o primeiro usuário encontrado, para o ID informado, sem exibir sua senha
            return ctx.Usuarios.Select(u => new Usuario()
            {
                IdUsuario = u.IdUsuario,
                NomeUsuario = u.NomeUsuario,
                Email = u.Email,
                IdTipoUsuario = u.IdTipoUsuario,

                IdTipoUsuarioNavigation = new TipoUsuario()
                {
                    IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                    NomeTipoUsuario = u.IdTipoUsuarioNavigation.NomeTipoUsuario
                }
            })
                .FirstOrDefault(u => u.IdTipoUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo Usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        public void CadastrarUsuario(Usuario novoUsuario)
        {
            //Adiciona ao objeto novoUsuario as informações cadastradas
            ctx.Usuarios.Add(novoUsuario);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Usuário existente 
        /// </summary>
        /// <param name="id">Id do Usuário que será deletado</param>
        public void DeletarUsuario(int id)
        {
            //Busca um usuário através de seu id
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            //Remove um usuário através de seu id
            ctx.Usuarios.Remove(usuarioBuscado);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Usuários
        /// </summary>
        /// <returns>Uma lista de Usuários</returns>
        public List<Usuario> ListarUsuarios()
        {
            return ctx.Usuarios.Select(u => new Usuario()
            {
                IdUsuario = u.IdUsuario,
                NomeUsuario = u.NomeUsuario,
                Email = u.Email,
                IdTipoUsuario = u.IdUsuario,

                IdTipoUsuarioNavigation = new TipoUsuario()
                {
                    IdTipoUsuario = u.IdTipoUsuarioNavigation.IdTipoUsuario,
                    NomeTipoUsuario = u.IdTipoUsuarioNavigation.NomeTipoUsuario
                }

            })
                .ToList();
        }

        public Usuario Login(string email, string senha)
        {
           //
            return ctx.Usuarios.FirstOrDefault(l => l.Email == email && l.Senha == senha);
            
        }
    }
}

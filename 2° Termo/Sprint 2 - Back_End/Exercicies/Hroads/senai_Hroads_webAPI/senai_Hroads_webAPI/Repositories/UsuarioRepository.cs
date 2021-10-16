using senai_Hroads_webAPI.Contexts;
using senai_Hroads_webAPI.Domains;
using senai_Hroads_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Instancia o objeto contexto que irá referenciar uma tabela, por onde serão chamados os métodos do EntityFramework Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um usuario existente
        /// </summary>
        /// <param name="idUsuario">Id do usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioAtualizado que contém as novas informações</param>
        public void Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            //Busca um tipo de usuario existente no banco de dados através de seu id
            Usuario usuarioBuscado = ctx.Usuarios.Find(idUsuario);

            //Outra forma para realizar a busca
            //Habilidade usuarioBuscado = BuscarPorId(idTipoUsuario);

            //Verifica se um novo nome do tipo de usuario foi informado
            if (usuarioAtualizado.NomeUsuario != null)
            {
                //Se o novo nome tiver sido informado, é realizada a alteração para o novo nome informado
               usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
            }
            //Realiza a alteração/atualização do tipo de usuario que foi buscado
            ctx.Usuarios.Update(usuarioBuscado);

            //Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um usuario por seu id
        /// </summary>
        /// <param name="idUsuario">Id do usuario buscado</param>
        /// <returns>Um usuario buscado</returns>
        public Usuario BuscarPorId(int idUsuario)
        {
            //Retorna o primeiro usuario encontrado comparando o id informado com o banco de dados 
            return ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == idUsuario);
        }

        /// <summary>
        /// Cadastra um usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado no banco de dados</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            //Adiciona um tipo de usuario 
            ctx.Usuarios.Add(novoUsuario);

            //Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuario através de seu id
        /// </summary>
        /// <param name="idUsuario">Id do usuario que será deletado</param>
        public void Deletar(int idUsuario)
        {
            //Busca um usuario através de seu id
            Usuario usuarioBuscado = BuscarPorId(idUsuario);

            //Remove um usuario encontrado
            ctx.Usuarios.Remove(usuarioBuscado);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas os usuario
        /// </summary>
        /// <returns>Uma lista com os usuarios existentes</returns>
        public List<Usuario> ListarTipoHabilidade()
        {
            //Retorna uma lista com todas as informações dos usuarios
            return ctx.Usuarios.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }
    }
}

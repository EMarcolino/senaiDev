using senai_Hroads_webAPI.Contexts;
using senai_Hroads_webAPI.Domains;
using senai_Hroads_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Instancia o objeto contexto que irá referenciar uma tabela, por onde serão chamados os métodos do EntityFramework Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um tipo de usuario existente
        /// </summary>
        /// <param name="idTipoUsuario">Id do tipo de usuario que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto tipoUsuarioAtualizado que contém as novas informações</param>
        public void Atualizar(int idTipoUsuario, TipoUsuario tipoUsuarioAtualizado)
        {
            //Busca um tipo de usuario existente no banco de dados através de seu id
            Habilidade tipoUsuarioBuscado = ctx.Habilidades.Find(idTipoUsuario);

            //Outra forma para realizar a busca
            //Habilidade tipoUsuarioBuscado = BuscarPorId(idTipoUsuario);

            //Verifica se um novo nome do tipo de usuario foi informado
            if (tipoUsuarioAtualizado.NomeTipoUsuario != null)
            {
                //Se o novo nome tiver sido informado, é realizada a alteração para o novo nome informado
                tipoUsuarioBuscado.NomeHabilidade = tipoUsuarioAtualizado.NomeTipoUsuario;
            }
            //Realiza a alteração/atualização do tipo de usuario que foi buscado
            ctx.Habilidades.Update(tipoUsuarioBuscado);

            //Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de usuario por seu id
        /// </summary>
        /// <param name="idTipoUsuario">Id do tipo de usuario buscado</param>
        /// <returns>Um tipo de usuario buscado</returns>
        public TipoUsuario BuscarPorId(int idTipoUsuario)
        {
            //Retorna o primeiro tipo de usuario encontrado comparando o id informado com o banco de dados 
            return ctx.TipoUsuarios.FirstOrDefault(c => c.IdTipoUsuario == idTipoUsuario);
        }

        /// <summary>
        /// Cadastra um tipo de usuario
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTipoUsuario que será cadastrado no banco de dados</param>
        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            //Adiciona um tipo de usuario 
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            //Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de usuario através de seu id
        /// </summary>
        /// <param name="idTipoUsuario">Id do tipo de usuario que será deletado</param>
        public void Deletar(int idTipoUsuario)
        {
            //Busca um tipo de usuario através de seu id
            TipoUsuario tipoUsuarioBuscado = BuscarPorId(idTipoUsuario);

            //Remove um tipo de usuario encontrado
            ctx.TipoUsuarios.Remove(tipoUsuarioBuscado);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas os tipo de usuario
        /// </summary>
        /// <returns>Uma lista com os tipos de usuarios existentes</returns>
        public List<TipoUsuario> ListarTipoHabilidade()
        {
            //Retorna uma lista com todas as informações dos tipos de usuarios
            return ctx.TipoUsuarios.ToList();
        }
    }
}

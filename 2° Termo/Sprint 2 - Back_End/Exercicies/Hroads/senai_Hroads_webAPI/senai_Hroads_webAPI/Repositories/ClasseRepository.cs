using senai_Hroads_webAPI.Contexts;
using senai_Hroads_webAPI.Domains;
using senai_Hroads_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        /// <summary>
        /// Instancia o objeto contexto que irá referenciar uma tabela, por onde serão chamados os métodos do EntityFramework Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza uma classe existente
        /// </summary>
        /// <param name="idClasse">Id da classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto classeAtualizada que contém as novas informações</param>
        public void Atualizar(int idClasse, Classe classeAtualizada)
        {
            //Busca uma classe de personagem existente no banco de dados através de seu id
            Classe classeBuscada = ctx.Classes.Find(idClasse);

            //Outra forma para realizar a busca
            //Classe classeBuscada = BuscarPorId(idClasse);

            //Verifica se um novo nome de classe de personagem foi informado
            if (classeAtualizada.NomeClasse != null)
            {
                //Se o novo nome tiver sido informado, é realizada a alteração para o novo nome informado
                classeBuscada.NomeClasse = classeAtualizada.NomeClasse;
            }
            //Realiza a alteração/atualização da classe de personagem que foi buscada
            ctx.Classes.Update(classeBuscada);

            //Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma classe de personagem por seu id
        /// </summary>
        /// <param name="idClasse">Id da classe buscada</param>
        /// <returns>Uma classe buscada</returns>
        public Classe BuscarPorId(int idClasse)
        {
            //Retorna a primeira classe de personagem encontrada comparando o id informado com o banco de dados 
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == idClasse);
        }

        /// <summary>
        /// Cadastra uma nova classe de personagem
        /// </summary>
        /// <param name="novaClasse">Nova classe cadastrada</param>
        public void Cadastrar(Classe novaClasse)
        {
            //Adiciona uma nova classe de personagem 
            ctx.Classes.Add(novaClasse);
            
            //Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma classe através de seu id
        /// </summary>
        /// <param name="idClasse">id da classe que será deletada</param>
        public void Deletar(int idClasse)
        {
            //Busca a classe de personagem através de seu id
            Classe classeBuscada = BuscarPorId(idClasse);
            
            //Remove a classe encontrada
            ctx.Classes.Remove(classeBuscada);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as classes de personagens
        /// </summary>
        /// <returns>Uma lista com as classes existentes</returns>
        public List<Classe> ListarClasses()
        {
            //Retorna uma lista com todas as informações das classes de personagens
            return ctx.Classes.ToList();
        }
    }
}

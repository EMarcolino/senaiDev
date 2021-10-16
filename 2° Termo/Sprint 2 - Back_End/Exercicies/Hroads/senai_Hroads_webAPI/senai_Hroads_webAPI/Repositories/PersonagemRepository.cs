using senai_Hroads_webAPI.Contexts;
using senai_Hroads_webAPI.Domains;
using senai_Hroads_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Repositories
{
      public class PersonagemRepository : IPersonagemRepository
    {
        /// <summary>
        /// Instancia o objeto contexto que irá referenciar uma tabela, por onde serão chamados os métodos do EntityFramework Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza uma personagem existente
        /// </summary>
        /// <param name="idPersonagem">Id do personagem que será atualizado</param>
        /// <param name="personagemAtualizado">Objeto personagemAtualizado que contém as novas informações</param>
        public void Atualizar(int idPersonagem, Personagem personagemAtualizado)
        {
            //Busca um personagem existente no banco de dados através de seu id
            Habilidade personagemBuscado = ctx.Habilidades.Find(idPersonagem);

            //Outra forma para realizar a busca
            //Habilidade personagemBuscado = BuscarPorId(idPersonagem);

            //Verifica se um novo nome do personagem foi informado
            if (personagemAtualizado.NomePersonagem != null)
            {
                //Se o novo nome tiver sido informado, é realizada a alteração para o novo nome informado
                personagemBuscado.NomeHabilidade = personagemAtualizado.NomePersonagem;
            }
            //Realiza a alteração/atualização do personagem que foi buscada
            ctx.Habilidades.Update(personagemBuscado);

            //Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um personagem por seu id
        /// </summary>
        /// <param name="idPersonagem">Id da personagem buscado</param>
        /// <returns>Um personagem buscado</returns>
        public Personagem BuscarPorId(int idPersonagem)
        {
            //Retorna o primeiro personagem encontrado comparando o id informado com o banco de dados 
            return ctx.Personagems.FirstOrDefault(c => c.IdPersonagem == idPersonagem);
        }

        /// <summary>
        /// Cadastra um personagem
        /// </summary>
        /// <param name="novoPersonagem">Objeto novoPersonagem que será cadastrado no banco de dados</param>
        public void Cadastrar(Personagem novoPersonagem)
        {
            //Adiciona um personagem 
            ctx.Personagems.Add(novoPersonagem);

            //Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um personagem através de seu id
        /// </summary>
        /// <param name="idPersonagem">Id do personagem que será deletado</param>
        public void Deletar(int idPersonagem)
        {
            //Busca um personagem através de seu id
            Personagem personagemBuscado = BuscarPorId(idPersonagem);

            //Remove um personagem encontrado
            ctx.Personagems.Remove(personagemBuscado);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas os personagens
        /// </summary>
        /// <returns>Uma lista com os personagens existentes</returns>
        public List<Personagem> ListarPersonagens()
        {
            //Retorna uma lista com todas as informações dos personagens
            return ctx.Personagems.ToList();
        }
    }
}

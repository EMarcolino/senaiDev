using senai_Hroads_webAPI.Contexts;
using senai_Hroads_webAPI.Domains;
using senai_Hroads_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        /// <summary>
        /// Instancia o objeto contexto que irá referenciar uma tabela, por onde serão chamados os métodos do EntityFramework Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza uma habilidade existente
        /// </summary>
        /// <param name="idHabilidade">Id da habilidade que será atualizada</param>
        /// <param name="habilidadeAtualizada">Objeto habilidadeAtualizada que contém as novas informações</param>
        public void Atualizar(int idHabilidade, Habilidade habilidadeAtualizada)
        {
            //Busca uma habilidade de personagem existente no banco de dados através de seu id
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(idHabilidade);

            //Outra forma para realizar a busca
            //Habilidade habilidadeBuscada = BuscarPorId(idClasse);

            //Verifica se um novo nome de habilidade de personagem foi informado
            if (habilidadeAtualizada.NomeHabilidade != null)
            {
                //Se o novo nome tiver sido informado, é realizada a alteração para o novo nome informado
                habilidadeBuscada.NomeHabilidade = habilidadeAtualizada.NomeHabilidade;
            }
            //Realiza a alteração/atualização da habilidade de personagem que foi buscada
            ctx.Habilidades.Update(habilidadeBuscada);

            //Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma habilidade de personagem por seu id
        /// </summary>
        /// <param name="idHabilidade">Id da habilidade buscada</param>
        /// <returns>Uma habilidade buscada</returns>
        public Habilidade BuscarPorId(int idHabilidade)
        {
            //Retorna a primeira Habilidade de personagem encontrada comparando o id informado com o banco de dados 
            return ctx.Habilidades.FirstOrDefault(c => c.IdHabilidade == idHabilidade);
        }

        /// <summary>
        /// Cadastra uma nova Habilidade de personagem
        /// </summary>
        /// <param name="novaHabilidade">Nova Habilidade cadastrada</param>
        public void Cadastrar(Habilidade novaHabilidade)
        {
            //Adiciona uma nova habilidade de personagem 
            ctx.Habilidades.Add(novaHabilidade);

            //Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma habilidade através de seu id
        /// </summary>
        /// <param name="idHabilidade">Id da habilidade que será deletada</param>
        public void Deletar(int idHabilidade)
        {
            //Busca a habilidade de personagem através de seu id
            Habilidade habilidadeBuscada = BuscarPorId(idHabilidade);

            //Remove a habilidade encontrada
            ctx.Habilidades.Remove(habilidadeBuscada);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as habilidade de personagens
        /// </summary>
        /// <returns>Uma lista com as habilidade existentes</returns>
        public List<Habilidade> ListarHabilidades()
        {
            //Retorna uma lista com todas as informações das habilidades dos personagens
            return ctx.Habilidades.ToList();
        }
    }
}

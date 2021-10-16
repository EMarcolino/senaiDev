using senai_Hroads_webAPI.Contexts;
using senai_Hroads_webAPI.Domains;
using senai_Hroads_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        /// <summary>
        /// Instancia o objeto contexto que irá referenciar uma tabela, por onde serão chamados os métodos do EntityFramework Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        /// <summary>
        /// Atualiza um tipo de habilidade existente
        /// </summary>
        /// <param name="idTipoHabilidade">Id do tipo de habilidade que será atualizado</param>
        /// <param name="tipoHabilidadeAtualizado">Objeto tipoHabilidadeAtualizado que contém as novas informações</param>
        public void Atualizar(int idTipoHabilidade, TipoHabilidade tipoHabilidadeAtualizado)
        {
            //Busca um tipo de habilidade existente no banco de dados através de seu id
            TipoHabilidade tipoHabilidadeBuscado = ctx.TipoHabilidades.Find(idTipoHabilidade);

            //Outra forma para realizar a busca
            //Habilidade tipoHabilidadeBuscado = BuscarPorId(idTipoUsuario);

            //Verifica se um novo nome do tipo de habilidade foi informado
            if (tipoHabilidadeAtualizado.NomeTipoHabilidate != null)
            {
                //Se o novo nome tiver sido informado, é realizada a alteração para o novo nome informado
                tipoHabilidadeBuscado.NomeTipoHabilidate = tipoHabilidadeAtualizado.NomeTipoHabilidate;
            }
            //Realiza a alteração/atualização do tipo de habilidade que foi buscado
            ctx.TipoHabilidades.Update(tipoHabilidadeBuscado);

            //Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de habilidade por seu id
        /// </summary>
        /// <param name="idTipoHabilidade">Id do tipo de habilidade buscado</param>
        /// <returns>Um tipo de habilidade buscada</returns>
        public TipoHabilidade BuscarPorId(int idTipoHabilidade)
        {
            //Retorna o primeiro tipo de habilidade encontrada comparando o id informado com o banco de dados 
            return ctx.TipoHabilidades.FirstOrDefault(c => c.IdTipoHabilidade == idTipoHabilidade);
        }

        /// <summary>
        /// Cadastra um tipo de habilidade
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto novoTipoHabilidade que será cadastrado no banco de dados</param>
        public void Cadastrar(TipoHabilidade novoTipoHabilidade)
        {
            //Adiciona um tipo de habilidade
            ctx.TipoHabilidades.Add(novoTipoHabilidade);

            //Salva as informações que serão gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary> 
        /// Deleta um tipo de habilidade através de seu id
        /// </summary>
        /// <param name="idTipoHabilidade">Id do tipo de habilidade que será deletado</param>
        public void Deletar(int idTipoHabilidade)
        {
            //Busca um tipo de habilidade através de seu id
            TipoHabilidade tipoHabilidadeBuscado = BuscarPorId(idTipoHabilidade);

            //Remove um tipo de habilidade encontrado
            ctx.TipoHabilidades.Remove(tipoHabilidadeBuscado);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas os tipos de habilidades
        /// </summary>
        /// <returns>Uma lista com os tipos de habilidades existentes</returns>
        public List<TipoHabilidade> ListarTipoHabilidade()
        {
            //Retorna uma lista com todas as informações dos tipos de habilidades
            return ctx.TipoHabilidades.ToList();
        }
    }
}

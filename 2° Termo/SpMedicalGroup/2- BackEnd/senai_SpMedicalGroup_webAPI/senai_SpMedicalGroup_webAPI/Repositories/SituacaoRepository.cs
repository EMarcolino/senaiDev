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
    /// Classe responsável por declarar a implementação dos métodos para SituacaoController
    /// </summary>
    public class SituacaoRepository : ISituacaoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Atualiza uma Situação existente
        /// </summary>
        /// <param name="id">Id da situação que será atualizada</param>
        /// <param name="situacaoAtualizada">Objeto com as novas informações</param>
        public void AtualizarSituacao(int id, Situacao situacaoAtualizada)
        {
            //Busca um usuário através de seu ID
            Situacao situacaoBuscada = ctx.Situacaos.Find(id);

            //Verifica se o nome da situação foi informado
            if (situacaoAtualizada.NomeSituacao != null)
            {
                //Atribui os novos valores aos campos existentes
                situacaoBuscada.NomeSituacao = situacaoAtualizada.NomeSituacao;
            }

            //Atualiza a situação que foi buscado
            ctx.Situacaos.Update(situacaoBuscada);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma Situação por seu id
        /// </summary>
        /// <param name="id">Id do Situação que está sendo buscada</param>
        /// <returns>Uma situação buscada</returns>
        public Situacao BuscarSituacaoPorId(int id)
        {
            //Retorna a primeira situação encontrada, para o ID informado
            return ctx.Situacaos.FirstOrDefault(s => s.IdSituacao == id);
        }

        /// <summary>
        /// Cadastra uma nova Situação
        /// </summary>
        /// <param name="novaSituacao">Objeto novaSituacao que será cadastrado</param>
        public void CadastrarSituacao(Situacao novaSituacao)
        {
            //Adiciona ao objeto novaSituacao as informações cadastradas
            ctx.Situacaos.Add(novaSituacao);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma Situação existente
        /// </summary>
        /// <param name="id">Id da Situação que será deletada</param>
        public void DeletarSituacao(int id)
        {
            //Busca uma situação através de seu id
            Situacao situacaoBuscada = ctx.Situacaos.Find(id);

            //Remove uma situação através de seu id
            ctx.Situacaos.Remove(situacaoBuscada);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as Situações
        /// </summary>
        /// <returns>Uma lista de Situações</returns>
        public List<Situacao> ListarSituacoes()
        {
            //Retorna uma lista com todas as situações
            return ctx.Situacaos.ToList();
        }
    }
}

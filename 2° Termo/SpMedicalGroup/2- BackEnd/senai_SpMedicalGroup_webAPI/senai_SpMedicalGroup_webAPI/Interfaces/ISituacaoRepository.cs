using senai_SpMedicalGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedicalGroup_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável por informar os métodos ao repositório SituacaoRepository
    /// </summary>
    interface ISituacaoRepository
    {
        /// <summary>
        /// Cadastra uma nova Situação
        /// </summary>
        /// <param name="novoSituacao">Objeto novoSituacao que será cadastrada</param>
        void CadastrarSituacao(Situacao novoSituacao);

        /// <summary>
        /// Lista todas as Situações
        /// </summary>
        /// <returns>Uma lista com as Situações cadastradas</returns>
        List<Situacao> ListarSituacoes();

        /// <summary>
        /// Busca uma Situação específica por seu id
        /// </summary>
        /// <param name="id">Id da Situação que está sendo buscada</param>
        /// <returns>Um Paciente buscado</returns>
        Situacao BuscarSituacaoPorId(int id);

        /// <summary>
        /// Atualiza uma Situação 
        /// </summary>
        /// <param name="id">Id da Situação que será atualizada</param>
        /// <param name="situacaoAtualizada">Objeto situacaoAtualizada que contém as atualizações</param>
        void AtualizarSituacao(int id, Situacao situacaoAtualizada);

        /// <summary>
        /// Deleta uma Situação
        /// </summary>
        /// <param name="id">Id da Situação que será deletada</param>
        void DeletarSituacao(int id);
    }
}

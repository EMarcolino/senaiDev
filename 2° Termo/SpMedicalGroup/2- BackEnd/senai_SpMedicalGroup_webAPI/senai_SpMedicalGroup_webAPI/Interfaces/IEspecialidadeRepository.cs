using senai_SpMedicalGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedicalGroup_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável por informar os métodos ao repositório EspecialidadeRepository
    /// </summary>
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// Cadastra uma nova Especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Objeto novaEspecialidade que será cadastrado</param>
        void CadastrarEspecialidade(Especialidade novaEspecialidade);

        /// <summary>
        /// Lista todas as Especialidades
        /// </summary>
        /// <returns>Uma lista com as Especialidade cadastradas</returns>
        List<Especialidade> ListarEspecialidades();

        /// <summary>
        /// Busca uma Especialidade específica por seu id
        /// </summary>
        /// <param name="id">Id da Especialidade que está sendo buscada</param>
        /// <returns>Uma Especialidade buscada</returns>
        Especialidade BuscarEspecialidadePorId(int id);

        /// <summary>
        /// Atualiza uma Especialidade 
        /// </summary>
        /// <param name="id">Id da Especialidade que será atualizada</param>
        /// <param name="especialidadeAtualizado">Objeto especialidadeAtualizado que contém as atualizações</param>
        void AtualizarEspecialidade(int id, Especialidade especialidadeAtualizado);

        /// <summary>
        /// Deleta uma Especialidade
        /// </summary>
        /// <param name="id">Id da Especialidade que será deletada</param>
        void DeletarEspecialidade(int id);
    }
}

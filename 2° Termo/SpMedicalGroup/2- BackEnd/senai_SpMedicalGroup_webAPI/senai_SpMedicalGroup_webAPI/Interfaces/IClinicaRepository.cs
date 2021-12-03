using senai_SpMedicalGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedicalGroup_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável por informar os métodos ao repositório ClinicaRepository
    /// </summary>
    interface IClinicaRepository
    {
        /// <summary>
        /// Cadastra uma nova Clínica
        /// </summary>
        /// <param name="novaClinica">Objeto novaClinica que será cadastrado</param>
        void CadastrarClinica(Clinica novaClinica);

        /// <summary>
        /// Lista todas as Clínicas
        /// </summary>
        /// <returns>Uma lista com as Clínicas cadastradas</returns>
        List<Clinica> ListarClinicas();

        /// <summary>
        /// Busca uma Clínica específica por seu id
        /// </summary>
        /// <param name="id">Id da Clinica que está sendo buscada</param>
        /// <returns>Uma Clínica buscada</returns>
        Clinica BuscarClinicaPorId(int id);

        /// <summary>
        /// Atualiza uma Clínica 
        /// </summary>
        /// <param name="id">Id da Clínica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto clinicaAtualizada que contém as atualizações</param>
        void AtualizarClinica(int id, Clinica clinicaAtualizada);

        /// <summary>
        /// Deleta uma Clínica
        /// </summary>
        /// <param name="id">Id da Clínica que será deletada</param>
        void DeletarClinica(int id);

    }
}

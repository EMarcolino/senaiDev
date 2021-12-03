using senai_SpMedicalGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedicalGroup_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável por informar os métodos ao repositório PacienteRepository
    /// </summary>
    interface IPacienteRepository
    {
        /// <summary>
        /// Cadastra um novo Paciente
        /// </summary>
        /// <param name="novoPacienteo">Objeto novoPaciente que será cadastrado</param>
        void CadastrarPaciente(Paciente novoPacienteo);

        /// <summary>
        /// Lista todos os Paciente
        /// </summary>
        /// <returns>Uma lista com os Paciente cadastrados</returns>
        List<Paciente> ListarPacientes();

        /// <summary>
        /// Busca um Paciente específico por seu id
        /// </summary>
        /// <param name="id">Id do Paciente que está sendo buscado</param>
        /// <returns>Um Paciente buscado</returns>
        Paciente BuscarPacientePorId(int id);

        /// <summary>
        /// Atualiza um Paciente 
        /// </summary>
        /// <param name="id">Id do Paciente que será atualizado</param>
        /// <param name="pacienteAtualizado">Objeto pacienteAtualizado que contém as atualizações</param>
        void AtualizarPaciente(int id, Paciente pacienteAtualizado);

        /// <summary>
        /// Deleta um Paciente
        /// </summary>
        /// <param name="id">Id do Paciente que será deletado</param>
        void DeletarPaciente(int id);
    }
}

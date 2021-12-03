using senai_SpMedicalGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedicalGroup_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável por informar os métodos ao repositório ConsultumRepository
    /// </summary>
    interface IConsultumRepository
    {
        /// <summary>
        /// Cadastra/Agenda uma nova Consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto novaConsulta que será cadastrado</param>
        void CadastrarConsulta(Consultum novaConsulta);

        /// <summary>
        /// Lista todos as Consultas
        /// </summary>
        /// <returns>Uma lista com as Consultas cadastradas</returns>
        List<Consultum> ListarConsultas();

        /// <summary>
        /// Lista todas as Consultas de um determinado Medico(a)
        /// </summary>
        /// <param name="idUsuario">Id do(a) Medico(a) que participa das Consultas listadas</param>
        /// <returns>Uma lista com as Consultas com os dados do(a) Medico(a)</returns>
        List<Consultum> ListarConsultasMedico(int idUsuario);

        /// <summary>
        /// Lista todas as Consultas de um determinado Paciente
        /// </summary>
        /// <param name="idUsuario">Id do Paciente que participa das Consultas listadas</param>
        /// <returns>Uma lista com as Consultas com os dados de um Paciente</returns>
        List<Consultum> ListarConsultasPaciente(int idUsuario);

        /// <summary>
        /// Altera o status de uma Consulta
        /// </summary>
        /// <param name="idConsulta">Id da Consulta que terá a situacao alterada</param>
        /// <param name="statusConsulta">Parâmetro que atualiza a situação da Consulta</param>
        void AprovarRecusar(int idConsulta, int statusConsulta);

        /// <summary>
        /// Busca uma Consulta específica por seu id
        /// </summary>
        /// <param name="id">Id do Consulta que está sendo buscada</param>
        /// <returns>Uma Consulta buscada</returns>
        Consultum BuscarConsultaPorId(int id);

        /// <summary>
        /// Atualiza uma Consulta 
        /// </summary>
        /// <param name="id">Id da Consulta que será atualizada</param>
        /// <param name="consultaAtualizada">Objeto consultaAtualizada que contém as atualizações</param>
        void AtualizarConsulta(int id, Consultum consultaAtualizada);

        /// <summary>
        /// Deleta uma Consulta
        /// </summary>
        /// <param name="id">Id do Consulta que será deletada</param>
        void DeletarConsulta(int id);
    }
}

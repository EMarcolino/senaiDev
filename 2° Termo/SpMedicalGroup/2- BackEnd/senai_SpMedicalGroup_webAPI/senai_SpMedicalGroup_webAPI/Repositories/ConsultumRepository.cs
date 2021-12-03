using Microsoft.EntityFrameworkCore;
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
    /// Classe responsável por declarar a implementação dos métodos para ConsultumController
    /// </summary>
    public class ConsultumRepository : IConsultumRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Método responsável por responder o status das consultas Agendada, Cancelada, Aguardando
        /// </summary>
        /// <param name="idConsulta"></param>
        /// <param name="statusConsulta"></param>
        public void AprovarRecusar(int idConsulta, int statusConsulta)
        {
            Consultum consultaBuscada = ctx.Consulta.FirstOrDefault(c => c.IdConsulta == idConsulta);

            switch (statusConsulta)
            {
                case 1:
                    consultaBuscada.IdSituacao = 1;
                    break;
                case 2:
                    consultaBuscada.IdSituacao = 2;
                    break;
                case 3:
                    consultaBuscada.IdSituacao = 3;
                    break;

                default:
                    consultaBuscada.IdSituacao = consultaBuscada.IdSituacao;
                    break;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza uma Consulta existente
        /// </summary>
        /// <param name="id">Id da Consulta que será atualizada</param>
        /// <param name="consultaAtualizada">Objeto com as novas informações</param>
        public void AtualizarConsulta(int id, Consultum consultaAtualizada)
        {
            //Busca uma consulta através de seu ID
            Consultum consultaBuscada = ctx.Consulta.Find(id);

            //Verifica se o Id do médico na consulta foi informado
            if (consultaAtualizada.IdMedico != null)
            {
                //Atribui os novos valores aos campos existentes
                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;
            }

            //Verifica se o Id do paciente na consulta foi informado
            if (consultaAtualizada.IdPaciente != null)
            {
                //Atribui os novos valores aos campos existentes
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
            }

            //Verifica se o Id do situacao na consulta foi informado
            if (consultaAtualizada.IdSituacao != null)
            {
                //Atribui os novos valores aos campos existentes
                consultaBuscada.IdSituacao = consultaAtualizada.IdSituacao;
            }

            //Verifica se a data da consulta na consulta foi informada
            if (consultaAtualizada.DataConsulta != null)
            {
                //Atribui os novos valores aos campos existentes
                consultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;
            }

            //Verifica se a descrição prontuário na consulta foi informada
            if (consultaAtualizada.DescricaoProntuario != null)
            {
                //Atribui os novos valores aos campos existentes
                consultaBuscada.DescricaoProntuario = consultaAtualizada.DescricaoProntuario;
            }

            //Atualiza a consulta que foi buscada
            ctx.Consulta.Update(consultaBuscada);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma Consulta por seu id
        /// </summary>
        /// <param name="id">Id da Consulta que está sendo buscada</param>
        /// <returns>Uma Consulta buscada</returns>
        public Consultum BuscarConsultaPorId(int id)
        {
            //Retorna o primeiro paciente encontrado, para o ID informado
            return ctx.Consulta.FirstOrDefault(c => c.IdConsulta == id);
        }

        /// <summary>
        /// Cadastra uma nova Consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto novaConsulta que será cadastrada</param>
        public void CadastrarConsulta(Consultum novaConsulta)
        {
            //Adiciona ao objeto novaConsulta as informações cadastradas
            ctx.Consulta.Add(novaConsulta);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma Consulta existente
        /// </summary>
        /// <param name="id">Id da Consulta que será deletada</param>
        public void DeletarConsulta(int id)
        {
            //Busca um consulta através de seu id
            Consultum pacienteBuscado = ctx.Consulta.Find(id);

            //Remove um consulta através de seu id
            ctx.Consulta.Remove(pacienteBuscado);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos as Consultas
        /// </summary>
        /// <returns>Uma lista de Consultas</returns>
        public List<Consultum> ListarConsultas()
        {
            //Retorna uma lista com todos os consultas
            return ctx.Consulta.ToList();
        }

        /// <summary>
        ///  Lista as Consultas de um(a) Médico(a)
        /// </summary>
        /// <param name="idUsuario">Id do(a) Médico(a) que está sendo buscado(a)</param>
        /// <returns></returns>
        public List<Consultum> ListarConsultasMedico(int idUsuario)
        {
            // Retorna uma lista com todas as informações das consultas
            return ctx.Consulta
                //
                .Include(c => c.IdSituacaoNavigation)
                .Include(c => c.IdPacienteNavigation.IdUsuarioNavigation)
                //.Include(c => c.IdPacienteNavigation.IdUsuarioNavigation.NomeUsuario)
                //.Include(c => c.IdPacienteNavigation.Cpf)
                //.Include(c => c.IdPacienteNavigation.Rg)
                // Estabelece como parâmetro o id do usuário recebido                
                .Where(c => c.IdMedicoNavigation.IdUsuario == idUsuario)
                .ToList();
        }

        /// <summary>
        ///  Lista as Consultas de um Paciente
        /// </summary>
        /// <param name="idUsuario">Id do Paciente que está sendo buscado</param>
        /// <returns></returns>
        public List<Consultum> ListarConsultasPaciente(int idUsuario)
        {
            // Retorna uma lista com todas as informações das consultas
            return ctx.Consulta
                //
                .Include(c => c.IdSituacaoNavigation)
                .Include(c => c.IdMedicoNavigation.IdUsuarioNavigation)
                .Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation)
                // Estabelece como parâmetro o id do usuário recebido
                .Where(c => c.IdPacienteNavigation.IdUsuario == idUsuario)
                .ToList();
        }

        
    }
}

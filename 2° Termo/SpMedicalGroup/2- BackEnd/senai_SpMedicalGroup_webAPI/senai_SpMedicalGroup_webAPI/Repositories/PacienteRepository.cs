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
    /// Classe responsável por declarar a implementação dos métodos para PacienteController
    /// </summary>
    public class PacienteRepository : IPacienteRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Atualiza um Paciente existente
        /// </summary>
        /// <param name="id">Id da Paciente que será atualizada</param>
        /// <param name="pacienteAtualizado">Objeto com as novas informações</param>
        public void AtualizarPaciente(int id, Paciente pacienteAtualizado)
        {
            //Busca um paciente através de seu ID
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            //Verifica se o cpf do paciente foi informado
            if (pacienteAtualizado.Cpf != null)
            {
                //Atribui os novos valores aos campos existentes
                pacienteBuscado.Cpf = pacienteAtualizado.Cpf;
            }

            //Verifica se o rg do paciente foi informado
            if (pacienteAtualizado.Rg != null)
            {
                //Atribui os novos valores aos campos existentes
                pacienteBuscado.Rg = pacienteAtualizado.Rg;
            }

            //Verifica se o Id do Usuario do paciente foi informado
            if (pacienteAtualizado.IdUsuario != null)
            {
                //Atribui os novos valores aos campos existentes
                pacienteBuscado.IdUsuario = pacienteAtualizado.IdUsuario;
            }

            //Verifica se o Id do Endereco do paciente foi informado
            if (pacienteAtualizado.IdEndereco != null)
            {
                //Atribui os novos valores aos campos existentes
                pacienteBuscado.IdEndereco = pacienteAtualizado.IdEndereco;
            }

            //Atualiza o paciente que foi buscado
            ctx.Pacientes.Update(pacienteBuscado);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Paciente por seu id
        /// </summary>
        /// <param name="id">Id do Paciente que está sendo buscado</param>
        /// <returns>Um Paciente buscado</returns>
        public Paciente BuscarPacientePorId(int id)
        {
            //Retorna o primeiro paciente encontrado, para o ID informado
            return ctx.Pacientes.FirstOrDefault(p => p.IdPaciente == id);
        }

        /// <summary>
        /// Cadastra um novo Paciente
        /// </summary>
        /// <param name="novoPaciente">Objeto novoPaciente que será cadastrado</param>
        public void CadastrarPaciente(Paciente novoPaciente)
        {
            //Adiciona ao objeto novoPaciente as informações cadastradas
            ctx.Pacientes.Add(novoPaciente);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Paciente existente
        /// </summary>
        /// <param name="id">Id do Paciente que será deletado</param>
        public void DeletarPaciente(int id)
        {
            //Busca um paciente através de seu id
            Paciente pacienteBuscado = ctx.Pacientes.Find(id);

            //Remove um paciente através de seu id
            ctx.Pacientes.Remove(pacienteBuscado);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Pacientes
        /// </summary>
        /// <returns>Uma lista de Pacientes</returns>
        public List<Paciente> ListarPacientes()
        {
            //Retorna uma lista com todos os pacientes
            return ctx.Pacientes.ToList();
        }
    }
}

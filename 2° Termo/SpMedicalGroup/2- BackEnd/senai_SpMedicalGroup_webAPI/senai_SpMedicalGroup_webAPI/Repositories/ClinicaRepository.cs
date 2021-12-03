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
    /// Classe responsável por declarar a implementação dos métodos para ClinicaController
    /// </summary>
    public class ClinicaRepository : IClinicaRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Atualiza uma Clínica existente
        /// </summary>
        /// <param name="id">Id da Clínica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto com as novas informações</param>
        public void AtualizarClinica(int id, Clinica clinicaAtualizada)
        {
            //Busca uma clínica através de seu ID
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            //Verifica se o cnpj da clínica foi informado
            if (clinicaAtualizada.IdEndereco != null)
            {
                //Atribui os novos valores aos campos existentes
                clinicaBuscada.IdEndereco = clinicaAtualizada.IdEndereco;
            }

            //Verifica se o cnpj da clínica foi informado
            if (clinicaAtualizada.Cnpj != null)
            {
                //Atribui os novos valores aos campos existentes
                clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
            }

            //Verifica se o cnpj da clínica foi informado
            if (clinicaAtualizada.NomeClinica != null)
            {
                //Atribui os novos valores aos campos existentes
                clinicaBuscada.NomeClinica = clinicaAtualizada.NomeClinica;
            }

            //Atualiza a clínica que foi buscada
            ctx.Clinicas.Update(clinicaBuscada);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma Clínica por seu id
        /// </summary>
        /// <param name="id">Id da Clínica que está sendo buscada</param>
        /// <returns>Uma Clínica buscada</returns>
        public Clinica BuscarClinicaPorId(int id)
        {
            //Retorna a primeira clínica encontrada, para o ID informado
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == id);
        }

        /// <summary>
        /// Cadastra uma nova Clínica
        /// </summary>
        /// <param name="novaClinica">Objeto novaClinica que será cadastrada</param>
        public void CadastrarClinica(Clinica novaClinica)
        {
            //Adiciona ao objeto novaClinica as informações cadastradas
            ctx.Clinicas.Add(novaClinica);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma Clínica existente
        /// </summary>
        /// <param name="id">Id da Clínica que será deletada</param>
        public void DeletarClinica(int id)
        {
            //Busca uma clínica através de seu id
            Clinica clinicaBuscada = ctx.Clinicas.Find(id);

            //Remove uma clínica através de seu id
            ctx.Clinicas.Remove(clinicaBuscada);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos as Clínicaa
        /// </summary>
        /// <returns>Uma lista de Clínicas</returns>
        public List<Clinica> ListarClinicas()
        {
            //Retorna uma lista com todos as clínica
            return ctx.Clinicas.ToList();
        }
    }
}

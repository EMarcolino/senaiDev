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
    /// Classe responsável por declarar a implementação dos métodos para MedicoController
    /// </summary>
    public class MedicoRepository : IMedicoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Atualiza um Médico(a) existente
        /// </summary>
        /// <param name="id">Id do médico(a) que será atualizado(a)</param>
        /// <param name="medicoAtualizado">Objeto com as novas informações</param>
        public void AtualizarMedico(int id, Medico medicoAtualizado)
        {
            //Busca um médico(a) através de seu ID
            Medico medicoBuscado = ctx.Medicos.Find(id);

            //Verifica se o Crm do médico(a) foi informado
            if (medicoAtualizado.Crm != null)
            {
                //Atribui os novos valores aos campos existentes
                medicoBuscado.Crm = medicoAtualizado.Crm;
            }

            //Verifica se o IdUsuario do médico(a) foi informado
            if (medicoAtualizado.IdUsuario != null)
            {
                //Atribui os novos valores aos campos existentes
                medicoBuscado.IdUsuario = medicoAtualizado.IdUsuario;
            }

            //Verifica se o IdEspecialidade do médico(a) foi informado
            if (medicoAtualizado.IdEspecialidade != null)
            {
                //Atribui os novos valores aos campos existentes
                medicoBuscado.IdEspecialidade = medicoAtualizado.IdEspecialidade;
            }

            //Atualiza o médico(a) que foi buscado
            ctx.Medicos.Update(medicoBuscado);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Médico(a) por seu id
        /// </summary>
        /// <param name="id">Id do Médico(a) que está sendo buscado(a)</param>
        /// <returns>Um Médico(a) buscado(a)</returns>
        public Medico BuscarMedicoPorId(int id)
        {
            //Retorna o primeiro médico(a) encontrado(a), para o ID informado
            return ctx.Medicos.FirstOrDefault(m => m.IdMedico == id);
        }

        /// <summary>
        /// Cadastra um novo(a) Médico(a)
        /// </summary>
        /// <param name="novoMedico">Objeto novoMedico que será cadastrado</param>
        public void CadastrarMedico(Medico novoMedico)
        {
            //Adiciona ao objeto novoMedico as informações cadastradas
            ctx.Medicos.Add(novoMedico);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }


        /// <summary>
        /// Deleta um(a) Médico(a) existente
        /// </summary>
        /// <param name="id">Id do Médico(a) que será deletado(a)</param>
        public void DeletarMedico(int id)
        {
            //Busca um(a) médico(a) através de seu id
            Medico medicoBuscado = ctx.Medicos.Find(id);

            //Remove um(a) médico(a) através de seu id
            ctx.Medicos.Remove(medicoBuscado);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Médicos(as)
        /// </summary>
        /// <returns>Uma lista de Médicos(as)</returns>
        public List<Medico> ListarMedicos()
        {
            //Retorna uma lista com todos os médicos(as)
            return ctx.Medicos.ToList();
        }
    }
}

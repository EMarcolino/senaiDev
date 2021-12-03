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
    /// Classe responsável por declarar a implementação dos métodos para EspecialidadeController
    /// </summary>
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Atualiza uma Especialidade existente
        /// </summary>
        /// <param name="id">Id da Especialidade que será atualizada</param>
        /// <param name="especialidadeAtualizada">Objeto com as novas informações</param>
        public void AtualizarEspecialidade(int id, Especialidade especialidadeAtualizada)
        {
            //Busca uma especialidade através de seu ID
            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id);

            //Verifica se o nome da especialidade foi informada
            if (especialidadeAtualizada.NomeEspecialidade != null)
            {
                //Atribui os novos valores aos campos existentes
                especialidadeBuscada.NomeEspecialidade = especialidadeAtualizada.NomeEspecialidade;
            }

            //Atualiza o nome da especialidade que foi buscado
            ctx.Especialidades.Update(especialidadeBuscada);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma Especialidade por seu id
        /// </summary>
        /// <param name="id">Id da Especialidade que está sendo buscada</param>
        /// <returns>Uma Especialidade buscada</returns>
        public Especialidade BuscarEspecialidadePorId(int id)
        {
            //Retorna a primeira especialidade encontrada, para o ID informado
            return ctx.Especialidades.FirstOrDefault(e => e.IdEspecialidade == id);
        }

        /// <summary>
        /// Cadastra uma nova Especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Objeto novaEspecialidade que será cadastrado</param>
        public void CadastrarEspecialidade(Especialidade novaEspecialidade)
        {
            //Adiciona ao objeto novaEspecialidade as informações cadastradas
            ctx.Especialidades.Add(novaEspecialidade);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma Especialidade existente
        /// </summary>
        /// <param name="id">Id da Especialidade que será deletada</param>
        public void DeletarEspecialidade(int id)
        {
            //Busca uma especialidade através de seu id
            Especialidade especialidadeBuscada = ctx.Especialidades.Find(id);

            //Remove uma especialidade através de seu id
            ctx.Especialidades.Remove(especialidadeBuscada);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos as Especialidades
        /// </summary>
        /// <returns>Uma lista de especialidades</returns>
        public List<Especialidade> ListarEspecialidades()
        {
            //Retorna uma lista com todos as especialidades
            return ctx.Especialidades.ToList();
        }
    }
}

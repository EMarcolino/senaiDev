using senai_SpMedicalGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedicalGroup_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável por informar os métodos ao repositório IMedicoRepository
    /// </summary>
    interface IMedicoRepository
    {
        /// <summary>
        /// Cadastra um novo(a) Medico(a)
        /// </summary>
        /// <param name="novoMedico">Objeto novoMedico que será cadastrado</param>
        void CadastrarMedico(Medico novoMedico);

        /// <summary>
        /// Lista todos(as) os(as) Medico(as)
        /// </summary>
        /// <returns>Uma lista com os Medico(as) cadastrados(as)</returns>
        List<Medico> ListarMedicos();

        /// <summary>
        /// Busca um Medico(a) específico(a) por seu id
        /// </summary>
        /// <param name="id">Id do Medico(a) que está sendo buscado(a)</param>
        /// <returns>Um(a) Medico(a) buscado(a)</returns>
        Medico BuscarMedicoPorId(int id);

        /// <summary>
        /// Atualiza um Medico(a) 
        /// </summary>
        /// <param name="id">Id do Medico(a) que será atualizado(a)</param>
        /// <param name="medicoAtualizado">Objeto medicoAtualizado que contém as atualizações</param>
        void AtualizarMedico(int id, Medico medicoAtualizado);

        /// <summary>
        /// Deleta um(a) Medico(a)
        /// </summary>
        /// <param name="id">Id do Medico(a) que será deletado(a)</param>
        void DeletarMedico(int id);
    }
}

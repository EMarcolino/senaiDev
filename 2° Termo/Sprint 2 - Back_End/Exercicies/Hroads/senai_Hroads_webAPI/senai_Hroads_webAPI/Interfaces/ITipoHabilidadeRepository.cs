using senai_Hroads_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        /// <summary>
        /// Lista todos os Tipos Habilidades
        /// </summary>
        /// <returns>Uma lista com todos os tipos habilidades</returns>
        List<TipoHabilidade> ListarTipoHabilidade();

        /// <summary>
        /// Busca um tipo habilidade por seu id
        /// </summary>
        /// <param name="idTipoHabilidade">Id do tipo habilidade buscado</param>
        /// <returns>O Tipo de Habilidade buscado</returns>
        TipoHabilidade BuscarPorId(int idTipoHabilidade);

        /// <summary>
        /// Cadastra um novo Tipo de Habilidade 
        /// </summary>
        /// <param name="novoTipoHabilidade">Objeto novoTipoHabilidade com as novas informações</param>
        void Cadastrar(TipoHabilidade novoTipoHabilidade);

        /// <summary>
        /// Atualiza as informações de um Tipo de Habilidade por seu id
        /// </summary>
        /// <param name="idTipoHabilidade">Id do Tipo de Habilidade que será atualizado</param>
        /// <param name="tipoHabilidadeAtualizado">Objeto tipoHabilidadeAtualizado com as novas informações</param>
        void Atualizar(int idTipoHabilidade, TipoHabilidade tipoHabilidadeAtualizado);

        /// <summary>
        /// Deleta um Tipo de Habilidade
        /// </summary>
        /// <param name="idTipoHabilidade">Id do Tipo de Habilidade que será deletado</param>
        void Deletar(int idTipoHabilidade);
    }
}

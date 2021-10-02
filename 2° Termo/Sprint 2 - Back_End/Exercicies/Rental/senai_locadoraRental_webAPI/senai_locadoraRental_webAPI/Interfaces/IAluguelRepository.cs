using senai_locadoraRental_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_locadoraRental_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsavel por AluguelRepository
    /// </summary>
    interface IAluguelRepository
    {
        //      TipoRetorno NomeMetodo(Tipoparametro parâmetro);
        // Ex:  void Cadastrar();

        /// <summary>
        /// Retorna todos os Alugueis
        /// </summary>
        /// <returns>Uma lista de alugueis</returns>
        List<AluguelDomain> ListarTodos();

        /// <summary>
        /// Busca um objeto (Aluguel) por seu id
        /// </summary>
        /// <param name="id">Id do Aluguel que será buscado</param>
        /// <returns>Um objeto do tipo AluguelDomaian (Aluguel) que foi buscado</returns>
        AluguelDomain BuscarporId(int idAluguel);

        /// <summary>
        /// Cadastra um novo objeto (Aluguel)
        /// </summary>
        /// <param name="novoAluguel">Um novo objeto do tipo AluguelDomain será cadastrado</param>
       void Cadastrar(AluguelDomain novoAluguel);

        /// <summary>
        /// Atualiza um objeto (Aluguel) existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="aluguel">Objeto Aluguel que será atualizado, com as novas informações</param>
        void AtualizaIdCorpo(AluguelDomain aluguel);

        /// <summary>
        /// Atualiza um objeto (Aluguel) existente passando o id pela URL da requisição 
        /// </summary>
        /// <param name="id">Id do Aluguel que será atualizado</param>
        /// <param name="aluguel">Objeto (Aluguel) que será atualizado, com as novas informações</param>
        void AtualizaIdUrl(int id, AluguelDomain aluguel);

        /// <summary>
        /// Deleta um objeto (Aluguel)
        /// </summary>
        /// <param name="id">id do objeto (Aluguel que será deletado</param>
        void Deletar(int id);
    }
}

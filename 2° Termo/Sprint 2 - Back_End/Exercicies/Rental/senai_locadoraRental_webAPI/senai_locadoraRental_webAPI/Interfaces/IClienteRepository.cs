using senai_locadoraRental_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_locadoraRental_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsavel por ClienteRepository
    /// </summary>
    interface IClienteRepository
    {
        /// <summary>
        /// Retorna todos os Clientes
        /// </summary>
        /// <returns>Uma Lista de Clientes</returns>
        List<ClienteDomain> ListarTodos();

        /// <summary>
        /// Buscando um objeto (Cliente) por seu id
        /// </summary>
        /// <param name="id">Id do Cliente que será buscado</param>
        /// <returns>Um objeto do tipo ClienteDomaian (Cliente) que foi buscado</returns>
        ClienteDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo objeto (Cliente)
        /// </summary>
        /// <param name="novoCliente">Um novo objeto do tipo ClienteDomain será cadastrado</param>
        void Cadastrar(ClienteDomain novoCliente);

        /// <summary>
        /// Atualiza um objeto (Cliente) existente passando o id pelo corpo da requisição 
        /// </summary>
        /// <param name="cliente">Objeto Cliente que será atualizado, com as novas informações</param>
        void AtualizarIdCorpo(ClienteDomain cliente);

        /// <summary>
        /// Atualiza um objeto (Cliente) existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">Id do objeto (Cliente) que será atualizado</param>
        /// <param name="cliente">Objeto (Cliente) que será atualizado, com as novas informações</param>
        void AtualizarIdUrl(int id, ClienteDomain cliente);

        /// <summary>
        /// Deleta um Objeto (Cliente)
        /// </summary>
        /// <param name="id">Id do objeto (Cliente) que será deletado</param>
        void Deletar(int id);
    }
}

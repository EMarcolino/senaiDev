using senai_locadoraRental_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_locadoraRental_webAPI.Interfaces
{
    interface IVeiculoRepository
    {
        /// <summary>
        /// Retorna todos os Veículos
        /// </summary>
        /// <returns>Uma lista de Veículos</returns>
        List<VeiculoDomain> ListarTodos();

        /// <summary>
        /// Buscando um objeto (Veículo) por seu id
        /// </summary>
        /// <param name="id">Id do Veículo que será buscado</param>
        /// <returns>Um objeto do tipo AluguelDomaian (Veículo) que foi buscado</returns>
        VeiculoDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo objeto (Aluguel)
        /// </summary>
        /// <param name="novoVeiculo">Um novo objeto do tipo VeiculoDomain será cadastrado </param>
        void Cadastrar(VeiculoDomain novoVeiculo);

        /// <summary>
        /// Atualiza um objeto (Veículo) existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="veiculo">Objeto Veículo que será atualizado, com as novas informações</param>
        void AtualizarIdCorpo(VeiculoDomain veiculo);

        /// <summary>
        /// Atualiza um objeto (Veículo) existente passando o id pela URL da requisição 
        /// </summary>
        /// <param name="id">Id do objeto (Veículo) que será atualizado</param>
        /// <param name="veiculo">Objeto (Veículo) que será atualizado, com as novas informações</param>
        void AtualizarIdUrl(int id, VeiculoDomain veiculo);

        /// <summary>
        /// Deleta um objeto (Veículo)
        /// </summary>
        /// <param name="id">Id do objeto (Veículo) que será deletado</param>
        void Deletar(int id);
    }
}

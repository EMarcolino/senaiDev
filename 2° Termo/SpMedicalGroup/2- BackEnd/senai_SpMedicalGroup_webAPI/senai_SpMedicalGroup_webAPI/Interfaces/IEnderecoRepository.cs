using senai_SpMedicalGroup_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SpMedicalGroup_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável por informar os métodos ao repositório EnderecoRepository
    /// </summary>
    interface IEnderecoRepository
    {
        /// <summary>
        /// Cadastra um novo Endereço
        /// </summary>
        /// <param name="novoEndereco">Objeto novoEndereco que será cadastrado</param>
        void CadastrarEndereco(Endereco novoEndereco);

        /// <summary>
        /// Lista todos os Endereços
        /// </summary>
        /// <returns>Uma lista com os Endereço cadastrados</returns>
        List<Endereco> ListarEnderecos();

        /// <summary>
        /// Busca um Endereço específico por seu id
        /// </summary>
        /// <param name="id">Id do Endereço que está sendo buscado</param>
        /// <returns>Um Endereço buscado</returns>
        Endereco BuscarEnderecoPorId(int id);

        /// <summary>
        /// Atualiza um Endereço 
        /// </summary>
        /// <param name="id">Id do Endereço que será atualizado</param>
        /// <param name="enderecoAtualizado">Objeto enderecoAtualizado que contém as atualizações</param>
        void AtualizarEndereco(int id, Endereco enderecoAtualizado);

        /// <summary>
        /// Deleta um Endereço
        /// </summary>
        /// <param name="id">Id do Endereço que será deletado</param>
        void DeletarEndereco(int id);
    }
}

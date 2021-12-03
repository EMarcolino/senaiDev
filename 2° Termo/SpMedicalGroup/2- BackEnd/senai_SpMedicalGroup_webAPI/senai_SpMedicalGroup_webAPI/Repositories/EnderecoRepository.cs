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
    /// Classe responsável por declarar a implementação dos métodos para EnderecoController
    /// </summary>
    public class EnderecoRepository : IEnderecoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Atualiza um Endereço existente
        /// </summary>
        /// <param name="id">Id do Endereço que será atualizado</param>
        /// <param name="enderecoAtualizado">Objeto com as novas informações</param>
        public void AtualizarEndereco(int id, Endereco enderecoAtualizado)
        {
            //Busca um endereco através de seu ID
            Endereco enderecoBuscado = ctx.Enderecos.Find(id);

            //Verifica se o Logradouro do endereço foi informado
            if (enderecoAtualizado.Logradouro != null)
            {
                //Atribui os novos valores aos campos existentes
                enderecoBuscado.Logradouro = enderecoAtualizado.Logradouro;
            }

            //Verifica se o Numero do endereço foi informado
            if (enderecoAtualizado.Numero != null)
            {
                //Atribui os novos valores aos campos existentes
                enderecoBuscado.Numero = enderecoAtualizado.Numero;
            }

            //Verifica se o Bairro do endereço foi informado
            if (enderecoAtualizado.Bairro != null)
            {
                //Atribui os novos valores aos campos existentes
                enderecoBuscado.Bairro = enderecoAtualizado.Bairro;
            }

            //Verifica se o Cidade do endereço foi informado
            if (enderecoAtualizado.Cidade != null)
            {
                //Atribui os novos valores aos campos existentes
                enderecoBuscado.Cidade = enderecoAtualizado.Cidade;
            }

            //Verifica se o Estado do endereço foi informado
            if (enderecoAtualizado.Estado != null)
            {
                //Atribui os novos valores aos campos existentes
                enderecoBuscado.Estado = enderecoAtualizado.Estado;
            }

            //Verifica se o Cep do endereço foi informado
            if (enderecoAtualizado.Cep != null)
            {
                //Atribui os novos valores aos campos existentes
                enderecoBuscado.Cep = enderecoAtualizado.Cep;
            }

            //Atualiza o endereço que foi buscado
            ctx.Enderecos.Update(enderecoBuscado);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um Endereço por seu id
        /// </summary>
        /// <param name="id">Id do Endereço que está sendo buscado</param>
        /// <returns>Um Endereço buscado</returns>
        public Endereco BuscarEnderecoPorId(int id)
        {
            //Retorna o primeiro endereço encontrado, para o ID informado
            return ctx.Enderecos.FirstOrDefault(e => e.IdEndereco == id);
        }

        /// <summary>
        /// Cadastra um novo Endereço
        /// </summary>
        /// <param name="novoEndereco">Objeto novoEndereco que será cadastrado</param>
        public void CadastrarEndereco(Endereco novoEndereco)
        {
            //Adiciona ao objeto novoEndereco as informações cadastradas
            ctx.Enderecos.Add(novoEndereco);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Endereço existente
        /// </summary>
        /// <param name="id">Id do Endereço que será deletado</param>
        public void DeletarEndereco(int id)
        {
            //Busca um endereço através de seu id
            Endereco enderecoBuscado = ctx.Enderecos.Find(id);

            //Remove um endereço através de seu id
            ctx.Enderecos.Remove(enderecoBuscado);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Endereços
        /// </summary>
        /// <returns>Uma lista de Endereços</returns>
        public List<Endereco> ListarEnderecos()
        {
            //Retorna uma lista com todos os endereços
            return ctx.Enderecos.ToList();
        }
    }
}

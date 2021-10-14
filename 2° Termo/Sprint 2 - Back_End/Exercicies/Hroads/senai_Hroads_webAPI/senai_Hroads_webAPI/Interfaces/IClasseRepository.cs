using senai_Hroads_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Interfaces
{
    interface IClasseRepository
    {
        /// <summary>
        /// Lista todas as Classes de personagens 
        /// </summary>
        /// <returns>Uma lista de classes</returns>
        List<Classe> ListarClasses();

        /// <summary>
        /// Busca uma classe através de seu id
        /// </summary>
        /// <param name="idClasse">id da classe que será buscada</param>
        /// <returns>Uma classe encontrada</returns>
        Classe BuscarPorId(int idClasse);

        /// <summary>
        /// Cadastra uma nova Classe 
        /// </summary>
        /// <param name="novaClasse">Objeto novaClasse com as informações</param>
        void Cadastrar(Classe novaClasse);

        /// <summary>
        /// Atualiza uma classe existente 
        /// </summary>
        /// <param name="idClasse">Id da classe que será atualizada</param>
        /// <param name="classeAtualizada">Objeto classeAtualizada com as novas informações</param>
        void Atualizar(int idClasse, Classe classeAtualizada);

        /// <summary>
        /// Deleta uma classe existente
        /// </summary>
        /// <param name="idClasse">Id da classe que será deletada</param>
        void Deletar(int idClasse);
    }
}

using senai_Hroads_webAPI.Contexts;
using senai_Hroads_webAPI.Domains;
using senai_Hroads_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        /// <summary>
        /// Instancia o objeto contexto que irá referenciar uma tabela, por onde serão chamados os métodos do EntityFramework Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();

        public void Atualizar(int idClasse, Classe classeAtualizada)
        {
            throw new NotImplementedException();
        }

        public Classe BuscarPorId(int idClasse)
        {
            //Retorna a primeira classe encontrada comparando o id informado com o banco de dados 
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == idClasse);
        }

        public void Cadastrar(Classe novaClasse)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idClasse)
        {
            throw new NotImplementedException();
        }

        public List<Classe> ListarClasses()
        {
          //Retorna uma lista com todas as informações das classes
          return ctx.Classes.ToList();
        }
    }
}

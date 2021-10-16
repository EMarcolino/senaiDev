using senai_Hroads_webAPI.Contexts;
using senai_Hroads_webAPI.Domains;
using senai_Hroads_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Hroads_webAPI.Repositories
{
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {
        /// <summary>
        /// Instancia o objeto contexto que irá referenciar uma tabela, por onde serão chamados os métodos do EntityFramework Core
        /// </summary>
        HroadsContext ctx = new HroadsContext();
        public List<ClasseHabilidade> ListarTodos()
        {
            //Retorna uma lista com todas as informações das classes de personagens
            return ctx.ClasseHabilidades.ToList();
        }
    }
}

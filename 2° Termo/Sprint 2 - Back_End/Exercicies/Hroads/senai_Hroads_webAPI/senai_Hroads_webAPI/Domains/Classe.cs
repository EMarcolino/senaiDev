using System;
using System.Collections.Generic;

#nullable disable

namespace senai_Hroads_webAPI.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            ClasseHabilidades = new HashSet<ClasseHabilidade>();
            Personagems = new HashSet<Personagem>();
        }

        public int IdClasse { get; set; }
        public string NomeClasse { get; set; }
        public decimal? VidaClasse { get; set; }
        public decimal? ManaClasse { get; set; }

        public virtual ICollection<ClasseHabilidade> ClasseHabilidades { get; set; }
        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}

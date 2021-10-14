using System;
using System.Collections.Generic;

#nullable disable

namespace senai_Hroads_webAPI.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public int? IdClasse { get; set; }
        public string NomePersonagem { get; set; }
        public DateTime? DatAtualizacao { get; set; }
        public DateTime? DataCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}

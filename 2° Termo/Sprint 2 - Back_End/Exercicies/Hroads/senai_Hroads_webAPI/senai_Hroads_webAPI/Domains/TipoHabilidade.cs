using System;
using System.Collections.Generic;

#nullable disable

namespace senai_Hroads_webAPI.Domains
{
    public partial class TipoHabilidade
    {
        public TipoHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public int IdTipoHabilidade { get; set; }
        public string NomeTipoHabilidate { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}

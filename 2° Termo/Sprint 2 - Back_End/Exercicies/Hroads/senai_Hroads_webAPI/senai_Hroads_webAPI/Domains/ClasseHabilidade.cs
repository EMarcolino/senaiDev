﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai_Hroads_webAPI.Domains
{
    public partial class ClasseHabilidade
    {
        public int IdClasseHabilidade { get; set; }
        public int? IdClasse { get; set; }
        public int? IdHabilidade { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI.Domains
{
    public class TipoUsuarioDomain
    {
        public int idTipoUsuario { get; set; }
        public string nomeTipo { get; set; }

    }
}

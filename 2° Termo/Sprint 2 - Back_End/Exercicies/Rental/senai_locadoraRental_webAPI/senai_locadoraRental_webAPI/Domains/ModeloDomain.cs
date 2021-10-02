using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_locadoraRental_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a Entidade (tabela) Modelo
    /// </summary>
    public class ModeloDomain
    {
        public int idModelo { get; set; }

        public int idMarca { get; set; }

        public string nomeModelo { get; set; }

    }
}

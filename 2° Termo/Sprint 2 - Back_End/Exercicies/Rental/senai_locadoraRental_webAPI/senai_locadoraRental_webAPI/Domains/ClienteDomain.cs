using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_locadoraRental_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a Entidade (tabela) Cliente
    /// </summary>
    public class ClienteDomain
    {
        public int idCliente { get; set; }

        public string nomeCliente { get; set; }

        public string sobrenomeCliente { get; set; }

        public int cpfCliente { get; set; }
    }
}

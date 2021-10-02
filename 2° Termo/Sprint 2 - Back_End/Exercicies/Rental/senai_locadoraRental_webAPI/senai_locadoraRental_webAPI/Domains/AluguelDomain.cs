using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_locadoraRental_webAPI.Domains
{
    /// <summary>
    /// Classe que representa a Entidade (tabela) Aluguel do banco de dados
    /// </summary>
    public class AluguelDomain
    {
     
        public int idAluguel { get; set; }

        public int idCliente { get; set; }

        public int idVeiculo { get; set; }

        public DateTime dataInicio { get; set; }

        public DateTime dataEntrega { get; set; }

    }
}

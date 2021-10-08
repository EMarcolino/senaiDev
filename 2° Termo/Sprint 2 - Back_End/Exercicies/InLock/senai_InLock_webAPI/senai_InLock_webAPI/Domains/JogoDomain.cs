using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI.Domains
{
    public class JogoDomain
    {
        public int idJogo { get; set; }
        public int idEstudio { get; set; }

        [Required(ErrorMessage = "O nome do Jogo é Obrigatório!")]
        public string nomeJogo { get; set; }
        public string descricao { get; set; }
        public DateTime dataLancamento { get; set; }
        public decimal valorJogo { get; set; }
        public EstudioDomain estudio { get; set; }


    }
}

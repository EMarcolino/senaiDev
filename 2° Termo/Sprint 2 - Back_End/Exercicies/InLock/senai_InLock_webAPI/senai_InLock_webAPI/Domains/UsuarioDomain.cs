using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_InLock_webAPI.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        public int idTipoUsuario { get; set; }

        [Required(ErrorMessage = "O email do Usuario é Obrigatório!")]
        public string email { get; set; }

        [Required(ErrorMessage = "A senha do Usuario é Obrigatória!")]
        public string senha { get; set; }
        public TipoUsuarioDomain tipoUsuario { get; set; }

    }
}

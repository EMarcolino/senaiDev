﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai_SpMedicalGroup_webAPI.Domains
{
    public partial class Endereco
    {
        public Endereco()
        {
            Clinicas = new HashSet<Clinica>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

        public virtual ICollection<Clinica> Clinicas { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}

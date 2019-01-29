using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloriculturaBeta.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteCpf { get; set; }
        public string ClienteTelefone { get; set; }
        public string ClienteEstado { get; set; }
        public string ClienteCidade { get; set; }
        public string ClienteBairro { get; set; }
        public string ClienteRua { get; set; }
        public string ClienteNumero { get; set; }
        public string ClienteComplemento { get; set; }

    }
}
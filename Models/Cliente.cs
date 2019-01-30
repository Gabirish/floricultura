using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FloriculturaBeta.Models
{
    public class Cliente
    {
        
        public int ClienteId { get; set; }

        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false)]
        public string ClienteNome { get; set; }

        [Display(Name = "CPF")]
        [Required(AllowEmptyStrings = false)]
        public string ClienteCpf { get; set; }

        [Display(Name = "Telefone")]
        [Required(AllowEmptyStrings = false)]
        public string ClienteTelefone { get; set; }

        [Display(Name = "Estado")]
        [Required(AllowEmptyStrings = false)]
        public string ClienteEstado { get; set; }

        [Display(Name = "Cidade")]
        [Required(AllowEmptyStrings = false)]
        public string ClienteCidade { get; set; }

        [Display(Name = "Bairro")]
        [Required(AllowEmptyStrings = false)]
        public string ClienteBairro { get; set; }

        [Display(Name = "Rua")]
        [Required(AllowEmptyStrings = false)]
        public string ClienteRua { get; set; }

        [Display(Name = "Numero")]
        public string ClienteNumero { get; set; }

        [Display(Name = "Complemento")]
        public string ClienteComplemento { get; set; }

    }
}
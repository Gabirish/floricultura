using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FloriculturaBeta.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false)]
        public string FuncionarioNome { get; set; }

        [Display(Name = "CPF")]
        [Required(AllowEmptyStrings = false)]
        public string FuncionarioCpf { get; set; }

    }
}
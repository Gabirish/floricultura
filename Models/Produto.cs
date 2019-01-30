using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FloriculturaBeta.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        [Display(Name = "Nome")]
        [Required(AllowEmptyStrings = false)]
        public string ProdutoNome { get; set; }

        [Display(Name = "Descrição")]
        [Required(AllowEmptyStrings = false)]
        public string ProdutoDescricao { get; set; }

        [Display(Name = "R$")]
        [Required(AllowEmptyStrings = false)]
        public decimal ProdutoValor { get; set; }

        [Display(Name = "Estoque")]
        [Required(AllowEmptyStrings = false)]
        public int ProdutoEstoque { get; set; }

        [NotMapped]
        public int QuantidadeVenda { get; set; }
    }
}
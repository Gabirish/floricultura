using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FloriculturaBeta.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public string ProdutoDescricao { get; set; }
        public decimal ProdutoValor { get; set; }
        public int ProdutoEstoque { get; set; }

        [NotMapped]
        public int QuantidadeVenda { get; set; }
    }
}
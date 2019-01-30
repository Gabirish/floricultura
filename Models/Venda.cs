using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace FloriculturaBeta.Models
{
    public class Venda
    {

        public int VendaId { get; set; }

        [Display(Name = "Funcionario")]
        [Required(AllowEmptyStrings = false)]
        public int FuncionarioId { get; set; }

        [Display(Name = "Cliente")]
        [Required(AllowEmptyStrings = false)]
        public int ClienteId { get; set; }

        [Display(Name = "Data")]
        [Required(AllowEmptyStrings = false)]
        public DateTime VendaData { get; set; }


        public virtual List<ItemVenda> ItensVenda { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        //Não será gerado uma coluna com os atributos marcados como NotMapped do data annotation no banco de dados
        [NotMapped]
        public virtual List<Produto> Produtos { get; set; }


        public bool verificaQuantidade()
        {
            foreach (Produto p in Produtos)
            {
                if (p.ProdutoEstoque < p.QuantidadeVenda)
                {
                    return false;
                }
            }
            return true;
        }
    }


}
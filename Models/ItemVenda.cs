using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloriculturaBeta.Models
{
    public class ItemVenda
    {
        public int ItemVendaId { get; set; }
        public int ProdutoId { get; set; }
        public int ItemVendaQuantidade { get; set; }
        public int VendaId { get; set; }

  
        public virtual Venda Venda { get; set; }
        public virtual Produto Produto { get; set; }

        
    }
}
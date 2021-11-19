using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjVendas.BLL
{
    public class ItemVenda
    {
        public int ProdutoId { get; set; }
        public int VendaId { get; set; }
        public String DescricaoProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public double PrecoUnitario { get; set; }

        public void InserirItem()
        {

        }
        public void ExcluItem()
        {

        }

    }
}
using PrjVendas.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjVendas.DAL
{
    public static class ItemVendaDALFake
    {
        public static IList<ItemVenda> Itens { get; set; } = new List<ItemVenda>();
    }
}
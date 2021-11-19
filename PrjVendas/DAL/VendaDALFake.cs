using PrjVendas.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjVendas.DAL
{
    public static class VendaDALFake
    {
        public static IEnumerable<Venda> Vendas { get; set; } = new List<Venda>();
    }
}
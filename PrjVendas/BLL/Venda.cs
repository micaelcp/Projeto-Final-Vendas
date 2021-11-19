using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjVendas.BLL
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public double Total { get; set; }

        public void RegistrarVenda()
        {

        }

        public int ListarVendas()
        {
            return 0;
        }
    }
}
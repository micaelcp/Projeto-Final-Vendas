using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjVendas.BLL
{
    public class Funcoes
    {
        private static string _connString = "Initial Catalog=bdVendas;Data Source=DITEC112826\\SQLEXPRESS;user id=usuarioVendas;password=senha;";

        public static string connString
        {
            get { return _connString; }
        }
    }
}
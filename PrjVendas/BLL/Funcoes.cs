using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrjVendas.BLL
{
    public class Funcoes
    {
        private static string _connString = "Initial Catalog=bdVendas;Data Source=DRACARYOS;user id=usuarioTeste;password=senha;";

        public static string connString
        {
            get { return _connString; }
        }
    }
}
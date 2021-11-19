using PrjVendas.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PrjVendas.BLL
{
    public class Vendedor
    {
        private static string connString = Funcoes.connString;
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public void Inserir()
        {
            string meuSQL = "INSERT INTO TBVENDEDOR(NOME, CPF, EMAIL, SENHA) VALUES" +
                            "('" + Nome.Trim() + "','" + Cpf.Trim() + "','" + Email.Trim() + "', '" + Senha.Trim() + "' )";
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }
        public void Alterar(int Id)
        {
            string meuSQL = "UPDATE TBVENDEDOR SET " +
                            " NOME = '" + Nome.Trim() + "'," +
                            " CPF = '" + Cpf.Trim() + "'," +
                            " email = '" + Email.Trim() + "'," +
                            " senha = '" + Senha.Trim() + "'" +
                            " WHERE IDVENDEDOR = " + Id;

            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }
        public void Excluir(int Id)
        {
            string meuSQL = "DELETE TBVENDEDOR WHERE IDVENDEDOR = " + Id;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }
        public static DataSet RetornaVendedorId(int Id)
        {
            string MeuSQL = "SELECT IDVENDEDOR, NOME, CPF, EMAIL, SENHA FROM TBVENDEDOR" +
                            " WHERE IDVENDEDOR = " + Id;
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, MeuSQL);
            return ds;
        }

        public static DataSet PreencheCboVendedor()
        {
            string meuSQL = "SELECT  IDVENDEDOR, NOME, CPF FROM TBVENDEDOR";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;

        }

        public void MostrarDadosVendedor(int id)
        {
            string MeuSQL = "SELECT IDVENDEDOR, NOME, CPF, EMAIL, SENHA FROM TBVENDEDOR" +
                           " WHERE IDVENDEDOR = " + id;
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, MeuSQL);
            if ((ds.Tables[0].Rows.Count > 0))
            {
                DataRow dr = ds.Tables[0].Rows[0];
                Id = Convert.ToInt32(dr["IDVENDEDOR"]);
                Nome = Convert.ToString(dr["NOME"]);
                Cpf = Convert.ToString(dr["CPF"]);
                Email = Convert.ToString(dr["EMAIL"]);
                Senha = Convert.ToString(dr["SENHA"]);

            }

        }
        public static DataSet ListaTodosVendedores()
        {
            string MeuSQL = "SELECT IDVENDEDOR, NOME, CPF, EMAIL FROM TBVENDEDOR";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, MeuSQL);
            return ds;


        }



    }
}
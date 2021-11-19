using PrjVendas.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PrjVendas.BLL
{
    public class Cliente
    {
        private static string connString = Funcoes.connString;
        
        private int idcliente;
        private string nome;
        private string cpf;
        private string email;
        private string senha;

        public int Idcliente { get => idcliente; set => idcliente = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
        

        public void Inserir()
        {
            string meuSQL = "INSERT INTO TBCLIENTE(NOME, CPF,EMAIL,SENHA) VALUES" +
                            "('" + nome.Trim() + "','" + cpf.Trim() + "','" + email.Trim() + "','" + senha.Trim() + "')";

            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }
        public void Alterar()
        {
            string meuSQL = "UPDATE TBCLIENTE SET " +
                            " NOME = '" + nome.Trim() + "'," +
                            " CPF = '" + cpf.Trim() + "'," +
                            " email = '" + email.Trim() + "'," +
                            " senha = '" + senha.Trim() + "'" +
                            " WHERE IDCLIENTE = " + idcliente;

            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }
        public void Excluir(int Id)
        {
            string meuSQL = "DELETE TBCLIENTE WHERE IDCLIENTE = " + Id;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);


        }
        public static DataSet RetornaClienteId(int Id)
        {
            string MeuSQL = "SELECT IDCLIENTE, NOME, CPF, EMAIL, SENHA FROM TBCLIENTE"+
                            " WHERE IDCLIENTE = "+Id;
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, MeuSQL);
            return ds;
        }
        public static DataSet PreencheCboCliente()
        {
            string meuSQL = "SELECT IDCLIENTE, NOME,CPF FROM TBCLIENTE";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            return ds;

        }
        public void MostrarDadosCliente(int id)
        {
            string MeuSQL = "SELECT IDCLIENTE, NOME, CPF, EMAIL, SENHA FROM TBCLIENTE" +
                           " WHERE IDCLIENTE = " + id;
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, MeuSQL);
            if((ds.Tables[0].Rows.Count> 0))
            {
                DataRow dr = ds.Tables[0].Rows[0];
                idcliente = Convert.ToInt32(dr["IDCLIENTE"]);
                nome = Convert.ToString(dr["NOME"]);
                cpf = Convert.ToString(dr["CPF"]);
                email = Convert.ToString(dr["EMAIL"]);
                senha = Convert.ToString(dr["SENHA"]);

            }
           
        }
        public static DataSet ListaTodosClientes()
        {
            string MeuSQL = "SELECT IDCLIENTE, NOME, CPF, EMAIL FROM TBCLIENTE";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, MeuSQL);
            return ds;


        }
    }
}
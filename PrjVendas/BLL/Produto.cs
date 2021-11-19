using PrjVendas.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace PrjVendas.BLL
{
    public class Produto
    {
        private static string connString = Funcoes.connString;
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string UnidadeMedida { get; set; }

        public double PrecoUnitario { get; set; }

        public byte[] ImgProduto { get; set; }


        public void Inserir()
        {
            string meuSQL = "INSERT INTO TBPRODUTO(NOME,DESCRICAO, QuantidadeEstoque,UnidadeMedida, PrecoUnitario, ImgProduto) VALUES " +
                            "('" + Nome.Trim() + "','" + Descricao.Trim() + "'," + QuantidadeEstoque + ",'" + UnidadeMedida + "'," + PrecoUnitario
                             + ", CONVERT(VARBINARY(MAX),'" + Convert.ToBase64String(ImgProduto) + "'))";
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);
        }
          
        public void Alterar(int Id)
        {
            string meuSQL = "UPDATE TBPRODUTO SET " +
                            " NOME = '" + Nome.Trim() + "'," +
                            " DESCRICAO = '" + Descricao.Trim() + "'," +
                            " QUANTIDADEESTOQUE = " + QuantidadeEstoque + "," +
                            " UNIDADEMEDIDA = '" + UnidadeMedida.Trim() + "'," +
                            " PRECOUNITARIO = " +PrecoUnitario+ "," +
                            " IMGPRODUTO = " + "CONVERT(VARBINARY(MAX), '" + Convert.ToBase64String(ImgProduto) + "'))"+
                            " WHERE IDPRODUTO = " +Id;

            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);

        }
        public void Excluir(int Id)
        {
            string meuSQL = "DELETE TBPRODUTO WHERE IDPRODUTO = " + Id;
            SqlHelper.ExecuteNonQuery(connString, CommandType.Text, meuSQL);

        }
        public int RetornaProdutoId(int id)
        {
            return 0;
        }
        public DataSet ListaTodosProdutos()
        {
            string MeuSQL = "SELECT IDPRODUTO, NOME, DESCRICAO, QUANTIDADEESTOQUE, UNIDADEMEDIDA, PRECOUNITARIO, IMGPRODUTO FROM TBPRODUTO ";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, MeuSQL);
            return ds;
        }

        public static DataSet PreencheCboProduto()
        {
            string MeuSQL = "SELECT IDPRODUTO, NOME FROM TBPRODUTO ";
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, MeuSQL);
            return ds;
        }
        public void MostrarDadosProduto(int id)
        {
            string meuSQL = "SELECT IDPRODUTO, NOME, DESCRICAO, QUANTIDADEESTOQUE, UNIDADEMEDIDA, PRECOUNITARIO, IMGPRODUTO FROM TBPRODUTO" +
                            " WHERE IDPRODUTO=" + id;
            DataSet ds = SqlHelper.ExecuteDataset(connString, CommandType.Text, meuSQL);
            if ((ds.Tables[0].Rows.Count > 0))
            {
                DataRow dr = ds.Tables[0].Rows[0];
                Id = Convert.ToInt32(dr["IDPRODUTO"]);
                Nome = Convert.ToString(dr["NOME"]);
                Descricao = Convert.ToString(dr["DESCRICAO"]);
                QuantidadeEstoque = Convert.ToInt32(dr["QUANTIDADEESTOQUE"]);
                UnidadeMedida = Convert.ToString(dr["UNIDADEMEDIDA"]);
                PrecoUnitario=Convert.ToDouble(dr["PRECOUNITARIO"]);
                byte[] buffer = (byte[])dr["IMGPRODUTO"];
                ImgProduto = (buffer);

            }
        }



    }
}
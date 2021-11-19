using PrjVendas.BLL;
using PrjVendas.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjVendas
{
    public partial class CVendas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                preenchecboCliente();
                preenchecboVendedor();
                preenchecboProduto();
            }
        }
        void preenchecboCliente()
        {

            cboCliente.DataTextField = "NOME";
            cboCliente.DataValueField = "IDCLIENTE";
            cboCliente.DataSource = Cliente.PreencheCboCliente();//Vou na classe Curso e chamo o método PreecheCboCurso
            cboCliente.DataBind();
            cboCliente.Items.Insert(0, new ListItem("SELECIONE UM CLIENTE"));
        }
        void preenchecboVendedor()
        {
            cboVendedor.DataTextField = "NOME";
            cboVendedor.DataValueField = "IDVENDEDOR";
            cboVendedor.DataSource = Vendedor.PreencheCboVendedor();//Vou na classe Curso e chamo o método PreecheCboCurso
            cboVendedor.DataBind();
            cboVendedor.Items.Insert(0, new ListItem("SELECIONE UM VENDEDOR"));
        }
        void preenchecboProduto()
        {
            cboProduto.DataTextField = "NOME";
            cboProduto.DataValueField = "IDPRODUTO";
            cboProduto.DataSource = Produto.PreencheCboProduto();//Vou na classe Curso e chamo o método PreecheCboCurso
            cboProduto.DataBind();
            cboProduto.Items.Insert(0, new ListItem("SELECIONE UM PRODUTO"));
        }

       

        protected void cboProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarProduto(Convert.ToInt32(cboProduto.SelectedValue));
        }
        void MostrarProduto(int codigo)
        {
            Produto produto = new Produto();
            produto.MostrarDadosProduto(codigo);
            txtValorProduto.Text = Convert.ToString(produto.PrecoUnitario);

        }

        protected void txtQtdVenda_TextChanged(object sender, EventArgs e)
        {
            txtValortotal.Text = Convert.ToString(Math.Round((Convert.ToDouble(txtQtdVenda.Text) * Convert.ToDouble(txtValorProduto.Text)),2));
        }

        protected void cmdAdicionarProduto_Click(object sender, EventArgs e)
        {
         
            ItemVenda itemVenda = new ItemVenda();
            itemVenda.ProdutoId = Convert.ToInt32(cboProduto.SelectedItem.Value);
            itemVenda.DescricaoProduto = cboProduto.SelectedItem.Text;
            itemVenda.PrecoUnitario = Convert.ToDouble(txtValorProduto.Text);
            itemVenda.QuantidadeProduto = Convert.ToInt32(txtValortotal.Text);

            ItemVendaDALFake.Itens.Add(itemVenda);

            grwVendas.DataSource = ItemVendaDALFake.Itens;
            grwVendas.DataBind();

            

        }
    }
}
using PrjVendas.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjVendas
{
    public partial class CVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                preencherGridVendedor();
            }
        }

        protected void cmdConfirmar_Click(object sender, EventArgs e)
        {
            adicionarVendedor();
            preencherGridVendedor();
            LimparCampos();
        }
        void preencherGridVendedor()
        {
            grwVendedor.DataSource = Vendedor.ListaTodosVendedores();
            grwVendedor.DataBind();
            Formatar_Grid();
        }
        void Formatar_Grid()
        {
            if(!(grwVendedor.HeaderRow is null))
            {
                grwVendedor.UseAccessibleHeader = true;
                grwVendedor.HeaderRow.TableSection = TableRowSection.TableHeader;
                AplicarDataTableGridView();
            }
            

        }
        public void AplicarDataTableGridView()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "minhaFuncao", "aplicarDataTable()", true);
        }

        private void adicionarVendedor()
        {
            Vendedor vendedor = new Vendedor();
            vendedor.Nome = txtNomeVendedor.Text;
            vendedor.Cpf = txtCPF.Text;
            vendedor.Email = txtEmail.Text;
            vendedor.Senha = txtSenha.Text;
            if (cmdConfirmar.Text == "Incluir")
            {
                vendedor.Inserir();
            }
            else
            {
               vendedor.Alterar(Convert.ToInt32(grwVendedor.DataKeys[grwVendedor.SelectedIndex].Values[0]));
            }
        }

        protected void cmdExcluir_Click(object sender, EventArgs e)
        {
            Vendedor vendedor = new Vendedor();
            vendedor.Excluir(Convert.ToInt32(grwVendedor.DataKeys[grwVendedor.SelectedIndex].Values[0]));
            preencherGridVendedor();
            LimparCampos();
        }
        void LimparCampos()
        {
            cmdConfirmar.Text = "Incluir";
            cmdExcluir.Enabled = false;
            txtNomeVendedor.Text = "";
            txtCPF.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
        }

        protected void cmdLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            Formatar_Grid();
        }

        protected void grwVendedor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var parametros = e.CommandArgument.ToString().Split('|');
            MostrarDadosVendedor(Convert.ToInt32(parametros[0]));
            int indiceLinha = Convert.ToInt32(parametros[1]);
            grwVendedor.SelectedIndex = indiceLinha;
            cmdConfirmar.Text = "Alterar";
            cmdExcluir.Enabled = true;
            Formatar_Grid();
        }
        public void MostrarDadosVendedor(int codigo)
        {
            Vendedor vendedor = new Vendedor();
            vendedor.MostrarDadosVendedor(codigo);
            txtNomeVendedor.Text = vendedor.Nome;
            txtCPF.Text = vendedor.Cpf;
            txtEmail.Text = vendedor.Email;
            txtSenha.Text = vendedor.Senha;
        }

        protected void grwVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
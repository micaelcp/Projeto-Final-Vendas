using PrjVendas.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjVendas
{
    public partial class CCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                preencherGridClientes();
            }
        }
        void preencherGridClientes()
        {
            grwCliente.DataSource = Cliente.ListaTodosClientes();
            grwCliente.DataBind();
            Formatar_Grid();
        }

        protected void cmdConfirmar_Click(object sender, EventArgs e)
        {
            adicionarCliente();
            preencherGridClientes();
        }
        private void adicionarCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = txtNomeCliente.Text;
            cliente.Cpf = txtCPF.Text;
            cliente.Email = txtEmail.Text;
            cliente.Senha = txtSenha.Text;

            if (cmdConfirmar.Text == "Incluir")
            {
                cliente.Inserir();

            }
            else
            {
                cliente.Idcliente = Convert.ToInt32(grwCliente.DataKeys[grwCliente.SelectedIndex].Values[0]);
                cliente.Alterar();
               
            }

            LimparCampos();
        }

        private void LimparCampos()
        {
            cmdConfirmar.Text = "Incluir";
            cmdExcluir.Enabled = false;
            txtNomeCliente.Text = "";
            txtCPF.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";

        }
        protected void grwCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var parametros = e.CommandArgument.ToString().Split('|');
            
            MostrarDadosCliente(Convert.ToInt32(parametros[0]));
            int indiceLinha = (Convert.ToInt32(parametros[1]));
            //
            grwCliente.SelectedIndex = indiceLinha;
            cmdConfirmar.Text = "Alterar";
            cmdExcluir.Enabled = true;
            Formatar_Grid();
        }
        void Formatar_Grid()
        {
            grwCliente.UseAccessibleHeader = true;
            //grwCliente.HeaderRow.TableSection = TableRowSection.TableHeader;
            AplicarDataTableGridView();

        }
        public void AplicarDataTableGridView()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "minhaFuncao", "aplicarDataTable()", true);
        }

        private void MostrarDadosCliente(int idCliente)
        {
            Cliente cliente = new Cliente();
            cliente.MostrarDadosCliente(idCliente);
            txtNomeCliente.Text = cliente.Nome;
            txtCPF.Text = cliente.Cpf;
            txtEmail.Text = cliente.Email;
            txtSenha.Text = cliente.Senha;

        }


        protected void grwCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmdExcluir_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Excluir(Convert.ToInt32(grwCliente.DataKeys[grwCliente.SelectedIndex].Values[0]));
            preencherGridClientes();
            LimparCampos();
        }

        protected void cmdLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            Formatar_Grid();
        }
    }
}
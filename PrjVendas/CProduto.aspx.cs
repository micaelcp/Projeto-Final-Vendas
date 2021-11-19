using PrjVendas.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjVendas
{
    public partial class CProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                preecheGridProduto();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ExibirModal("myModalUpload");
        }
        public void ExibirModal(string idmodal)
        {
            // Essa função emite um msgbox efoi adaptada para o uso do AJAX
            // Se eu quiser usar outras funções basta criar um arquivo javascript e referenciá-lo no scriptmanger vide exemplo no html desta página
            string strScript = string.Empty;

            strScript = strScript + "$('#" + idmodal + "').modal('show');";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), strScript, true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            StartUpLoad();
        }
        private void StartUpLoad()
        {
            //get the file name of the posted image  
            string imgName = FileUpload.FileName;
            //sets the image path  
            string imgPath = "ImageStorage/" + imgName;
            //get the size in bytes that  

            int imgSize = FileUpload.PostedFile.ContentLength;

            //validates the posted file before saving  
            if (FileUpload.PostedFile != null && FileUpload.PostedFile.FileName != "")
            {
                // 10240 KB means 10MB, You can change the value based on your requirement  
                if (FileUpload.PostedFile.ContentLength > 10240)
                {
                   // Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('File is too big.')", true);
                }
                else
                {
                    //then save it to the Folder  
                    FileUpload.SaveAs(Server.MapPath(imgPath));
                    imgProduto.ImageUrl = "~/" + imgPath;
                    //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Alert", "alert('Image saved!')", true);
                }

            }
        }

        protected void cmdConfirmar_Click(object sender, EventArgs e)
        {

            adicionarProduto();
                                                                                          //
        }
        void Formatar_Grid()
        {
            if (!(grwProduto.HeaderRow is null))
            {
                grwProduto.UseAccessibleHeader = true;
                grwProduto.HeaderRow.TableSection = TableRowSection.TableHeader;
                AplicarDataTableGridView();
            }


        }
        public void AplicarDataTableGridView()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "minhaFuncao", "aplicarDataTable()", true);
        }
        private void adicionarProduto()
        {
            Produto produto = new Produto();
            byte[] buffer = new byte[imgInp.FileContent.Length];
            Stream s = imgInp.FileContent;
            s.Read(buffer, 0, buffer.Length);

            produto.Nome = txtNomeProduto.Text;
            produto.Descricao = txtDescricao.Text;
            produto.QuantidadeEstoque = Convert.ToInt32 (txtQuantidade.Text);
            produto.UnidadeMedida = txtUnidadeMedida.Text;
            produto.PrecoUnitario = Convert.ToDouble(txtPreco.Text);
            produto.ImgProduto = buffer;
            if (cmdConfirmar.Text == "Incluir")
            {
                produto.Inserir();
            }
            else
            {
                //produto.Alterar(id);
            }
            preecheGridProduto();
            LimparCampos();

        }
        void preecheGridProduto()
        {
            Produto produto = new Produto();
            grwProduto.DataSource = produto.ListaTodosProdutos();
            grwProduto.DataBind();
            Formatar_Grid();
        }
        void LimparCampos()
        {
            cmdConfirmar.Text = "Incluir";
            cmdExcluir.Enabled = false;
            txtNomeProduto.Text = "";
            txtDescricao.Text = "";
            txtQuantidade.Text = "";
            txtUnidadeMedida.Text = "";
            txtPreco.Text = "";
            imgProduto.ImageUrl = "";
        }
        protected void cmdSair_Click(object sender, EventArgs e)
        {
          
        }
       
    }
}

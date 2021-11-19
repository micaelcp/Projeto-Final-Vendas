<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="CProduto.aspx.cs" Inherits="PrjVendas.CProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card">
                <div class="card-header bg-info text-white">
                    Cadastro de Produtos
                </div>

                <div class="card-body form-group">
                    <div class="form-group row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Image ID="imgProduto" runat="server" Width="80%" Height="200px"/>
                                <asp:FileUpload ID="imgInp" runat="server" accept="image/*" type='file' />
                            </div>
                        </div>
                        <div class="col-md-9">
                            <div class="form-group row">
                                <div class="col-md-6">
                                    <label>Nome Produto</label>
                                    <asp:TextBox ID="txtNomeProduto" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label>Quantidade</label>
                                    <asp:TextBox ID="txtQuantidade" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label>Uni Medida</label>
                                    <asp:TextBox ID="txtUnidadeMedida" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <label>Preço</label>
                                    <asp:TextBox ID="txtPreco" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div>
                                <label>Descrição do Produto</label>
                                <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Produtos Cadastrados"></asp:Label>
                            <asp:GridView ID="grwProduto" runat="server" AutoGenerateColumns="False" DataKeyNames="IDPRODUTO">
                                <Columns>
                                    <asp:TemplateField HeaderText="NOME">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblNOME" runat="server" CommandArgument='<%#Eval("IDPRODUTO").ToString()+"|"+Container.DataItemIndex.ToString()%>'
                                                Text='<%#(Eval("NOME").ToString()) %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="QuantidadeEstoque" HeaderText="NOME" />
                                    <asp:BoundField DataField="PrecoUnitario" HeaderText="E-MAIL" />
                                </Columns>
                                <SelectedRowStyle BackColor="Yellow" />
                            </asp:GridView>
                        </div>
                    </div>

                </div>
                <div class="card-footer">
                    <div class="form-group row">
                        <div class="col-md-3">
                            <asp:Button ID="cmdConfirmar" CssClass="btn btn-info" Width="100%" runat="server" Text="Incluir" Font-Bold="True" OnClick="cmdConfirmar_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdExcluir" CssClass="btn btn-info" Width="100%" runat="server" Text="Excluir" Font-Bold="True" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdLimpar" CssClass="btn btn-info" Width="100%" runat="server" Text="Limpar" Font-Bold="True" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdSair" CssClass="btn btn-info" Width="100%" runat="server" Text="Sair" Font-Bold="True" OnClick="cmdSair_Click" />
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">Validation Errors List for HP7 Citation</h4>
                            </div>
                            <div class="modal-body">
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="cmdConfirmar" />
        </Triggers>
    </asp:UpdatePanel>
    <!-- Modal Pesquis -->
    <div class="modal fade" id="myModalUpload" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title"></h4>
                </div>
                <div class="modal-body">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h3 class="panel-title panel-success Form">Upload de Arquivos</h3>
                        </div>
                        <div class="panel-body efeito_Panel" style="padding: 2px; margin: 1px">
                            <div>
                                <div>
                                    <label>Selecione arquivo:</label>
                                    <asp:FileUpload ID="FileUpload" runat="server"
                                        CssClass="form-control" />
                                </div>
                                <div>
                                    <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        ContentPlaceHolder1_imgInp.onchange = evt => {

            const [file] = ContentPlaceHolder1_imgInp.files

            if (file) {

                ContentPlaceHolder1_imgProduto.src = URL.createObjectURL(file)

            }

        }
        function aplicarDataTable() {
            var dt = $('#ContentPlaceHolder1_grwProduto').DataTable({
                "language": {
                    "lengthMenu": 'Mostrar <select>' +
                        '<option value="5">05</option>' +
                        '<option value="10">10</option>' +
                        '<option value="20">30</option>' +
                        '</select> Operações',
                    "emptyTable": "Nenhum registro encontrado",
                    "search": "Pesquisar Produtos:",
                    "info": "Mostrando página _PAGE_ de _PAGES_",
                    "infoFiltered": "(filtrado _MAX_ do total Produtos)",
                    "paginate": {
                        "first": "Primeiro",
                        "last": "Último",
                        "next": "Próximo",
                        "previous": "Anterior"
                    }

                },
                "pageLength": 5,
                "scrollY": "300px",
                "scrollCollapse": true,
                "destroy": true


            });


            return dt;
        }
        aplicarDataTable();

    </script>
</asp:Content>

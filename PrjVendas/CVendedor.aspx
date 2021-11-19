<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="CVendedor.aspx.cs" Inherits="PrjVendas.CVendedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <updatepanel>
        <contenttemplate>
            <div class="card efeito_Panel_2">
                <div class="card-header bg-info text-white">
                    Cadastro de Vendedores
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <div>
                            <asp:Label ID="lblCPF" runat="server" Text="CPF"></asp:Label>
                            <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblNome" runat="server" Text="Nome do Vendedor"></asp:Label>
                            <asp:TextBox ID="txtNomeVendedor" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblEmail" runat="server" Text="e-Mail"></asp:Label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div>
                            <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lblSenha" runat="server" Text="Senha"></asp:Label>
                            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>

                        <div>
                            <asp:Label ID="Label1" runat="server" Text="Vendedores Cadastrados"></asp:Label>
                            <asp:GridView ID="grwVendedor" runat="server" AutoGenerateColumns="False" DataKeyNames="IDVENDEDOR" OnRowCommand="grwVendedor_RowCommand" OnSelectedIndexChanged="grwVendedor_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="CPF">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lblCPF" runat="server" CommandArgument='<%#Eval("IDVENDEDOR").ToString()+"|"+Container.DataItemIndex.ToString()%>'
                                                Text='<%#(Eval("CPF").ToString()) %>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NOME" HeaderText="NOME" />
                                    <asp:BoundField DataField="EMAIL" HeaderText="E-MAIL" />
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
                            <asp:Button ID="cmdExcluir" CssClass="btn btn-info" Width="100%" runat="server" Text="Excluir" Font-Bold="True" OnClick="cmdExcluir_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdLimpar" CssClass="btn btn-info" Width="100%" runat="server" Text="Limpar" Font-Bold="True" OnClick="cmdLimpar_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="cmdSair" CssClass="btn btn-info" Width="100%" runat="server" Text="Sair" Font-Bold="True" />
                        </div>
                    </div>
                </div>
            </div>
        </contenttemplate>


    </updatepanel>


    <script>

        function aplicarDataTable() {
            var dt = $('#ContentPlaceHolder1_grwVendedor').DataTable({
                "language": {
                    "lengthMenu": 'Mostrar <select>' +
                        '<option value="5">05</option>' +
                        '<option value="10">10</option>' +
                        '<option value="20">30</option>' +
                        '</select> Operações',
                    "emptyTable": "Nenhum registro encontrado",
                    "search": "Pesquisar Clientes:",
                    "info": "Mostrando página _PAGE_ de _PAGES_",
                    "infoFiltered": "(filtrado _MAX_ do total Alunos)",
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

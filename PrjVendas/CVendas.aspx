<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.Master" AutoEventWireup="true" CodeBehind="CVendas.aspx.cs" Inherits="PrjVendas.CVendas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card efeito_Panel_2">
                <div class="card-header bg-info text-white">
                    Vendas
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <div>
                            <asp:Label ID="lblCliente" runat="server" Text="Cliente"></asp:Label>
                            <asp:DropDownList ID="cboCliente" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div>
                            <asp:Label ID="lblVendedor" runat="server" Text="Vendedor"></asp:Label>
                            <asp:DropDownList ID="cboVendedor" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Label ID="Label1" runat="server" Text="Produto"></asp:Label>
                                <asp:DropDownList ID="cboProduto" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="cboProduto_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="lblQtdVenda" runat="server" Text="Qtd Venda"></asp:Label>
                                <asp:TextBox ID="txtQtdVenda" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtQtdVenda_TextChanged"></asp:TextBox>

                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="lblValorProduto" runat="server" Text="Valor Produto"></asp:Label>
                                <asp:TextBox ID="txtValorProduto" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="lblValorTotal" runat="server" Text="Valor Total "></asp:Label>
                                <asp:TextBox ID="txtValortotal" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                            </div>
                            <div class="col-md-2 mt-2">
                                <asp:Button ID="cmdAdicionarProduto" runat="server" Text="Adicionar Produto" CssClass="form-control mt-3 btn btn-info" OnClick="cmdAdicionarProduto_Click" />
                            </div>
                            <div>
                                <asp:Label ID="lblItensVenda" runat="server" Text="ItensVenda"></asp:Label>
                                <asp:GridView ID="grwVendas" runat="server" AutoGenerateColumns="true">
                                    <Columns>
                                    </Columns>
                                    <SelectedRowStyle BackColor="Yellow" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        function pageLoad() {
            $('#' + '<%=cboCliente.ClientID%>').select2();
            $('#' + '<%=cboVendedor.ClientID%>').select2();
            $('#' + '<%=cboProduto.ClientID%>').select2();
        }
    </script>
</asp:Content>

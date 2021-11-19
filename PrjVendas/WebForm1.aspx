<%@ Page Title="" Language="C#" MasterPageFile="~/MasterP.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PrjVendas.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <%--<link href="Content/NavBar21.css" rel="stylesheet" />--%>
    <link href="Content/NavBar3.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.21/css/jquery.dataTables.min.css">
    <%--<link href="Content/fontawesome-all.min.css" rel="stylesheet" />--%>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="css/daterangepicker.css" rel="stylesheet" />
    <link href="Content/fontawesome.min.css" rel="stylesheet" />

    <style type="text/css">
        html, body {
            height: 100%;
        }

        #principal {
            padding-top: 5px; /*padding for navbar*/
        }

        .dropdown-submenu {
            position: relative;
        }

            .dropdown-submenu > a:after {
                content: "\f0da";
                float: right;
                border: none;
                font-family: 'FontAwesome';
            }

            .dropdown-submenu > .dropdown-menu {
                top: 0;
                left: 100%;
                margin-top: 0px;
                margin-left: 0px;
            }
    </style>
    <link href="Scripts/sidebars.css" rel="stylesheet" />
    <script src="Scripts/sidebars.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

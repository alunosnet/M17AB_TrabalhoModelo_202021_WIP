<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="RemoverUtilizador.aspx.cs" Inherits="M17AB_TrabalhoModelo_202021_WIP.Admin.Utilizadores.RemoverUtilizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Apagar utilizador</h2>
    <br />Email:<asp:Label ID="lbEmail" runat="server" Text="Label"></asp:Label>
    <br />Nome:<asp:Label ID="lbNome" runat="server" Text="Label"></asp:Label>
    <br /><asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
    <br /><asp:Button OnClick="Button1_Click" CssClass="bnt badge-danger" ID="Button1" runat="server" Text="Remover" />
    <asp:Button CssClass="btn btn-info" ID="Button2" runat="server" Text="Voltar"
        PostBackUrl="~/Admin/Utilizadores/Utilizadores.aspx"/>
</asp:Content>

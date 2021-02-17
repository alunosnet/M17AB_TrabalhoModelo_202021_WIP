<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="M17AB_TrabalhoModelo_202021_WIP.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Login-->
    <div runat="server" id="divLogin">
        Email:<asp:TextBox ID="tbEmail" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
        Password:<asp:TextBox ID="tbPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
        <asp:Button CssClass="btn btn-info" ID="btLogin" runat="server" Text="Login" OnClick="btLogin_Click" />
        <asp:Button CssClass="btn btn-danger" ID="btRecuperar" runat="server" Text="Recuperar password" OnClick="btRecuperar_Click" />
    </div>
    <!--Pesquisa-->

    <!--Lista dos livros-->

</asp:Content>
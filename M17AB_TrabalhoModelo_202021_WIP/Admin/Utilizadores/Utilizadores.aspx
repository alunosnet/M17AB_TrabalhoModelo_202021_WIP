<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="Utilizadores.aspx.cs" Inherits="M17AB_TrabalhoModelo_202021_WIP.Admin.Utilizadores.Utilizadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Utilizadores</h2>
    <asp:GridView CssClass="table" ID="gvUtilizadores" runat="server"></asp:GridView>
    <h2>Adicionar utilizador</h2>
    Email:<asp:TextBox CssClass="form-control" MaxLength="100" TextMode="Email" ID="tbEmail" runat="server"></asp:TextBox>
    <br />Nome:<asp:TextBox CssClass="form-control" MaxLength="100" ID="tbNome" runat="server"></asp:TextBox>
    <br />Morada:<asp:TextBox CssClass="form-control" MaxLength="100" ID="tbMorada" runat="server"></asp:TextBox>
    <br />Nif:<asp:TextBox CssClass="form-control" MaxLength="9" ID="tbNif" runat="server"></asp:TextBox>
    <br />Palavra passe:<asp:TextBox CssClass="form-control" TextMode="Password" ID="tbPassword" runat="server"></asp:TextBox>
    <br />Perfil:
    <asp:DropDownList CssClass="form-control" ID="ddPerfil" runat="server">
        <asp:ListItem Value="0">Administrador</asp:ListItem>
        <asp:ListItem Value="1">Utilizador</asp:ListItem>
    </asp:DropDownList>
    <br /><asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
    <br /><asp:Button CssClass="btn btn-lg btn-danger" OnClick="Button1_Click" ID="Button1" runat="server" Text="Adicionar" />
</asp:Content>

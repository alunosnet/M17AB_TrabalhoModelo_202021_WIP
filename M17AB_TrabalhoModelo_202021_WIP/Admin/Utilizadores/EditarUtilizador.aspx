<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="EditarUtilizador.aspx.cs" Inherits="M17AB_TrabalhoModelo_202021_WIP.Admin.Utilizadores.EditarUtilizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Editar utilizador</h2>
    <br />Nome:<asp:TextBox CssClass="form-control" MaxLength="100" ID="tbNome" runat="server"></asp:TextBox>
    <br />Morada:<asp:TextBox CssClass="form-control" MaxLength="100" ID="tbMorada" runat="server"></asp:TextBox>
    <br />Nif:<asp:TextBox CssClass="form-control" MaxLength="9" ID="tbNif" runat="server"></asp:TextBox>
    <br /><asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
    <br /><asp:Button OnClick="Button1_Click" CssClass="btn btn-lg btn-danger" ID="Button1" runat="server" Text="Atualizar" />

</asp:Content>

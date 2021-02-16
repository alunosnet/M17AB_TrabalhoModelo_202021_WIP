<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="RemoverLivro.aspx.cs" Inherits="M17AB_TrabalhoModelo_202021_WIP.Admin.Livros.RemoverLivro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Apagar livro</h1>
    Nº Livro: <asp:Label runat="server" ID="lbNlivro" /><br />
    Nome: <asp:Label runat="server" ID="lbNome" /><br />
    Capa: <asp:Image runat="server" ID="imgCapa" Width="200" /><br />
    <asp:Label runat="server" ID="lbErro" /><br />
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btRemover" Text="Remover"
        OnClick="btRemover_Click" />
    <asp:Button CssClass="btn btn-lg btn-info" runat="server" ID="btCancelar" Text="Voltar"
        PostBackUrl="~/Admin/Livros/Livros.aspx" />
</asp:Content>

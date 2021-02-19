<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="Emprestimos.aspx.cs" Inherits="M17AB_TrabalhoModelo_202021_WIP.User.Emprestimos.Emprestimos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Reserva livro</h2>
    <asp:GridView CssClass="table" ID="gvLivros" runat="server"></asp:GridView>
</asp:Content>

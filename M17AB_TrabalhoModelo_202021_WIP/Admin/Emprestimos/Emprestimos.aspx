<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="Emprestimos.aspx.cs" Inherits="M17AB_TrabalhoModelo_202021_WIP.Admin.Emprestimos.Emprestimos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Empréstimos</h2>
    <asp:CheckBox AutoPostBack="true" OnCheckedChanged="cbEmprestimos_CheckedChanged" CssClass="form-control" ID="cbEmprestimos" runat="server" />
    Só empréstimos por concluir
    <asp:GridView CssClass="table" ID="gvEmprestimos" runat="server"></asp:GridView>
    <h2>Adicionar Empréstimos</h2>
    Livro:<asp:DropDownList CssClass="form-control" ID="ddLivros" runat="server"></asp:DropDownList>
    <br />Utilizador:<asp:DropDownList CssClass="form-control" ID="ddUtilizadores" runat="server"></asp:DropDownList>
    <br />Data devolução:<asp:TextBox TextMode="Date" CssClass="form-control" ID="tbData" runat="server"></asp:TextBox>
    <br /><asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button CssClass="btn btn-danger" ID="Button1" runat="server" Text="Registar" OnClick="Button1_Click" />
</asp:Content>

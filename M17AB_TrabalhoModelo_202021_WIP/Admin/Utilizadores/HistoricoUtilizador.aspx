<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="HistoricoUtilizador.aspx.cs" Inherits="M17AB_TrabalhoModelo_202021_WIP.Admin.Utilizadores.HistoricoUtilizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Histórico</h2>
    <asp:GridView EmptyDataText="Utilizador não empréstimos." CssClass="table" ID="gvHistorico" runat="server"></asp:GridView>
    <br /><asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
    <br /><asp:Button CssClass="btn btn-info" ID="Button1" runat="server" Text="Voltar" PostBackUrl="~/Admin/Utilizadores/Utilizadores.aspx" />
</asp:Content>

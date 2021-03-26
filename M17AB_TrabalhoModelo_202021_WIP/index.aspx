<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="M17AB_TrabalhoModelo_202021_WIP.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--Login-->
    <div runat="server" id="divLogin" class="float-right col-sm-3 table-bordered divLogin" style="z-index:1">
        Email:<asp:TextBox ID="tbEmail" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
        Password:<asp:TextBox ID="tbPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
        <asp:Button CssClass="btn btn-info" ID="btLogin" runat="server" Text="Login" OnClick="btLogin_Click" />
        <asp:Button CssClass="btn btn-danger" ID="btRecuperar" runat="server" Text="Recuperar password" OnClick="btRecuperar_Click" />
    </div>
    <!--Pesquisa-->
    <div class="col-sm-8">
        <h1>Livros Online</h1>
        <div class="float-left col-sm-8 input-group">
            <asp:TextBox CssClass="form-control" ID="tbPesquisa" runat="server"></asp:TextBox>
            <span class="input-group-btn">
                <asp:Button CssClass="btn btn-info" runat="server" ID="btPesquisar" Text="Pesquisar" OnClick="btPesquisar_Click" />
            </span>
        </div>
    </div>
    <!--Lista dos livros-->
    <div class="float-left col-md-8 m-1" id="divLivros" runat="server"></div>
</asp:Content>
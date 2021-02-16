<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="EditarLivro.aspx.cs" Inherits="M17AB_TrabalhoModelo_202021_WIP.Admin.Livros.EditarLivro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Editar livro</h2>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbNome"> Nome:</label>
        <asp:TextBox MaxLength="100" placeholder="Nome do livro" CssClass="form-control" ID="tbNome" runat="server"></asp:TextBox><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbAno">Ano:</label>
        <asp:TextBox TextMode="Number" placeholder="Ano de edição do livro" CssClass="form-control" ID="tbAno" runat="server"></asp:TextBox><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbData">Data aquisição:</label>
        <asp:TextBox CssClass="form-control" ID="tbData" runat="server" TextMode="Date" /><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbPreco">Preço:</label>
        <asp:TextBox TextMode="Number" CssClass="form-control" ID="tbPreco" runat="server"></asp:TextBox><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbAutor">Autor:</label>
        <asp:TextBox MaxLength="100" CssClass="form-control" ID="tbAutor" runat="server"></asp:TextBox><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbTipo">Tipo:</label>
        <asp:TextBox MaxLength="50" CssClass="form-control" ID="tbTipo" runat="server"></asp:TextBox><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_FileUpload1">Capa:</label>
        <asp:Image runat="server" ID="imgCapa" Width="200px" /><br />
        <asp:FileUpload CssClass="form-control-file" ID="FileUpload1" runat="server" /><br />
    </div>
    <asp:Label ID="lbErro" runat="server" /><br />
    <asp:Button CssClass="btn btn-lg btn-danger" ID="bt1" runat="server" Text="Atualizar" OnClick="bt1_Click" />
    <asp:Button CssClass="btn btn-lg btn-info" ID="bt2" runat="server" Text="Voltar" PostBackUrl="~/Admin/Livros/Livros.aspx" />

</asp:Content>

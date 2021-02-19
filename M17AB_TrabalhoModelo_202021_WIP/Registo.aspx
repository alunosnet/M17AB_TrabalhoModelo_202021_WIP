<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="Registo.aspx.cs" Inherits="M17AB_TrabalhoModelo_202021_WIP.Registo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://www.google.com/recaptcha/api.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Email:<asp:TextBox CssClass="form-control" MaxLength="100" TextMode="Email" ID="tbEmail" runat="server"></asp:TextBox>
    <br />Nome:<asp:TextBox CssClass="form-control" MaxLength="100" ID="tbNome" runat="server"></asp:TextBox>
    <br />Morada:<asp:TextBox CssClass="form-control" MaxLength="100" ID="tbMorada" runat="server"></asp:TextBox>
    <br />Nif:<asp:TextBox CssClass="form-control" MaxLength="9" ID="tbNif" runat="server"></asp:TextBox>
    <br />Palavra passe:<asp:TextBox CssClass="form-control" TextMode="Password" ID="tbPassword" runat="server"></asp:TextBox>
    <br /><asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
    <!--Recaptcha-->
    <div class="g-recaptcha" data-sitekey="6Lc1vvoSAAAAAFjyIsG88_b-SoYcW5n89amtzucB"></div>
    <!--Registar-->
    <asp:Button runat="server" ID="btRegistar" Text="Registar"
        CssClass="btn btn-info" OnClick="btRegistar_Click" />
</asp:Content>

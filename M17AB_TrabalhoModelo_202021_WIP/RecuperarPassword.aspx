<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="RecuperarPassword.aspx.cs" Inherits="M17AB_TrabalhoModelo_202021_WIP.RecuperarPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Recuperar palavra passe</h2>
    Nova palavra passe:<asp:TextBox CssClass="form-control" ID="tbPassword" TextMode="Password" runat="server"></asp:TextBox>
    <asp:Button OnClick="btAlterarPassword_Click" ID="btAlterarPassword" CssClass="btn btn-danger" runat="server" Text="Alterar Password" />
    <asp:Label ID="lbErro" runat="server" Text=""></asp:Label>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/master_page.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="M17AB_TrabalhoModelo_202021_WIP.Admin.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Public/chartistJS/chartist.css" rel="stylesheet" />
    <script src="/Public/chartistJS/chartist.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>Admin dashboard</h2>
    <button id="btnlista" class="btn btn-info">Carregar dados</button>
    <button id="btnCriaGrafico" class="btn btn-success">Dados de utilizadores</button>
    <div id="divLista"></div>
    <div class="ct-chart ct-golden-section"></div>
    <script>
        $(document).ready(function () {
            $("#btnlista").on('click', function (e) {
                //alert("btn lista");
                e.preventDefault();
                $.ajax({
                    type: "POST",
                    url: "Servicos.asmx/ListaLivros",
                    contentType: "application/json; charset=utf-8",
                    success: OnSuccess,
                    error: OnError
                });
                function OnError(response) {
                    alert("Alguma coisa errada correu mal");
                }
                function OnSuccess(response) {
                    var listaLivros = JSON.parse(response.d);
                    for (var i = 0; i < listaLivros.length; i++) {
                        $("#divLista").append(listaLivros[i].nome + "<br/>");
                    }
                }
            });
            $("#btnCriaGrafico").on('click', function (e) {
                //alert("btn gráfico");
                var pData = [];
                /*pData[0] = $("#ddlyear").val();*/
                var jsonData = JSON.stringify({ pData: pData });

                $.ajax({
                    type: "POST",
                    url: "Servicos.asmx/DadosUtilizadores",
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess_,
                    error: OnErrorCall_
                });
                function OnSuccess_(response) {
                    var aData = response.d;
                    var arrLabels = [], arrSeries = [];
                    $.map(aData, function (item, index) {
                        arrLabels.push(item.perfil);
                        arrSeries.push(item.contagem);
                    });
                    var data = {
                        labels: arrLabels,
                        series: arrSeries
                    }
                    // This is themain part, where we set data and create PIE CHART
                    new Chartist.Pie('.ct-chart', data);
                }

                function OnErrorCall_(response) {
                    alert("Whoops something went wrong!");
                    console.log(response);
                }
                e.preventDefault();
            });
        });
    </script>
</asp:Content>

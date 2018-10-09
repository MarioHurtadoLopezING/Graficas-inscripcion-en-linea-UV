<%@ Page Title="" Language="C#" MasterPageFile="~/App/interfazGrafica/Encabezado.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GraficasILinea.App.interfazGrafica.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #seleccion_periodo {
            width: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js"></script>
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <div id ="combos">
    </div>

    <script src="../Scripts/default.js"></script>
     

</asp:Content>

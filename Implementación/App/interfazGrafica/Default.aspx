<%@ Page Title="" Language="C#" MasterPageFile="~/App/interfazGrafica/Encabezado.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GraficasILinea.App.interfazGrafica.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/Chart.min.js"></script>
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <div id ="combos">
   </div>
        <div id ="graficas">

        </div>
    
    <script src="../Scripts/Graficas.js"></script>
    <script src="../Scripts/default.js"></script>
</asp:Content>

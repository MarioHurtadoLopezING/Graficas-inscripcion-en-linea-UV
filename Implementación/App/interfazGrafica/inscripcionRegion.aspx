<%@ Page Title="" Language="C#" MasterPageFile="~/App/interfazGrafica/Encabezado.Master" AutoEventWireup="true" CodeBehind="inscripcionRegion.aspx.cs" Inherits="GraficasILinea.App.interfazGrafica.inscripcionRegion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
   
    
    <div id="combo">
		<label>Días de inscripción:</label>
		<select  id="comboDiasInscripcion">
		</select>
	</div>
	<div id="divCanvas">
		<h4 id="lblPeriodoInscripcion">hola mundo</h4>
		<canvas id="canvas">
		</canvas>
		<div class="imagenesSeleccion">
			<img id="pastel" src="../recursosGraficos/chart-pie.png"/>
			<img id="barra" src="../recursosGraficos/graficas.png"/>
			<img id="linea" src="../recursosGraficos/vector.png"/>
		</div>
	</div>
    <div id="tabla">
		<table id="tab">
		</table>
	</div>
    <script src="../Scripts/Graficas.js"></script>
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/tablaEstadisticas.js"></script>
     <script src="../Scripts/inscripcionRegion.js"></script>
    <script src="../Scripts/Chart.min.js"></script>
</asp:Content>

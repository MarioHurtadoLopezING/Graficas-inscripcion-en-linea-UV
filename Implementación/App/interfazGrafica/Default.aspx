<%@ Page Title="" Language="C#" MasterPageFile="~/App/interfazGrafica/Encabezado.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GraficasILinea.App.interfazGrafica.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Scripts/Chart.min.js"></script>
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <link href="Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    
    <div id="combo">
		<label>Consultar por:</label>
		<select>
			<option>PERIODO COMPLETO</option>
            <option>INTERSEMESTRAL</option>
		</select>
		<label>Periodo:</label>
		<select id="comboPeriodos">
		</select>
	</div>
	<div id="divCanvas">
		<h4 id="lblPeriodoInscripcion"></h4>
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
    <script src="../Scripts/tablaEstadisticas.js"></script>
    <script src="../Scripts/default.js"></script>
</asp:Content>

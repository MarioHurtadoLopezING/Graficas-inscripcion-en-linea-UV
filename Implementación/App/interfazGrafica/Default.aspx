<%@ Page Title="" Language="C#" MasterPageFile="~/App/interfazGrafica/Encabezado.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GraficasILinea.App.interfazGrafica.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <div id="divContenidoPagina">
		<div id="divCombos">
			<label>Consultar por:</label>
			<select>
				<option>PERIODO COMPLETO</option>
			</select>
			<label>Periodo:</label>
			<select id="comboPeriodos">
			</select>
		</div>
		<div>
			<div id="divCanvasGrafica">
				<center><h4 id="tituloGrafica"></h4></center>
				<div id ="divGrafica">
                    <canvas id="canvasGrafica">
				    </canvas>	
				</div>
				<div class="imagenesSeleccion">
					<img id="pastel" src="../recursosGraficos/chart-pie.png"/>
					<img id="barra" src="../recursosGraficos/graficas.png"/>
					<img id="linea" src="../recursosGraficos/vector.png"/>
				</div>
			</div>
		</div>
		<div id="divTablaEstadistica">
			<center>
				<table id="tabla">
				</table>
			</center>
		</div>
	</div>
   <script src="../Scripts/recursos/Graficas.js"></script>
    <script src="../Scripts/recursos/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/recursos/Chart.min.js"></script>
    <script src="../Scripts/recursos/tablaEstadisticas.js"></script>
    <script src="../Scripts/default.js"></script>
</asp:Content>

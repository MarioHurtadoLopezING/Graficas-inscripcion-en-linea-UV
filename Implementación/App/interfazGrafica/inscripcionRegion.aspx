<%@ Page Title="" Language="C#" MasterPageFile="~/App/interfazGrafica/Encabezado.Master" AutoEventWireup="true" CodeBehind="inscripcionRegion.aspx.cs" Inherits="GraficasILinea.App.interfazGrafica.inscripcionRegion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="Styles/css/bootstrap.min.css">
    <script src="../Scripts/js/jquery.min.js"></script>
    <script src="../Scripts/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Styles/inscripcionRegion.css" />
  
    <div id="divContenidoPagina">
		<div id="divCombos">
            <label>Días de inscripción:</label>
            <select id="comboDiasInscripcion">
			</select>       
             <button type="button" id="btnPeriodo" data-toggle="modal" data-target="#myModal">Seleccionar periodo</button>
		</div>
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title">Periodo inscripción</h1>
                    </div>
                    <div class="modal-body">
                        <center>
                            <label class="fuente">Periodo</label>
                            <select class="fuente" id="comboPeriodos">
                            </select>
                        </center>
                    </div>
                    <div class="modal-footer">
                        <center>
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        </center>
                    </div>
                </div>
            </div>
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
    <script src="../Scripts/inscripcionRegion.js"></script>
</asp:Content>
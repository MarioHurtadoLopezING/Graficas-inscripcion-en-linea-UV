<%@ Page Title="" Language="C#" MasterPageFile="~/App/interfazGrafica/Encabezado.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GraficasILinea.App.interfazGrafica.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/estilosDefault.css" rel="stylesheet" type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js"></script>
    <div id="div_tipoInscripcion">
        <label>Tipo inscripción:</label>
        <select name="Inscripción" id="seleccion_insripcion">
            <option>Periodo completo</option>
            <option>Intersemestral</option>
        </select>
    </div>
    <div id="div_periodoInscripcion">
        <label>Periodo:</label>
        <select name="seleccion_periodo" id="seleccion_periodo">
            <option>""</option>
            <option>""</option>
        </select>
    </div>
    <div>
        <div><canvas id="graficaGeneral" width="600" height="400"></canvas></div>
    <table id="tablaRegistro">
      <tr>
          <!--esta tabla se puede crear dinamicamente-->
        <th>Dia</th>
        <th>Lugares sorteados</th>
        <th>Lugares inscritos</th>
        <th>total %</th>
      </tr>
      <tr>
        <td>""</td>
        <td>""</td>
        <td>""</td>
        <td>""</td>
      </tr>
      <tr>
        <td>""</td>
        <td>""</td>
        <td>""</td>
        <td>""</td>
      </tr>
      <tr>
        <td>""</td>
        <td>""</td>
        <td>""</td>
        <td>""</td>
      </tr>
        <tr>
        <td>""</td>
        <td>""</td>
        <td>""</td>
        <td>""</td>
      </tr>
    </table>
        </div>
    <!--aqui-->
    <div class="container">
        
    </div>
     
    <script src="../Scripts/Graficas.js"></script>
</asp:Content>

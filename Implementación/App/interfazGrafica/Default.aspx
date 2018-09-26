<%@ Page Title="" Language="C#" MasterPageFile="~/App/interfazGrafica/Encabezado.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GraficasILinea.App.interfazGrafica.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #seleccion_periodo {
            width: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Styles/estilosDefault.css" rel="stylesheet" type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js"></script>
    <div id="div_tipoInscripcion">
        <label>Tipo inscripción:</label>&nbsp;
    </div>
    <div id="div_periodoInscripcion">
        <asp:DropDownList ID="DropDownList1" runat="server" Height="28px" Width="204px">
        </asp:DropDownList>
        <label>Periodo:</label>&nbsp;
    </div>
    <div>
        <div><canvas id="graficaGeneral" width="600" height="400"></canvas></div>
        </div>
   <!-- <table id="tablaRegistro1">
      <tr>
          <!--esta tabla se puede crear dinamicamente
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
        
        <asp:DropDownList ID="DropDownList2" runat="server" Height="19px" Width="175px">
        </asp:DropDownList>
        
    </div>
     
    <script src="../Scripts/Graficas.js"></script>
</asp:Content>

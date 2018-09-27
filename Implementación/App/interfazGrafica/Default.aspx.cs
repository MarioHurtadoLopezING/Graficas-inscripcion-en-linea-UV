using GraficasILinea.App.accesoDatos;
using GraficasILinea.App.entidades;
using GraficasILinea.App.logicaNegocio.entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GraficasILinea.App.interfazGrafica
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.DataTextField = "FieldName";
            DropDownList1.DataValueField = "FieldName";
            DropDownList1.DataBind();

            this.mostrarDatos();
            // new DiaInscripcionDAOSql().ObtenerDiasInscripcion("");
            
        }

        public void mostrarDatos()
        {
            List<DiaInscripcion> diasInscripcion = new DiaInscripcion().obtenerDias("");
            StringBuilder html = new StringBuilder();
            html.Append("<table id = 'tablaRegistro' border ='1'>");
            html.Append("<tr>");
            foreach (DiaInscripcion dia in diasInscripcion) {
                html.Append("<th>");
                html.Append(dia.getFecha());
                html.Append("</th>");
            }
            html.Append("</tr>");
            html.Append("<tr>");
            foreach (DiaInscripcion dia in diasInscripcion)
            {
                
                html.Append("<td>");
                html.Append(dia.getValor());
                html.Append("</td>");
                
            }
            html.Append("</tr>");
            html.Append("</table>");
            this.Controls.Add(new Literal { Text = html.ToString() });

        }

       
    }
}
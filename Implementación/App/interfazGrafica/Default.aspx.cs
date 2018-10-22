using GraficasILinea.App.accesoDatos;
using GraficasILinea.App.entidades;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GraficasILinea.App.interfazGrafica
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static string getPeriodosEducativos() {
            List<PeriodoEducativo> periodos = new PeriodoEducativo().obtenerPeriodosEducativos();
            var jsonList = JsonConvert.SerializeObject(periodos);
            return jsonList;
        }
        [System.Web.Services.WebMethod]
        public static String getDiasInscripcion(String fecha) {
            var jsonList = "";
            try
            {
                List<InscripcionGeneral> inscripciones = new InscripcionGeneral().obtenerDiasInscripcion(fecha);
                jsonList = JsonConvert.SerializeObject(inscripciones);
            }
            catch (SqlException ex) {
                jsonList = "error";
            }
            return jsonList;
        }
    }
}
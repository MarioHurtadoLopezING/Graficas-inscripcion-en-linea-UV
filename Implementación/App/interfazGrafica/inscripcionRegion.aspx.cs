using GraficasILinea.App.accesoDatos;
using GraficasILinea.App.entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GraficasILinea.App.interfazGrafica
{
    public partial class inscripcionRegion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        [System.Web.Services.WebMethod]
        public static string getRegionesInscripcion(String periodoInscripcion) {
            List<Region> regiones = new Region().obtenerRegionesInscripcion(periodoInscripcion);
            var jsonList = JsonConvert.SerializeObject(regiones);
            return jsonList;
        }
        [System.Web.Services.WebMethod]
        public static string getDiasInscripcion(String periodoEducativo) {
            List<PeriodoEducativo> diasInscripcion = new PeriodoEducativo().ObtenerDiasInscripcion(periodoEducativo);
            var jsonList = JsonConvert.SerializeObject(diasInscripcion);
            return jsonList;
        }
        [System.Web.Services.WebMethod]
        public static string getRegionesInscripcionDia(String fecha, String periodoEducativo) {
            List<Region> regiones = new Region().ObtenerRegionesInscripcionDia(fecha, periodoEducativo);
            var jsonList = JsonConvert.SerializeObject(regiones);
            return jsonList;
        }
    }
}
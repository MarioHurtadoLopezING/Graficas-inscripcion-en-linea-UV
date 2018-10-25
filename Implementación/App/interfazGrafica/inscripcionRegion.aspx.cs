using GraficasILinea.App.entidades;
using Newtonsoft.Json;
using System;

namespace GraficasILinea.App.interfazGrafica
{
    public partial class inscripcionRegion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        [System.Web.Services.WebMethod]
        public static string getRegionesInscripcion(String periodoInscripcion) {
            return JsonConvert.SerializeObject(new Region().getRegionesInscripcion(periodoInscripcion)); 
        }
        [System.Web.Services.WebMethod]
        public static string getDiasInscripcion(String periodoEducativo) {
            return JsonConvert.SerializeObject(new PeriodoEducativo().ObtenerDiasInscripcion(periodoEducativo));
        }
        [System.Web.Services.WebMethod]
        public static string getRegionesInscripcionDia(String fecha, String periodoEducativo) {
            return JsonConvert.SerializeObject(new Region().getRegionesInscripcionDia(fecha, periodoEducativo));
        }
    }
}
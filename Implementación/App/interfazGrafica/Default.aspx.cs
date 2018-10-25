using GraficasILinea.App.entidades;
using Newtonsoft.Json;
using System;

namespace GraficasILinea.App.interfazGrafica
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        [System.Web.Services.WebMethod]
        public static string getPeriodosEducativos() {
            return JsonConvert.SerializeObject(new PeriodoEducativo().obtenerPeriodosEducativos());
        }
        [System.Web.Services.WebMethod]
        public static String getDiasInscripcion(String fecha) {
            return JsonConvert.SerializeObject(new InscripcionGeneral().obtenerDiasInscripcion(fecha));
        }
    }
}
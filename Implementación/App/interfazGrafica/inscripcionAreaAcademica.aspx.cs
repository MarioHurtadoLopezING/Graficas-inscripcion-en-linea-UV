using GraficasILinea.App.entidades;
using Newtonsoft.Json;
using System;

namespace GraficasILinea.App.interfazGrafica
{
    public partial class inscripcionAreaAcademica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static String getPeriodosEducativos()
        {
            return JsonConvert.SerializeObject(new PeriodoEducativo().obtenerPeriodosEducativos());
        }
        [System.Web.Services.WebMethod]
        public static String getAreasAcademicas(string periodoInscripcion)
        {
            return JsonConvert.SerializeObject(new AreaAcademica().getAreasAcademicas(periodoInscripcion));
        }
        [System.Web.Services.WebMethod]
        public static String getRegiones(string periodoInscripcion)
        {
            return JsonConvert.SerializeObject(new Region().getRegionesInscripcion(periodoInscripcion));
        }
        [System.Web.Services.WebMethod]
        public static string getDiasInscripcion(String periodoEducativo)
        {
            return JsonConvert.SerializeObject(new PeriodoEducativo().ObtenerDiasInscripcion(periodoEducativo));
        }
        [System.Web.Services.WebMethod]
        public static String getAreasAcademicasPorRegion(string periodoInscripcion, int idRegion)
        {
            return JsonConvert.SerializeObject(new AreaAcademica().getAreasAcademicas(periodoInscripcion, idRegion));
        }
        
        [System.Web.Services.WebMethod]
        public static String getAreasAcademicasPorRegionYFecha(string periodoInscripcion, String fecha, int idRegion)
        {
            return JsonConvert.SerializeObject(new AreaAcademica().getAreasAcademicas(periodoInscripcion, fecha, idRegion));
        }        
    }
}
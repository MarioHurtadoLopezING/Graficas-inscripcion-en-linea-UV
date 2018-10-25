using GraficasILinea.App.entidades;
using Newtonsoft.Json;
using System;

namespace GraficasILinea.App.interfazGrafica
{
    public partial class inscripcionAreaAcademica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getAreasAcademicas();
        }
        [System.Web.Services.WebMethod]
        public static String getAreasAcademicas(string periodoInscripcion)
        {
            return JsonConvert.SerializeObject(new AreaAcademica().getAreasAcademicas("201801|"));
        }
        [System.Web.Services.WebMethod]
        public static String getAreasAcademicas()//(string periodoInscripcion, String fecha, int idRegion)
        {
            return JsonConvert.SerializeObject(new AreaAcademica().getAreasAcademicas("201901|MP", "20180521", 1));
        }
    }
}
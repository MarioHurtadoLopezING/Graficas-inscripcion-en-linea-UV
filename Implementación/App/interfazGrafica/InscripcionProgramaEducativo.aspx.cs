using GraficasILinea.App.entidades;
using Newtonsoft.Json;
using System;

namespace GraficasILinea.App.interfazGrafica
{
    public partial class InscripcionProgramaEducativo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        [System.Web.Services.WebMethod]
        public static String getProgramasEducativos(String periodoInscripcion)
        {
            return JsonConvert.SerializeObject(new ProgramaEducativo().getProgramasEducativos(periodoInscripcion));
        }
        [System.Web.Services.WebMethod]
        public static String getAreasAcademicas(string periodoInscripcion)
        {
            return JsonConvert.SerializeObject(new AreaAcademica().getAreasAcademicas(periodoInscripcion));
        }
        [System.Web.Services.WebMethod]
        public static String getProgramasEducativosPeriodoYArea(String periodoInscripcion, int idAreaAcademica)
        {
            return JsonConvert.SerializeObject(new ProgramaEducativo().getProgramasEducativos(periodoInscripcion, idAreaAcademica));
        }    
        [System.Web.Services.WebMethod]
        public static String getProgramasEducativosPorFechaYArea(string periodoInscripcion, int idRegion, int idAreaAcademica, string fecha)
        {
            return JsonConvert.SerializeObject(new ProgramaEducativo().getProgramasEducativos(periodoInscripcion, idRegion, idAreaAcademica, fecha));
        }
    }
}
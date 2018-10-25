using GraficasILinea.App.entidades;
using Newtonsoft.Json;
using System;

namespace GraficasILinea.App.interfazGrafica
{
    public partial class InscripcionProgramaEducativo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getProgramasEducativos("201901|MP",1,1, "20180521");
        }
        [System.Web.Services.WebMethod]
        public static String getProgramasEducativos(String periodoInscripcion)
        {
            return JsonConvert.SerializeObject(new ProgramaEducativo().getProgramasEducativos(periodoInscripcion));
        }
        [System.Web.Services.WebMethod]
        public static String getProgramasEducativos(string periodoInscripcion, int idRegion, int idAreaAcademica, string fecha)
        {
            return JsonConvert.SerializeObject(new ProgramaEducativo().getProgramasEducativos(periodoInscripcion, idRegion, idAreaAcademica, fecha));
        }
    }
}
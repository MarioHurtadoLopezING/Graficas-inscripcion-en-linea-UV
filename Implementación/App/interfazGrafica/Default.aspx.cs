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
            getPeriodosEducativos();
        }
        [System.Web.Services.WebMethod]
        public static string getPeriodosEducativos() {
            List<PeriodoEducativo> periodos = new PeriodoEducativo().obtenerPeriodosEducativos();
            var jsonList = JsonConvert.SerializeObject(periodos);
            return jsonList;
        }
        [System.Web.Services.WebMethod]
        public static String getDiasInscripcion(String fecha) {
            List<InscripcionGeneral> inscripciones = new InscripcionGeneral().obtenerDiasInscripcion(fecha);
            int totalLugaresSoreteados = new InscripcionGeneral().getTotalLugaresSorteados(inscripciones);
            int totalLugaresInscritos = new InscripcionGeneral().getTotalLugaresInscritos(inscripciones);
            double totalPeriodoInscripcion = new InscripcionGeneral().getTotalPeriodoInscripcion(inscripciones);
            foreach (InscripcionGeneral inscripcion in inscripciones) {
                inscripcion.setgetTotalLugaresSorteados(totalLugaresSoreteados);
                inscripcion.setTotalLugaresInscritos(totalLugaresInscritos);
                inscripcion.setTotalPeriodoInscripcion(totalPeriodoInscripcion);
            }
            var jsonList = JsonConvert.SerializeObject(inscripciones);
            return jsonList;
        }
    }
}
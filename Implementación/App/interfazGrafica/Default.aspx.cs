using GraficasILinea.App.accesoDatos;
using GraficasILinea.App.entidades;
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
            /* List<AreaAcademica> areas = new AreaAcademicaDAOSql().obtenerAreasAcademicasInscripcion("201901");//.obtenerDiasInscripcion("201901");
             int totaLSort = new AreaAcademica().getTotalLugaresSorteados(areas);
             int totaLugInsc = new AreaAcademica().getTotalLugaresInscritos(areas);
             double total = new AreaAcademica().getTotalPeriodoInscripcion(areas);*/
            new PeriodoEducativoDAOSql().obtenerPeriodosEducativos();
        }
    }
}
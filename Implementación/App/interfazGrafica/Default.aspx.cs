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
            List<Region> dias = new RegionDAOSql().obtenerRegionesInscripcion("201901");//.obtenerDiasInscripcion("201901");
           // int totaLSort = new DiaInscripcion().getTotalLugaresSorteados(dias);
            //int totaLugInsc = new DiaInscripcion().getTotalLugaresInscritos(dias);
            //double total = new DiaInscripcion().getTotalPeriodoInscripcion(dias);

        }
    }
}
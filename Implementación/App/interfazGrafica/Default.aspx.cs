using GraficasILinea.App.accesoDatos;
using GraficasILinea.App.logicaNegocio.entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GraficasILinea.App.interfazGrafica
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            new Periodo().obtenerPeriodosIntersesmtral();
        }
    }
}
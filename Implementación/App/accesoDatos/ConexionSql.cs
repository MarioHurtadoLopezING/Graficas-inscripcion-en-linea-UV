using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using System.Data.SqlClient;

namespace GraficasILinea.App.accesoDatos
{
    public class ConexionSql
    {
        private SqlConnection conexion;

        public ConexionSql(){
            this.crearConexion();
        }
        public void crearConexion() {
            try
            {
                conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GraficasSqlServer"].ToString());
                conexion.Open();
            }
            catch (SqlException exception)
            {
                 throw exception;
            }
        }

        public SqlConnection getconexionSql() {
            return this.conexion;
        }

        public void cerrarConexion() {
            conexion.Close();
            conexion.Dispose();
        }
    }
}
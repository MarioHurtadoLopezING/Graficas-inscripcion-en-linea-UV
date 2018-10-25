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
        private SqlConnection conexionSql;

        public ConexionSql(){
            this.crearConexion();
        }
        private void crearConexion() {
            try
            {
                conexionSql = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GraficasSqlServer"].ToString());
                conexionSql.Open();
            }
            catch (SqlException sqlException)
            {
                 throw sqlException;
            }
        }

        public SqlConnection getconexionSql() {
            return this.conexionSql;
        }

        public void cerrarConexion() {
            conexionSql.Close();
            conexionSql.Dispose();
        }
    }
}
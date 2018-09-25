using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraficasILinea.App.logicaNegocio.entidades;
using System.Data.SqlClient;

namespace GraficasILinea.App.accesoDatos
{
    public class PeriodoDAOSql : PeriodoDAO
    {
        public PeriodoDAOSql() {
        }
        /// <summary>
        /// obtener periodos inscripcion
        /// </summary>
        /// <returns></returns>
        public List<Periodo> obtenerPeriodosInscripcion()
        {
            ConexionSql conexionSql = new ConexionSql();
            List<Periodo> listaPeriodos = new List<Periodo>();
            SqlCommand comando = new SqlCommand("PAS_P_IL_PIL", conexionSql.getconexionSql());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@IND_IL_PIL", 1));
            try
            {
                SqlDataReader lector = comando.ExecuteReader();
                int i = 0;
                while (lector.Read())
                {
                    String a = lector["FECHA"].ToString();
                    String b = lector["VALOR"].ToString();
                    listaPeriodos.Add(new Periodo(i, "cualquiera", lector["FECHA"].ToString()));
                    i++;
                }
            }
            catch (Exception e)
            {
                String res = e.StackTrace.ToString();
            }
            finally {
                conexionSql.cerrarConexion();
            }
            return listaPeriodos;
        }
        /// <summary>
        /// Obtener periodos intersemestral
        /// </summary>
        /// <returns></returns>
        public List<Periodo> ontenerPeriodosIntersemestral() {
            List<Periodo> listaPeriodos = new List<Periodo>();
            ConexionSql conexion = new ConexionSql();
            SqlCommand comando = new SqlCommand("PAS_SWBGRIN_per_ofer",conexion.getconexionSql());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                SqlDataReader lector = comando.ExecuteReader();
                int i = 0;
                while (lector.Read()) {
                    String s  = lector["PERIODO"].ToString();
                    listaPeriodos.Add(new Periodo(i, "intersemestral", lector["PERIODO"].ToString()));
                    i++;
                }
            }
            catch (Exception e)
            {
                e.StackTrace.ToString();
            }
            finally
            {
                conexion.cerrarConexion();
            }
            return listaPeriodos;
        }
    }
}

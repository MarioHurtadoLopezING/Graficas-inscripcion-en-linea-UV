using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraficasILinea.App.entidades;
using System.Data.SqlClient;

namespace GraficasILinea.App.accesoDatos
{
    public class PeriodoEducativoDAOSql : PeriodoEducativoDAO
    {
        public List<PeriodoEducativo> obtenerPeriodosEducativos()
        {
            List<PeriodoEducativo> periodosEducativos = new List<PeriodoEducativo>();
            ConexionSql conexion = new ConexionSql();
            SqlCommand comandoSql = new SqlCommand("PAS_P_IL_PIL", conexion.getconexionSql());
            comandoSql.CommandType = System.Data.CommandType.StoredProcedure;
            comandoSql.Parameters.Add(new SqlParameter("@IND_IL_PIL", "2"));
            try
            {
                SqlDataReader lector = comandoSql.ExecuteReader();
                while (lector.Read())
                {
                    if (!lector["FECHA"].ToString().Contains("JUNIO"))
                    {
                        periodosEducativos.Add(new PeriodoEducativo(lector["FECHA"].ToString(), lector["VALOR"].ToString()));
                    }
                }
            }
            catch (SqlException excepcionSql)
            {
                throw excepcionSql;
            }
            finally
            {
                conexion.cerrarConexion();
            }
            return periodosEducativos;
        }
        public List<PeriodoEducativo> ObtenerDiasInscripcion(String periodoEducativo)
        {
            List<PeriodoEducativo> diasInscripcion = new List<PeriodoEducativo>();
            ConexionSql conexionSql = new ConexionSql();
            SqlCommand comandoSql = new SqlCommand("PAS_FECHAS_GRAF",conexionSql.getconexionSql());
            comandoSql.CommandType = System.Data.CommandType.StoredProcedure;
            comandoSql.Parameters.Add(new SqlParameter("@PERIODO", periodoEducativo.Split('|')[0]));
            comandoSql.Parameters.Add(new SqlParameter("@IND_MP", (periodoEducativo.Contains("MP") ? "MP" : "")));
            comandoSql.Parameters.Add(new SqlParameter("@IND_IL_PIL","2"));
            try
            {
                SqlDataReader lector = comandoSql.ExecuteReader();
                while (lector.Read())
                {
                    diasInscripcion.Add(new PeriodoEducativo(lector["FECHA"].ToString(), lector["VALOR"].ToString()));

                }
            }
            catch (SqlException excepcionSql)
            {
                throw excepcionSql;
            }
            finally
            {
                conexionSql.cerrarConexion();
            }

            return diasInscripcion;
        }
    }
}
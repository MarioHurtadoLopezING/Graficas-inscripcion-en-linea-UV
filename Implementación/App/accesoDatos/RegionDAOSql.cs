using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraficasILinea.App.entidades;
using System.Data.SqlClient;

namespace GraficasILinea.App.accesoDatos
{
    public class RegionDAOSql : RegionDAO
    {
        public List<Region> obtenerRegionesInscripcion(string periodoInscripcion)
        {
            List<Region> regionesInscripcion = new List<Region>();
            List<SqlParameter> parametrosSql = new List<SqlParameter>();
            parametrosSql.Add(new SqlParameter("@FECHA", "0"));
            parametrosSql.Add(new SqlParameter("@PERIODO", periodoInscripcion.Split('|')[0]));
            parametrosSql.Add(new SqlParameter("@IND_MP", (periodoInscripcion.Contains("MP") ? "MP" : "")));
            parametrosSql.Add(new SqlParameter("@IND_IL_PIL", "2"));
            ConexionSql conexion = new ConexionSql();
            SqlCommand comandoSql = new SqlCommand("PAS_XREGION", conexion.getconexionSql());
            comandoSql.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter parametro in parametrosSql)
            {
                comandoSql.Parameters.Add(parametro);
            }
            try
            {
                SqlDataReader lector = comandoSql.ExecuteReader();
                while (lector.Read())
                {
                    regionesInscripcion.Add(new Region(lector["NOMBRE"].ToString(), int.Parse(lector["TOTALSORT"].ToString()), int.Parse(lector["TOTALINSC"].ToString())));
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
            return regionesInscripcion;
        }
        public List<Region> ObtenerRegionesInscripcionDia (String fecha, String periodoInscripcion)
        {
            List<Region> regionesInscripcion = new List<Region>();
            List<SqlParameter> parametrosSql = new List<SqlParameter>();
            parametrosSql.Add(new SqlParameter("@FECHA", fecha));
            parametrosSql.Add(new SqlParameter("@PERIODO", periodoInscripcion.Split('|')[0]));
            parametrosSql.Add(new SqlParameter("@IND_MP", (periodoInscripcion.Contains("MP") ? "MP" : "")));
            parametrosSql.Add(new SqlParameter("@IND_IL_PIL", "2"));
            ConexionSql conexion = new ConexionSql();
            SqlCommand comandoSql = new SqlCommand("PAS_XREGION", conexion.getconexionSql());
            comandoSql.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter parametro in parametrosSql)
            {
                comandoSql.Parameters.Add(parametro);
            }
            try
            {
                SqlDataReader lector = comandoSql.ExecuteReader();
                while (lector.Read())
                {
                    regionesInscripcion.Add(new Region(lector["NOMBRE"].ToString(), int.Parse(lector["TOTALSORT"].ToString()), int.Parse(lector["TOTALINSC"].ToString())));
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
            return regionesInscripcion;
        }
    }
}
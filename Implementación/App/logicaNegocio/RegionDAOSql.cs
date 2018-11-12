using System;
using System.Collections.Generic;
using GraficasILinea.App.entidades;
using System.Data.SqlClient;

namespace GraficasILinea.App.accesoDatos
{
    public class RegionDAOSql : RegionDAO
    {
        /// <summary>
        /// Método publico de tipo List<> que regresa un conjunto de regiones que tengan registrado una estadistica de
        /// inscripción a partir de un periodo
        /// </summary>
        /// <param name="periodoInscripcion"> Parametro de tipo string que representa un periodo de inscripción</param>
        /// <returns></returns>
        public List<Region> getRegionesInscripcionPorPeriodo(string periodoInscripcion)
        {
            List<SqlParameter> parametrosSql = new List<SqlParameter>();
            parametrosSql.Add(new SqlParameter("@FECHA", "0"));
            parametrosSql.Add(new SqlParameter("@PERIODO", periodoInscripcion.Split('|')[0]));
            parametrosSql.Add(new SqlParameter("@IND_MP", (periodoInscripcion.Contains("MP") ? "MP" : "")));
            parametrosSql.Add(new SqlParameter("@IND_IL_PIL", "2"));
            return this.obtenerEntidades(parametrosSql);
        }
        /// <summary>
        /// Método publico de tipo List<Region> 
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="periodoInscripcion"></param>
        /// <returns></returns>
        public List<Region> getRegionesInscripcionPorPeriodoYFecha(String fecha, String periodoInscripcion)
        {
            List<SqlParameter> parametrosSql = new List<SqlParameter>();
            parametrosSql.Add(new SqlParameter("@FECHA", fecha));
            parametrosSql.Add(new SqlParameter("@PERIODO", periodoInscripcion.Split('|')[0]));
            parametrosSql.Add(new SqlParameter("@IND_MP", (periodoInscripcion.Contains("MP") ? "MP" : "")));
            parametrosSql.Add(new SqlParameter("@IND_IL_PIL", "2"));
            return this.obtenerEntidades(parametrosSql);
        }

        private List<Region> obtenerEntidades(List<SqlParameter> parametrosSql) {
            List<Region> regionesInscripcion = new List<Region>();
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
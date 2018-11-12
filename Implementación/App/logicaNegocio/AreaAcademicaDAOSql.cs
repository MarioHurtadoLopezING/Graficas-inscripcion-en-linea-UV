using System;
using System.Collections.Generic;
using GraficasILinea.App.entidades;
using System.Data.SqlClient;

namespace GraficasILinea.App.accesoDatos
{
    public class AreaAcademicaDAOSql : AreaAcademicaDAO
    {
        public List<AreaAcademica> getAreasAcademicas(string periodoInscripcion)
        {
            List<AreaAcademica> areasAcademicas = new List<AreaAcademica>();
            List<SqlParameter> parametrosSql = new List<SqlParameter>();
            parametrosSql.Add(new SqlParameter("@REGION", "0"));
            parametrosSql.Add(new SqlParameter("@FECHA", "0"));
            parametrosSql.Add(new SqlParameter("@PERIODO", periodoInscripcion.Split('|')[0]));
            parametrosSql.Add(new SqlParameter("@IND_MP", (periodoInscripcion.Contains("MP") ? "MP" : "")));
            parametrosSql.Add(new SqlParameter("@IND_IL_PIL", "2"));
            return this.obtenerEntidades(parametrosSql);
        }
        public List<AreaAcademica> getAreasAcademicas(string periodoInscripcion, int idRegion)
        {
            List<AreaAcademica> areasAcademicas = new List<AreaAcademica>();
            List<SqlParameter> parametrosSql = new List<SqlParameter>();
            parametrosSql.Add(new SqlParameter("@REGION", idRegion));
            parametrosSql.Add(new SqlParameter("@FECHA", "0"));
            parametrosSql.Add(new SqlParameter("@PERIODO", periodoInscripcion.Split('|')[0]));
            parametrosSql.Add(new SqlParameter("@IND_MP", (periodoInscripcion.Contains("MP") ? "MP" : "")));
            parametrosSql.Add(new SqlParameter("@IND_IL_PIL", "2"));
            return this.obtenerEntidades(parametrosSql);
        }

        public List<AreaAcademica> getAreasAcademicas(string periodoInscripcion, String fecha, int idRegion)
        {
            List<AreaAcademica> areasAcademicas = new List<AreaAcademica>();
            List<SqlParameter> parametrosSql = new List<SqlParameter>();
            parametrosSql.Add(new SqlParameter("@REGION", idRegion));
            parametrosSql.Add(new SqlParameter("@FECHA", fecha));
            parametrosSql.Add(new SqlParameter("@PERIODO", periodoInscripcion.Split('|')[0]));
            parametrosSql.Add(new SqlParameter("@IND_MP", (periodoInscripcion.Contains("MP") ? "MP" : "")));
            parametrosSql.Add(new SqlParameter("@IND_IL_PIL", "2"));
            return this.obtenerEntidades(parametrosSql);            
        }
        private List<AreaAcademica> obtenerEntidades(List<SqlParameter> parametrosSql)
        {
            List<AreaAcademica> areasAcademicas = new List<AreaAcademica>();
            ConexionSql conexion = new ConexionSql();
            SqlCommand comandoSql = new SqlCommand("PAS_XREGION_AREA", conexion.getconexionSql());
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
                    String x = lector["NOMBRE"].ToString() + " " + lector["TOTALSORT"].ToString() + " " + lector["TOTALINSC"].ToString();
                    areasAcademicas.Add(new AreaAcademica(lector["NOMBRE"].ToString(), int.Parse(lector["TOTALSORT"].ToString()), int.Parse(lector["TOTALINSC"].ToString())));
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
            return areasAcademicas;
        }
    }
}
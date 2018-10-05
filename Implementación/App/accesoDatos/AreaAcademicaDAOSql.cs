using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraficasILinea.App.entidades;
using System.Data.SqlClient;

namespace GraficasILinea.App.accesoDatos
{
    public class AreaAcademicaDAOSql : AreaAcademicaDAO
    {
        public List<AreaAcademica> obtenerAreasAcademicasInscripcion(string periodoInscripcion)
        {
            List<AreaAcademica> areasAcademicas = new List<AreaAcademica>();
            List<SqlParameter> parametrosSql = new List<SqlParameter>();
            parametrosSql.Add(new SqlParameter("@REGION", "0"));
            parametrosSql.Add(new SqlParameter("@FECHA", "0"));
            parametrosSql.Add(new SqlParameter("@PERIODO", periodoInscripcion));
            parametrosSql.Add(new SqlParameter("@IND_MP", "MP"));
            parametrosSql.Add(new SqlParameter("@IND_IL_PIL", "2"));
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
                    String xz = lector["NOMBRE"].ToString() + " " + lector["TOTALSORT"].ToString() + " " + lector["TOTALINSC"].ToString();
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
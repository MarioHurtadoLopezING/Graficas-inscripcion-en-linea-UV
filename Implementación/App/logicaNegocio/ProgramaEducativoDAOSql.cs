using System.Collections.Generic;
using GraficasILinea.App.entidades;
using System.Data.SqlClient;

namespace GraficasILinea.App.accesoDatos
{
    public class ProgramaEducativoDAOSql : ProgramaEducativoDAO
    {
        public List<ProgramaEducativo> getProgramasEducativos(string periodoInscripcion)
        {
            List<SqlParameter> parametrosSql = new List<SqlParameter>();
            parametrosSql.Add(new SqlParameter("@REGION", "0"));
            parametrosSql.Add(new SqlParameter("@AREA", "0"));
            parametrosSql.Add(new SqlParameter("@FECHA", "0"));
            parametrosSql.Add(new SqlParameter("@PERIODO", periodoInscripcion.Split('|')[0]));
            parametrosSql.Add(new SqlParameter("@IND_MP", (periodoInscripcion.Contains("MP") ? "MP" : "")));
            parametrosSql.Add(new SqlParameter("@IND_IL_PIL", "2"));
            return this.obtenerEntidades(parametrosSql);
        }
        public List<ProgramaEducativo> getProgramasEducativos(string periodoInscripcion, int idAreaAcademica)
        {
            List<SqlParameter> parametrosSql = new List<SqlParameter>();
            parametrosSql.Add(new SqlParameter("@REGION", "0"));
            parametrosSql.Add(new SqlParameter("@AREA", idAreaAcademica));
            parametrosSql.Add(new SqlParameter("@FECHA", "0"));
            parametrosSql.Add(new SqlParameter("@PERIODO", periodoInscripcion.Split('|')[0]));
            parametrosSql.Add(new SqlParameter("@IND_MP", (periodoInscripcion.Contains("MP") ? "MP" : "")));
            parametrosSql.Add(new SqlParameter("@IND_IL_PIL", "2"));
            return this.obtenerEntidades(parametrosSql);
        }
        public List<ProgramaEducativo> getProgramasEducativos(string periodoInscripcion, int idRegion, int idAreaAcademica, string fecha)
        {
            List<SqlParameter> parametrosSql = new List<SqlParameter>();
            parametrosSql.Add(new SqlParameter("@REGION", idRegion));
            parametrosSql.Add(new SqlParameter("@AREA", idAreaAcademica));
            parametrosSql.Add(new SqlParameter("@FECHA", fecha));
            parametrosSql.Add(new SqlParameter("@PERIODO", periodoInscripcion.Split('|')[0]));
            parametrosSql.Add(new SqlParameter("@IND_MP", (periodoInscripcion.Contains("MP") ? "MP" : "")));
            parametrosSql.Add(new SqlParameter("@IND_IL_PIL", "2"));
            return this.obtenerEntidades(parametrosSql);
        }

        private List<ProgramaEducativo> obtenerEntidades(List<SqlParameter> parametrosSql) {
            List<ProgramaEducativo> programasEducativos = new List<ProgramaEducativo>();
            ConexionSql conexion = new ConexionSql();
            SqlCommand comandoSql = new SqlCommand("PAS_XPROGRAMA", conexion.getconexionSql());
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
                    string x = lector["NOMBRE"].ToString()+" "+lector["TOTALSORT"].ToString()+" "+lector["TOTALINSC"].ToString();
                    programasEducativos.Add(new ProgramaEducativo(lector["NOMBRE"].ToString(), int.Parse(lector["TOTALSORT"].ToString()), int.Parse(lector["TOTALINSC"].ToString())));
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
            return programasEducativos;
        }
    }
}
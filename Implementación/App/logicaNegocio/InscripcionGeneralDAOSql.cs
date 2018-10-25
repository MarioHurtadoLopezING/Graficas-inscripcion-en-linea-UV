using System;
using System.Collections.Generic;
using GraficasILinea.App.entidades;
using System.Data.SqlClient;

namespace GraficasILinea.App.accesoDatos
{
    public class InscripcionGeneralDAOSql : InscripcionGeneralDAO
    {
        public List<InscripcionGeneral> getDiasInscripcion(String periodoInscripcion)
        {
            List<InscripcionGeneral> diasInscripcion = new List<InscripcionGeneral>();
            List<SqlParameter> parametrosSql = new List<SqlParameter>();
            parametrosSql.Add(new SqlParameter("@PERIODO", periodoInscripcion.Split('|')[0]));
            parametrosSql.Add(new SqlParameter("@IND_MP", (periodoInscripcion.Contains("MP")?"MP":"")));
            parametrosSql.Add(new SqlParameter("@IND_IL_PIL", "2"));
            ConexionSql conexion = new ConexionSql();
            SqlCommand comandoSql = new SqlCommand("PAS_HISTORICO", conexion.getconexionSql());
            comandoSql.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter parametro in parametrosSql) {
                comandoSql.Parameters.Add(parametro);
            }
            try
            {
                SqlDataReader lector = comandoSql.ExecuteReader();
                while (lector.Read())
                {
                    diasInscripcion.Add(new InscripcionGeneral(lector["NOMBRE"].ToString(), int.Parse(lector["TOTALSORT"].ToString()), int.Parse(lector["TOTALINSC"].ToString())));
                }
            }
            catch (SqlException excepcionSql)
            {
                throw excepcionSql;
            }
            finally {
                conexion.cerrarConexion();
            }
            return diasInscripcion;
        }
    }
}
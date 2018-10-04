using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GraficasILinea.App.entidades;
using System.Data.SqlClient;

namespace GraficasILinea.App.accesoDatos
{
    public class DiaInscripcionDAOSql : DiaInscripcionDAO
    {
        public List<DiaInscripcion> obtenerDiasInscripcion(string periodoInscripcion)
        {
            List<DiaInscripcion> diasInscripcion = new List<DiaInscripcion>();
            List<SqlParameter> parametrosSql = new List<SqlParameter>();
            parametrosSql.Add(new SqlParameter("@PERIODO", periodoInscripcion));//201901 es la fecha como un acronimo acortado
            parametrosSql.Add(new SqlParameter("@IND_MP", "MP"));//MP proceso almacenado? al parecer solo funciona con 2018 - 2019// funciona para obtener la fecha mas actual
            parametrosSql.Add(new SqlParameter("@IND_IL_PIL", "2"));//indice de inscripcion????// ews una constante entonces puede ser un marcador
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
                    //String xz = lector["NOMBRE"].ToString() + " " + lector["TOTALSORT"].ToString() + " " + lector["TOTALINSC"].ToString();
                    diasInscripcion.Add(new DiaInscripcion(lector["NOMBRE"].ToString(), int.Parse(lector["TOTALSORT"].ToString()), int.Parse(lector["TOTALINSC"].ToString())));
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
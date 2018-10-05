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
                    String xz = lector["FECHA"].ToString() + " " + lector["VALOR"].ToString();
                    periodosEducativos.Add(new PeriodoEducativo(lector["FECHA"].ToString(), lector["VALOR"].ToString()));
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
    }
}
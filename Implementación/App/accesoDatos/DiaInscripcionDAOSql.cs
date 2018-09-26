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
        public double calcularPorcentajeTotal(List<DiaInscripcion> diaInscripcion)
        {
            throw new NotImplementedException();
        }

        public List<DiaInscripcion> obtenerDiasInscripcion(string periodoInscripcion)
        {
            ConexionSql conexionSql = new ConexionSql();
            List<DiaInscripcion> diasInscripcion = new List<DiaInscripcion>();
            SqlCommand comando = new SqlCommand("PAS_FECHAS_GRAF",conexionSql.getconexionSql());
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@PERIODO", periodoInscripcion));
            parametros.Add(new SqlParameter("@IND_MP",""));
            parametros.Add(new SqlParameter("@IND_IL_PIL","2"));
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (SqlParameter parametro in parametros) {
                comando.Parameters.Add(parametro);
            }
            try
            {
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    String borrar = lector["FECHA"].ToString() + "--" + lector["VALOR"].ToString();
                    diasInscripcion.Add(new DiaInscripcion(lector["FECHA"].ToString(), lector["VALOR"].ToString()));
                }
            }
            catch (SqlException e)
            {
                e.StackTrace.ToString();
            }
            finally {
                conexionSql.cerrarConexion();
            }
            return diasInscripcion;

        }

        public int obtenerLugaresSorteados(string diaInscripcion)
        {
            throw new NotImplementedException();
        }

        public double obtenerPorcentajeDia(int lugaresSorteados, int lugaresInscritos)
        {
            throw new NotImplementedException();
        }
    }
}
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
            parametros.Add(new SqlParameter("@PERIODO", "201901"));
            parametros.Add(new SqlParameter("@IND_MP","MP"));
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

        public List<DiaInscripcion> obtenerLugaresSorteados(String periodoInscripcion)
        {
            List<DiaInscripcion> diasInscripcion = new List<DiaInscripcion>();

            ConexionSql conexionSql = new ConexionSql();
            SqlCommand comando = new SqlCommand("PAS_HISTORICO",conexionSql.getconexionSql());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("@PERIODO", periodoInscripcion);//"201901"
            comando.Parameters.Add("@IND_MP", "MP");
            comando.Parameters.Add("@IND_IL_PIL", "2");
            try
            {
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    String re = lector["NOMBRE"].ToString() + "--" + int.Parse(lector["TOTALSORT"].ToString()) + "--" + int.Parse(lector["TOTALINSC"].ToString());
                    //lista.Add(new Registro(sqlDrd["NOMBRE"].ToString(), int.Parse(sqlDrd["TOTALSORT"].ToString()), int.Parse(sqlDrd["TOTALINSC"].ToString())));
                }
            }
            catch (SqlException e)
            {
                String ex = e.StackTrace.ToString();
            }
            finally {
                conexionSql.cerrarConexion();
            }
            return diasInscripcion;
        }

        public double obtenerPorcentajeDia(int lugaresSorteados, int lugaresInscritos)
        {
            throw new NotImplementedException();
        }
    }
}
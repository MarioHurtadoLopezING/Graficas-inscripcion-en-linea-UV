using GraficasILinea.App.accesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraficasILinea.App.entidades
{
    public class DiaInscripcion
    {
        private int idDia;
        private int totalSorteado;
        private DateTime fecha;

        public DiaInscripcion(int idDia, int totalSorteado, DateTime fecha) {

        }
        public List<DiaInscripcion> obtenerDias(String periodoInscripcion) {
            return null;// new PeriodoDAOSql().obtenerPeriodosInscripcion(periodoInscripcion);
        }
    }
}
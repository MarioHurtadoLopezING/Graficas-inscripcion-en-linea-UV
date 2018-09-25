using GraficasILinea.App.accesoDatos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraficasILinea.App.logicaNegocio.entidades
{
    public class Periodo
    {
        private int idPeriodo;
        private String tipoInsripcion;
        private String periodoInscripcion;
        private PeriodoDAOSql periodoDao;

        public Periodo() {

        }
        public Periodo(int idPeriodo, String tipoInsripcion, String periodoInscripcion)
        {
            this.idPeriodo = idPeriodo;
            this.tipoInsripcion = tipoInsripcion;
            this.periodoInscripcion = periodoInscripcion;
        }
        public List<Periodo> obtenerPeriodosInscripcion(String tipoInscripcion) {
            return new PeriodoDAOSql().obtenerPeriodosInscripcion();
        }
        public List<Periodo> obtenerPeriodosIntersesmtral() {
            return new PeriodoDAOSql().ontenerPeriodosIntersemestral();
        }
        public String getPeriodoInscripcion() {
            return this.periodoInscripcion;
        }
    }
}
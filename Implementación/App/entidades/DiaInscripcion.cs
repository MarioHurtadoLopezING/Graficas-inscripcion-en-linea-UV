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
        private String fecha;
        private String valor;

        public DiaInscripcion(int idDia, int totalSorteado, String fecha) {

        }
        public DiaInscripcion(String fecha, String valor) {
            this.fecha = fecha;
            this.valor = valor;
        }

        public DiaInscripcion()
        {
        }

        public List<DiaInscripcion> obtenerDias(String periodoInscripcion)
        {
            //turn new DiaInscripcionDAOSql().obtenerDiasInscripcion(periodoInscripcion);
            return new DiaInscripcionDAOSql().obtenerLugaresSorteados("");
        }
        public String getFecha() {
            return this.fecha;
        }
        public String getValor() {
            return this.valor;
        }
    }
}
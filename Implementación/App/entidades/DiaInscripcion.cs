using GraficasILinea.App.accesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraficasILinea.App.entidades
{
    public class DiaInscripcion
    {
        private String fecha;
        private int lugaresSorteados;
        private int lugaresInscritos;
        private int totalLugaresSorteados;
        private int totalLugaresInscritos;
        private double porcentajeTotalPeriodo;
        private double porcentajeDia;

        public DiaInscripcion(String fecha, int lugaresSorteados, int lugaresInscritos) {
            this.fecha = fecha;
            this.lugaresSorteados = lugaresSorteados;
            this.lugaresInscritos = lugaresInscritos;
        }
        public DiaInscripcion(){}
        
        public List<DiaInscripcion> obtenerDiasInscripcion(string periodoInscripcion) {
            List<DiaInscripcion> diasInscripcion = new DiaInscripcionDAOSql().obtenerDiasInscripcion(periodoInscripcion);
            diasInscripcion = this.calcularPorcentajeDia(diasInscripcion);
            return diasInscripcion;
        }

        private List<DiaInscripcion> calcularPorcentajeDia(List<DiaInscripcion> diasInscripcion) {
            double porcentaje = 0.0;
            foreach (DiaInscripcion diaInscripcion in diasInscripcion) {
                porcentaje = diaInscripcion.getLugaresInscritos() * 100;
                porcentaje = porcentaje / diaInscripcion.getLugaresSorteados();
                diaInscripcion.setPorcentajeDia(porcentaje);
            }
            return diasInscripcion;
        }

        public int getTotalLugaresSorteados(List<DiaInscripcion> diasInscripcion) {
            totalLugaresSorteados = 0;
            foreach (DiaInscripcion diaInscripcion in diasInscripcion) {
                totalLugaresSorteados = totalLugaresSorteados + diaInscripcion.getLugaresSorteados();
            }
            return totalLugaresSorteados;
        }

        public int getTotalLugaresInscritos(List<DiaInscripcion> diasInscripcion) {
            totalLugaresInscritos = 0;
            foreach (DiaInscripcion diaInscripcion in diasInscripcion) {
                totalLugaresInscritos = totalLugaresInscritos + diaInscripcion.getLugaresInscritos();
            }
            return totalLugaresInscritos;
        }
        public double getTotalPeriodoInscripcion(List<DiaInscripcion> diasInscripcion) {
            porcentajeTotalPeriodo = getTotalLugaresInscritos(diasInscripcion);
            porcentajeTotalPeriodo = porcentajeTotalPeriodo * 100;
            porcentajeTotalPeriodo = porcentajeTotalPeriodo / getTotalLugaresSorteados(diasInscripcion);
            return porcentajeTotalPeriodo;
        }

        public void setPorcentajeDia(double porcentajeDia) {
            this.porcentajeDia = porcentajeDia;
        }
        public double getPorcentajeDia() {
            return this.porcentajeDia;
        }
        public int getLugaresSorteados() {
            return this.lugaresSorteados;
        }
        public int getLugaresInscritos() {
            return this.lugaresInscritos;
        }
        public String getFecha() {
            return this.fecha;
        }
    }
}
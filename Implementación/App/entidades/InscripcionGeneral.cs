using GraficasILinea.App.accesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraficasILinea.App.entidades
{
    public class InscripcionGeneral
    {
        private String fecha;
        private int lugaresSorteados;
        private int lugaresInscritos;
        private int totalLugaresSorteados;
        private int totalLugaresInscritos;
        private double porcentajeTotalPeriodo;
        private double porcentajeDia;

        public InscripcionGeneral(String fecha, int lugaresSorteados, int lugaresInscritos) {
            this.fecha = fecha;
            this.lugaresSorteados = lugaresSorteados;
            this.lugaresInscritos = lugaresInscritos;
        }
        public InscripcionGeneral(){}
        public List<InscripcionGeneral> obtenerDiasInscripcion(string periodoInscripcion) {
            List<InscripcionGeneral> diasInscripcion = new InscripcionGeneralDAOSql().obtenerDiasInscripcion(periodoInscripcion);
            diasInscripcion = this.calcularPorcentajeDia(diasInscripcion);
            return diasInscripcion;
        }
        private List<InscripcionGeneral> calcularPorcentajeDia(List<InscripcionGeneral> diasInscripcion) {
            double porcentaje = 0.0;
            foreach (InscripcionGeneral diaInscripcion in diasInscripcion) {
                porcentaje = diaInscripcion.getLugaresInscritos() * 100;
                porcentaje = porcentaje / diaInscripcion.getLugaresSorteados();
                diaInscripcion.setPorcentajeDia(porcentaje);
            }
            return diasInscripcion;
        }
        public int getTotalLugaresSorteados(List<InscripcionGeneral> diasInscripcion) {
            totalLugaresSorteados = 0;
            foreach (InscripcionGeneral diaInscripcion in diasInscripcion) {
                totalLugaresSorteados = totalLugaresSorteados + diaInscripcion.getLugaresSorteados();
            }
            return totalLugaresSorteados;
        }
        public int getTotalLugaresInscritos(List<InscripcionGeneral> diasInscripcion) {
            totalLugaresInscritos = 0;
            foreach (InscripcionGeneral diaInscripcion in diasInscripcion) {
                totalLugaresInscritos = totalLugaresInscritos + diaInscripcion.getLugaresInscritos();
            }
            return totalLugaresInscritos;
        }
        public double getTotalPeriodoInscripcion(List<InscripcionGeneral> diasInscripcion) {
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
using GraficasILinea.App.accesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraficasILinea.App.entidades
{
    public class AreaAcademica
    {
        private String nombreAreaAcademica;
        private int lugaresSorteados;
        private int lugaresInscritos;
        private int totalLugaresSorteados;
        private int totalLugaresInscritos;
        private double porcentajeTotalPeriodo;
        private double porcentajeArea;

        public AreaAcademica(String nombreAreaAcademica, int lugaresSorteados, int lugaresInscritos) {
            this.nombreAreaAcademica = nombreAreaAcademica;
            this.lugaresSorteados = lugaresSorteados;
            this.lugaresInscritos = lugaresInscritos;
        }
        public AreaAcademica() { }
        public List<AreaAcademica> obtenerAreasAcademicasInscripcion(string periodoInscripcion)
        {
            List<AreaAcademica> areasAcademicas = new AreaAcademicaDAOSql().obtenerAreasAcademicasInscripcion(periodoInscripcion);
            areasAcademicas = this.calcularPorcentajeArea(areasAcademicas);
            return areasAcademicas;
        }
        private List<AreaAcademica> calcularPorcentajeArea(List<AreaAcademica> areasAcademicas)
        {
            double porcentaje = 0.0;
            foreach (AreaAcademica areaAcademica in areasAcademicas)
            {
                porcentaje = areaAcademica.getLugaresInscritos() * 100;
                porcentaje = porcentaje / areaAcademica.getLugaresSorteados();
                areaAcademica.setPorcentajeArea(porcentaje);
            }
            return areasAcademicas;
        }
        public int getTotalLugaresSorteados(List<AreaAcademica> areasAcademicas)
        {
            totalLugaresSorteados = 0;
            foreach (AreaAcademica areaAcademica in areasAcademicas)
            {
                totalLugaresSorteados = totalLugaresSorteados + areaAcademica.getLugaresSorteados();
            }
            return totalLugaresSorteados;
        }
        public int getTotalLugaresInscritos(List<AreaAcademica> areasAcademicas)
        {
            totalLugaresInscritos = 0;
            foreach (AreaAcademica areasAcademica in areasAcademicas)
            {
                totalLugaresInscritos = totalLugaresInscritos + areasAcademica.getLugaresInscritos();
            }
            return totalLugaresInscritos;
        }
        public double getTotalPeriodoInscripcion(List<AreaAcademica> areasAcademicas)
        {
            porcentajeTotalPeriodo = getTotalLugaresInscritos(areasAcademicas);
            porcentajeTotalPeriodo = porcentajeTotalPeriodo * 100;
            porcentajeTotalPeriodo = porcentajeTotalPeriodo / getTotalLugaresSorteados(areasAcademicas);
            return porcentajeTotalPeriodo;
        }
        public void setPorcentajeArea(double porcentajeArea)
        {
            this.porcentajeArea = porcentajeArea;
        }
        public double getPorcentajeArea()
        {
            return this.porcentajeArea;
        }
        public int getLugaresSorteados()
        {
            return this.lugaresSorteados;
        }
        public int getLugaresInscritos()
        {
            return this.lugaresInscritos;
        }
        public string getAreaAcademica() {
            return this.nombreAreaAcademica;
        }
    }
}
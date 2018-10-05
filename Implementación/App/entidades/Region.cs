using GraficasILinea.App.accesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraficasILinea.App.entidades
{
    public class Region
    {
        private String nombreRegion;
        private int lugaresSorteados;
        private int lugaresInscritos;
        private int totalLugaresSorteados;
        private int totalLugaresInscritos;
        private double porcentajeRegion;
        private double porcentajeTotalRegion;

        public Region() { }
        public Region(String nombreRegion, int lugaresSorteados, int lugaresInscritos) {
            this.nombreRegion = nombreRegion;
            this.lugaresSorteados = lugaresSorteados;
            this.lugaresInscritos = lugaresInscritos;
        }
        public List<Region> obtenerRegionesInscripcion(String periodoInscripcion) {
            List<Region> regionesInscripcion = new RegionDAOSql().obtenerRegionesInscripcion(periodoInscripcion);
            regionesInscripcion = this.calcularPorcentajeRegion(regionesInscripcion);
            return regionesInscripcion;
        }
        private List<Region> calcularPorcentajeRegion(List<Region> regionesInscripcion){
            double porcentaje = 0.0;
            foreach (Region region in regionesInscripcion)
            {
                porcentaje = region.getLugaresInscritos() * 100;
                porcentaje = porcentaje / region.getLugaresSorteados();
                region.setPorcentajeRegion(porcentaje);
            }
            return regionesInscripcion;
        }
        public int getTotalLugaresSorteados(List<Region> regionesInscripcion)
        {
            totalLugaresSorteados = 0;
            foreach (Region region in regionesInscripcion)
            {
                totalLugaresSorteados = totalLugaresSorteados + region.getLugaresSorteados();
            }
            return totalLugaresSorteados;
        }
        public int getTotalLugaresInscritos(List<Region> regionesInscripcion)
        {
            totalLugaresInscritos = 0;
            foreach (Region region in regionesInscripcion)
            {
                totalLugaresInscritos = totalLugaresInscritos + region.getLugaresInscritos();
            }
            return totalLugaresInscritos;
        }
        public double getTotalRegionInscripcion(List<Region> regionesInscripcion)
        {
            porcentajeTotalRegion = getTotalLugaresInscritos(regionesInscripcion);
            porcentajeTotalRegion = porcentajeTotalRegion * 100;
            porcentajeTotalRegion = porcentajeTotalRegion / getTotalLugaresSorteados(regionesInscripcion);
            return porcentajeTotalRegion;
        }
        public void setPorcentajeRegion(double porcentajeRegion) {
            this.porcentajeRegion = porcentajeRegion;
        }
        public int getLugaresSorteados() {
            return this.lugaresSorteados;
        }
        public int getLugaresInscritos() {
            return this.lugaresInscritos;
        }
        public string getNombreRegion()
        {
            return this.nombreRegion;
        }
    }
}
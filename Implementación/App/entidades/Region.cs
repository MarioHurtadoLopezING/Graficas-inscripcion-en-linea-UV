using GraficasILinea.App.accesoDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GraficasILinea.App.entidades
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Region
    {
        [JsonProperty]
        private String nombreRegion;
        [JsonProperty]
        private int lugaresSorteados;
        [JsonProperty]
        private int lugaresInscritos;

        public Region() { }
        public Region(String nombreRegion, int lugaresSorteados, int lugaresInscritos) {
            this.nombreRegion = nombreRegion;
            this.lugaresSorteados = lugaresSorteados;
            this.lugaresInscritos = lugaresInscritos;
        }
        public List<Region> getRegionesInscripcion(String periodoInscripcion) {
            return new RegionDAOSql().getRegionesInscripcionPorPeriodo(periodoInscripcion);
        }
        public List<Region> getRegionesInscripcionDia(String fecha, String periodoInscripcion)
        {
            return new RegionDAOSql().getRegionesInscripcionPorPeriodoYFecha(fecha,periodoInscripcion);
        }
    }
}
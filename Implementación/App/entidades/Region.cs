using GraficasILinea.App.accesoDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public List<Region> obtenerRegionesInscripcion(String periodoInscripcion) {
            return new RegionDAOSql().obtenerRegionesInscripcion(periodoInscripcion);
        }
        public List<Region> ObtenerRegionesInscripcionDia(String fecha, String periodoInscripcion)
        {
            return new RegionDAOSql().ObtenerRegionesInscripcionDia(fecha,periodoInscripcion);
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
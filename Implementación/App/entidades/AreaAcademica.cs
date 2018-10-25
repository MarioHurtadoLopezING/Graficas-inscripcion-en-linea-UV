using GraficasILinea.App.accesoDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GraficasILinea.App.entidades
{
    [JsonObject(MemberSerialization.OptOut)]
    public class AreaAcademica
    {
        [JsonProperty]
        private String nombreAreaAcademica;
        [JsonProperty]
        private int lugaresSorteados;
        [JsonProperty]
        private int lugaresInscritos;

        public AreaAcademica(String nombreAreaAcademica, int lugaresSorteados, int lugaresInscritos) {
            this.nombreAreaAcademica = nombreAreaAcademica;
            this.lugaresSorteados = lugaresSorteados;
            this.lugaresInscritos = lugaresInscritos;
        }
        public AreaAcademica() { }
        public List<AreaAcademica> getAreasAcademicas(string periodoInscripcion) {
            return new AreaAcademicaDAOSql().getAreasAcademicas(periodoInscripcion);
        }
        public List<AreaAcademica> getAreasAcademicas(String periodoInscripcion, String fecha, int idRegion) {
            return new AreaAcademicaDAOSql().getAreasAcademicas(periodoInscripcion,fecha,idRegion);
        }
    }
}
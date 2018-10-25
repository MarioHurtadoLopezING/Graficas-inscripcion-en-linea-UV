using GraficasILinea.App.accesoDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GraficasILinea.App.entidades
{
    [JsonObject(MemberSerialization.OptOut)]
    public class InscripcionGeneral
    {
        [JsonProperty]
        private String fecha;
        [JsonProperty]
        private int lugaresSorteados;
        [JsonProperty]
        private int lugaresInscritos;

        public InscripcionGeneral(String fecha, int lugaresSorteados, int lugaresInscritos) {
            this.fecha = fecha;
            this.lugaresSorteados = lugaresSorteados;
            this.lugaresInscritos = lugaresInscritos;
        }
        public InscripcionGeneral() { }
        public List<InscripcionGeneral> obtenerDiasInscripcion(string periodoInscripcion) {
               return new InscripcionGeneralDAOSql().getDiasInscripcion(periodoInscripcion);
        }
    }
}
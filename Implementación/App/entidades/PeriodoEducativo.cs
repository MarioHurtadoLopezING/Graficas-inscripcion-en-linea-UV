using GraficasILinea.App.accesoDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraficasILinea.App.entidades
{
    [JsonObject(MemberSerialization.OptOut)]
    public class PeriodoEducativo
    {
        [JsonProperty]
        private String fechaRegistro;
        [JsonProperty]
        private String valorRegistro;

        public PeriodoEducativo()
        {
        }
        public PeriodoEducativo(String fechaRegistro, String valorRegistro) {
            this.fechaRegistro = fechaRegistro;
            this.valorRegistro = valorRegistro;
        }
        public String getFechaRegistro() {
            return this.fechaRegistro;
        }
        public String getValorRegistro() {
            return this.valorRegistro;
        }
        public List<PeriodoEducativo> obtenerPeriodosEducativos() {
            return new PeriodoEducativoDAOSql().obtenerPeriodosEducativos();
        }
        public List<PeriodoEducativo> ObtenerDiasInscripcion(String periodoEducativo) {
            return new PeriodoEducativoDAOSql().ObtenerDiasInscripcion(periodoEducativo);
        }
    }
}
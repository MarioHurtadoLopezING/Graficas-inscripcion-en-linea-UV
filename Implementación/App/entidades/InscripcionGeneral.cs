using GraficasILinea.App.accesoDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
            try
            {
                return new InscripcionGeneralDAOSql().obtenerDiasInscripcion(periodoInscripcion);
            }
            catch (SqlException sqlExcepciuon) {
                throw sqlExcepciuon;
            }
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
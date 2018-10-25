using GraficasILinea.App.accesoDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GraficasILinea.App.entidades
{
    [JsonObject(MemberSerialization.OptOut)]
    public class ProgramaEducativo
    {
        [JsonProperty]
        private String nombreProgramaEducativo;
        [JsonProperty]
        private int lugaresSorteados;
        [JsonProperty]
        private int lugaresInscritos;

        public ProgramaEducativo()
        {
        }

        public ProgramaEducativo(String nombreProgramaEducativo, int lugaresSorteados, int lugaresInscritos) {
            this.nombreProgramaEducativo = nombreProgramaEducativo;
            this.lugaresSorteados = lugaresSorteados;
            this.lugaresInscritos = lugaresInscritos;
        }
        public List<ProgramaEducativo> getProgramasEducativos(String periodoInscripcion)
        {
            return new ProgramaEducativoDAOSql().getProgramasEducativos(periodoInscripcion);
        }

        public List<ProgramaEducativo> getProgramasEducativos(string periodoInscripcion, int idRegion, int idAreaAcademica, string fecha)
        {
            return new ProgramaEducativoDAOSql().getProgramasEducativos(periodoInscripcion, idRegion, idAreaAcademica,fecha);
        }
    }
}
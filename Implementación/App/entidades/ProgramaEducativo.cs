using GraficasILinea.App.accesoDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraficasILinea.App.entidades
{
    [JsonObject(MemberSerialization.OptOut)]
    public class ProgramaEducativo
    {
        private String nombreProgramaEducativo;
        private int lugaresSorteados;
        private int lugaresInscritos;

        public ProgramaEducativo(String nombreProgramaEducativo, int lugaresSorteados, int lugaresInscritos) {
            this.nombreProgramaEducativo = nombreProgramaEducativo;
            this.lugaresSorteados = lugaresSorteados;
            this.lugaresInscritos = lugaresInscritos;
        }
        public List<ProgramaEducativo> obtenerProgramasEducativos(String periodoInscripcion)
        {
            return new ProgramaEducativoDAOSql().obtenerProgramasEducativos(periodoInscripcion);
        }
        public int getLugaresSorteados()
        {
            return this.lugaresSorteados;
        }
        public int getLugaresInscritos()
        {
            return this.lugaresInscritos;
        }
        public string getProgramaEducativo()
        {
            return this.nombreProgramaEducativo;
        }
    }
}
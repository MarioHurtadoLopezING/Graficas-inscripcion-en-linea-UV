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

        public AreaAcademica(String nombreAreaAcademica, int lugaresSorteados, int lugaresInscritos) {
            this.nombreAreaAcademica = nombreAreaAcademica;
            this.lugaresSorteados = lugaresSorteados;
            this.lugaresInscritos = lugaresInscritos;
        }
        public AreaAcademica() { }
        public List<AreaAcademica> obtenerAreasAcademicasInscripcion(string periodoInscripcion)
        {
            return new AreaAcademicaDAOSql().obtenerAreasAcademicasInscripcion(periodoInscripcion);
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
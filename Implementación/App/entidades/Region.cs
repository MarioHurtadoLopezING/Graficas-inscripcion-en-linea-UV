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

        public Region() { }
        public Region(String nombreRegion, int lugaresSorteados, int lugaresInscritos) {
            this.nombreRegion = nombreRegion;
            this.lugaresSorteados = lugaresSorteados;
            this.lugaresInscritos = lugaresInscritos;
        }

    }
}
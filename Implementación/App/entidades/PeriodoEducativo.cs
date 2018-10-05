using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraficasILinea.App.entidades
{
    public class PeriodoEducativo
    {
        private String fechaRegistro;
        private String valorRegistro;

        public PeriodoEducativo(String fechaRegistro, String valorRegistro) {
            this.fechaRegistro = fechaRegistro;
            this.valorRegistro = valorRegistro;
        }
    }
}
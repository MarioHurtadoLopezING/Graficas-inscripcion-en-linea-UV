using GraficasILinea.App.entidades;
using System;
using System.Collections.Generic;

namespace GraficasILinea.App.accesoDatos
{
    interface RegionDAO
    {
        List<Region> getRegionesInscripcionPorPeriodo(string periodoInscripcion);
        List<Region> getRegionesInscripcionPorPeriodoYFecha(String fecha, String periodoInscripcion);
    }
}

using GraficasILinea.App.entidades;
using System;
using System.Collections.Generic;

namespace GraficasILinea.App.accesoDatos
{
    interface AreaAcademicaDAO
    {
        List<AreaAcademica> getAreasAcademicas(String periodoInscripcion); 
    }
}

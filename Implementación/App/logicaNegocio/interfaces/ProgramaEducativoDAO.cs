using GraficasILinea.App.entidades;
using System;
using System.Collections.Generic;

namespace GraficasILinea.App.accesoDatos
{
    interface ProgramaEducativoDAO
    {
        List<ProgramaEducativo> getProgramasEducativos(String periodoInscripcion);
    }
}

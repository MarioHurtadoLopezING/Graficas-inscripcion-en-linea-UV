using GraficasILinea.App.entidades;
using System.Collections.Generic;

namespace GraficasILinea.App.accesoDatos
{
    interface InscripcionGeneralDAO
    {
        List<InscripcionGeneral> getDiasInscripcion(string periodoInscripcion);
    }
}

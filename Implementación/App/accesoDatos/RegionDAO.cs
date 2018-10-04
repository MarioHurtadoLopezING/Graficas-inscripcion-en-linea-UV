using GraficasILinea.App.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficasILinea.App.accesoDatos
{
    interface RegionDAO
    {
        List<Region> obtenerRegionesInscripcion(string periodoInscripcion);
    }
}

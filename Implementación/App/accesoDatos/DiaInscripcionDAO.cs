using GraficasILinea.App.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficasILinea.App.accesoDatos
{
    interface DiaInscripcionDAO
    {
        List<DiaInscripcion> obtenerDiasInscripcion(String periodoInscripcion);
        int obtenerLugaresSorteados(String diaInscripcion);
        double obtenerPorcentajeDia(int lugaresSorteados, int lugaresInscritos);
        double calcularPorcentajeTotal(List<DiaInscripcion> diaInscripcion);
    }
}

using GraficasILinea.App.logicaNegocio.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficasILinea.App.accesoDatos
{
    interface PeriodoDAO
    {
        List<Periodo> obtenerPeriodosInscripcion();
        List<Periodo> ontenerPeriodosIntersemestral();
    }
}

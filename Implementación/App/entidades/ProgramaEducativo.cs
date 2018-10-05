using GraficasILinea.App.accesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraficasILinea.App.entidades
{
    public class ProgramaEducativo
    {
        private String nombreProgramaEducativo;
        private int lugaresSorteados;
        private int lugaresInscritos;
        private int totalLugaresSorteados;
        private int totalLugaresInscritos;
        private double porcentajePrograma;
        private double porcentajeTotalProgramas;

        public ProgramaEducativo(String nombreProgramaEducativo, int lugaresSorteados, int lugaresInscritos) {
            this.nombreProgramaEducativo = nombreProgramaEducativo;
            this.lugaresSorteados = lugaresSorteados;
            this.lugaresInscritos = lugaresInscritos;
        }
        public List<ProgramaEducativo> obtenerProgramasEducativos(String periodoInscripcion)
        {
            List<ProgramaEducativo> programasEducativos = new ProgramaEducativoDAOSql().obtenerProgramasEducativos(periodoInscripcion);
            programasEducativos = this.calcularPorcentajePrograma(programasEducativos);
            return programasEducativos;
        }
        private List<ProgramaEducativo> calcularPorcentajePrograma(List<ProgramaEducativo> programasEducativos)
        {
            double porcentaje = 0.0;
            foreach (ProgramaEducativo programaEducativo in programasEducativos)
            {
                porcentaje = programaEducativo.getLugaresInscritos() * 100;
                porcentaje = porcentaje / programaEducativo.getLugaresSorteados();
                programaEducativo.setPorcentajeProgramaEducativo(porcentaje);
            }
            return programasEducativos;
        }
        public int getTotalLugaresSorteados(List<ProgramaEducativo> programasEducativos)
        {
            totalLugaresSorteados = 0;
            foreach (ProgramaEducativo programaEducativo in programasEducativos)
            {
                totalLugaresSorteados = totalLugaresSorteados + programaEducativo.getLugaresSorteados();
            }
            return totalLugaresSorteados;
        }
        public int getTotalLugaresInscritos(List<ProgramaEducativo> programasEducativos)
        {
            totalLugaresInscritos = 0;
            foreach (ProgramaEducativo programaEducativo in programasEducativos)
            {
                totalLugaresInscritos = totalLugaresInscritos + programaEducativo.getLugaresInscritos();
            }
            return totalLugaresInscritos;
        }
        public double getTotalProgramaEducativo(List<ProgramaEducativo> programasEducativos)
        {
            porcentajeTotalProgramas = getTotalLugaresInscritos(programasEducativos);
            porcentajeTotalProgramas = porcentajeTotalProgramas * 100;
            porcentajeTotalProgramas = porcentajeTotalProgramas / getTotalLugaresSorteados(programasEducativos);
            return porcentajeTotalProgramas;
        }
        public void setPorcentajeProgramaEducativo(double porcentajePrograma)
        {
            this.porcentajePrograma = porcentajePrograma;
        }
        public int getLugaresSorteados()
        {
            return this.lugaresSorteados;
        }
        public int getLugaresInscritos()
        {
            return this.lugaresInscritos;
        }
        public string getProgramaEducativo()
        {
            return this.nombreProgramaEducativo;
        }
    }
}
using System;
using System.Collections.Generic;

using TareaSemana3.Nombramientos.Comun;

namespace TareaSemana3.Nombramientos.Demos.AbrebiaturasSimetrias
{
    // =====================================================================
    // DEMO 6: ABREVIATURAS Y SIMETRÍAS
    // Reglas (Clean Code, cap. 2):
    //  a) No abrevie: Reg, Mngr, Agr, Calc, Desc obligan a descifrar.
    //  b) Una palabra por concepto: no use Agregar, Ins y Meter para lo mismo.
    //  c) Use pares simétricos: Agregar/Quitar, Inscribir/Retirar,
    //     Abrir/Cerrar. Si existe el uno, se espera el otro.
    // =====================================================================

    // ------------------------- VERSIÓN SUCIA ----------------------------
    // Problemas: abreviaturas (Reg, Mngr, Agr, Rem, Calc, Desc), verbos
    // mezclados para el mismo concepto (Agr/Ins) y pares incompletos:
    // existe AgrNota pero nadie encuentra RemNota.
    public class RegNotasMngr
    {
        private List<double> lstNotas = new List<double>();
        private bool estInscrito = false;

        public void AgrNota(double n)
        {
            lstNotas.Add(n);
        }

        public void RemNota(int i)
        {
            lstNotas.RemoveAt(i);
        }

        public void InsEst()
        {
            estInscrito = true;
        }

        public double CalcProm()
        {
            double s = 0;
            foreach (double x in lstNotas)
                s += x;
            return lstNotas.Count == 0 ? 0 : s / lstNotas.Count;
        }

        public string DescEst()
        {
            return estInscrito ? "Estudiante inscrito" : "Estudiante no inscrito";
        }

        public void Ver()
        {
            Console.WriteLine($"  {DescEst()} | Notas: {lstNotas.Count} | Prom: {CalcProm():0.00}");
        }
    }

    // ------------------------- VERSIÓN LIMPIA ---------------------------
    // Sin abreviaturas y con pares simétricos completos:
    //   AgregarNota   <-> QuitarNota
    //   InscribirEstudiante <-> RetirarEstudiante
    public class ControlDeNotas
    {
        private List<double> _notas = new List<double>();
        private bool _estudianteInscrito = false;

        public void InscribirEstudiante()
        {
            _estudianteInscrito = true;
        }

        public void RetirarEstudiante()
        {
            _estudianteInscrito = false;
        }

        public void AgregarNota(double nota)
        {
            _notas.Add(nota);
        }

        public void QuitarNota(int posicion)
        {
            _notas.RemoveAt(posicion);
        }

        public double CalcularPromedio()
        {
            double sumaNotas = 0;
            foreach (double nota in _notas)
                sumaNotas += nota;
            return _notas.Count == 0 ? 0 : sumaNotas / _notas.Count;
        }

        public string ObtenerDescripcion()
        {
            return _estudianteInscrito ? "Estudiante inscrito" : "Estudiante no inscrito";
        }

        public void MostrarEstado()
        {
            Console.WriteLine($"  {ObtenerDescripcion()} | Notas registradas: {_notas.Count} | Promedio: {CalcularPromedio():0.00}");
        }
    }

    public static class Demo06AbrebiaturasSimetrias
    {
        public static void Ejecutar()
        {
            Presentacion.Encabezado("DEMO 6: ABREVIATURAS Y SIMETRÍAS");

            Console.WriteLine("--- VERSIÓN SUCIA  (clase RegNotasMngr) ---");
            var sucio = new RegNotasMngr();
            sucio.InsEst();
            sucio.AgrNota(80);
            sucio.AgrNota(90);
            sucio.Ver();
            Console.WriteLine("  ¿Reg? ¿Mngr? ¿Agr? ¿Rem? ¿Desc? El lector debe descifrar cada una.");

            Console.WriteLine();
            Console.WriteLine("--- VERSIÓN LIMPIA (clase ControlDeNotas) ---");
            var limpio = new ControlDeNotas();
            limpio.InscribirEstudiante();   // simétrico de RetirarEstudiante
            limpio.AgregarNota(80);         // simétrico de QuitarNota
            limpio.AgregarNota(90);
            limpio.MostrarEstado();
            limpio.QuitarNota(0);
            limpio.MostrarEstado();
            limpio.RetirarEstudiante();     // el par opuesto existe y es claro
            limpio.MostrarEstado();

            Presentacion.ReglaAplicada(
                "no abrevie y use pares simétricos: Agregar/Quitar, Inscribir/Retirar; una sola palabra por concepto.");
        }
    }
}

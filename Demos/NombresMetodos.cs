using System;
using System.Collections.Generic;

using TareaSemana3.Nombramientos.Comun;

namespace TareaSemana3.Nombramientos.Demos.NombresMetodos
{
    // =====================================================================
    // DEMO 4: NOMBRES DE MÉTODOS
    // Regla (Clean Code, cap. 2): los métodos son FRASES VERBALES:
    // CalcularPromedio, InscribirEstudiante, ObtenerNotasAprobadas.
    // Evite Hacer, Procesar, Manejar, Verif, Mng: no dicen qué hacen.
    // =====================================================================

    // ------------------------- VERSIÓN SUCIA ----------------------------
    // Hacer()   -> ¿hacer qué?
    // Procesar()-> ¿procesar cómo y qué?
    // Verif()   -> abreviado y vago
    // Mng()     -> ¿manejar? ¿administrar? nadie lo sabe
    public class Operaciones
    {
        private List<double> _notas = new List<double> { 70, 85, 90, 55 };

        public double Hacer()
        {
            double s = 0;
            foreach (double x in _notas)
                s += x;
            return s / _notas.Count;
        }

        public List<double> Procesar()
        {
            var r = new List<double>();
            foreach (double x in _notas)
                if (x >= 70)
                    r.Add(x);
            return r;
        }

        public bool Verif()
        {
            return Hacer() >= 70;
        }

        public void Mng()
        {
            Console.WriteLine($"  Boletín: promedio {Hacer():0.00} | ¿Aprobado? {Verif()}");
        }
    }

    // ------------------------- VERSIÓN LIMPIA ---------------------------
    // Cada método es una frase verbal específica: se lee como una oración.
    public class RegistroAcademico
    {
        private List<double> _notasRegistradas = new List<double> { 70, 85, 90, 55 };

        public double CalcularPromedio()
        {
            double sumaNotas = 0;
            foreach (double nota in _notasRegistradas)
                sumaNotas += nota;
            return sumaNotas / _notasRegistradas.Count;
        }

        public List<double> ObtenerNotasAprobadas()
        {
            var notasAprobadas = new List<double>();
            foreach (double nota in _notasRegistradas)
                if (nota >= CalculoAcademico.NotaMinimaAprobacion)
                    notasAprobadas.Add(nota);
            return notasAprobadas;
        }

        public bool EstaAprobadoElCurso()
        {
            return CalcularPromedio() >= CalculoAcademico.NotaMinimaAprobacion;
        }

        public void ImprimirBoletin()
        {
            Console.WriteLine($"  Boletín: promedio {CalcularPromedio():0.00} | ¿Curso aprobado? {EstaAprobadoElCurso()}");
        }
    }

    public static class CalculoAcademico
    {
        public const double NotaMinimaAprobacion = 70;
    }

    public static class Demo04NombresDeMetodos
    {
        public static void Ejecutar()
        {
            Presentacion.Encabezado("DEMO 4: NOMBRES DE MÉTODOS");

            Console.WriteLine("--- VERSIÓN SUCIA  (clase Operaciones) ---");
            var operaciones = new Operaciones();
            Console.WriteLine("  r = operaciones.Hacer();      // ¿qué devuelve?");
            operaciones.Mng();
            Console.WriteLine($"  operaciones.Procesar() devuelve {operaciones.Procesar().Count} elementos");

            Console.WriteLine();
            Console.WriteLine("--- VERSIÓN LIMPIA (clase RegistroAcademico) ---");
            var registro = new RegistroAcademico();
            Console.WriteLine("  promedio = registro.CalcularPromedio();");
            registro.ImprimirBoletin();
            List<double> notasAprobadas = registro.ObtenerNotasAprobadas();
            Console.WriteLine($"  registro.ObtenerNotasAprobadas() devuelve {notasAprobadas.Count} notas aprobadas");

            Presentacion.ReglaAplicada(
                "los métodos son frases verbales: CalcularPromedio y ObtenerNotasAprobadas se explican solos; Hacer y Procesar no.");
        }
    }
}

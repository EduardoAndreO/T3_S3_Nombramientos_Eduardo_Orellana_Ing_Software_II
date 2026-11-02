using System;

using TareaSemana3.Nombramientos.Comun;

namespace TareaSemana3.Nombramientos.Demos.AsignacionesMentales
{
    // =====================================================================
    // DEMO 2: ASIGNACIONES MENTALES
    // Regla (Clean Code, cap. 2): evite nombres que obligan al lector a
    // "mapear mentalmente" qué significa cada letra (n, s, x, m, p, r, v).
    // El lector no debe necesitar una tabla mental para traducir el código.
    // =====================================================================

    // ------------------------- VERSIÓN SUCIA ----------------------------
    // Para leer este método hay que responder: ¿n son notas? ¿s es suma?
    // ¿m es media? ¿p es promedio? Ese trabajo mental es el problema.
    public class Calculos
    {
        public static double Calcular(double[] n)
        {
            double s = 0;
            foreach (double x in n)
                s += x;
            double m = s / n.Length;
            return m;
        }

        public static string Estado(double p)
        {
            if (p >= 70)
                return "Aprobado";
            return "Reprobado";
        }
    }

    // ------------------------- VERSIÓN LIMPIA ---------------------------
    // Los nombres son explícitos y además la nota mínima deja de ser un
    // número suelto: ahora es una constante con nombre de negocio.
    public class CalculadoraAcademica
    {
        public const double NotaMinimaAprobacion = 70;

        public static double CalcularPromedio(double[] notas)
        {
            double sumaNotas = 0;
            foreach (double nota in notas)
                sumaNotas += nota;
            double promedio = sumaNotas / notas.Length;
            return promedio;
        }

        public static string ObtenerEstadoAcademico(double promedio)
        {
            if (promedio >= NotaMinimaAprobacion)
                return "Aprobado";
            return "Reprobado";
        }
    }

    public static class Demo02AsignacionesMentales
    {
        public static void Ejecutar()
        {
            Presentacion.Encabezado("DEMO 2: ASIGNACIONES MENTALES");

            Console.WriteLine("--- VERSIÓN SUCIA  (clase Calculos) ---");
            // En el código sucio el que llama también usa letras: ¿v1?, ¿r?, ¿e?
            double[] v1 = { 60, 75, 88, 91 };
            double r = Calculos.Calcular(v1);
            string e = Calculos.Estado(r);
            Console.WriteLine($"  Resultado: {r:0.00} | Estado: {e}");

            Console.WriteLine();
            Console.WriteLine("--- VERSIÓN LIMPIA (clase CalculadoraAcademica) ---");
            // En el código limpio la llamada se lee como una oración.
            double[] notasParciales = { 60, 75, 88, 91 };
            double promedioFinal = CalculadoraAcademica.CalcularPromedio(notasParciales);
            string estadoFinal = CalculadoraAcademica.ObtenerEstadoAcademico(promedioFinal);
            Console.WriteLine($"  Promedio final: {promedioFinal:0.00} | Estado académico: {estadoFinal}");

            Presentacion.ReglaAplicada(
                "evite asignaciones mentales: n, s, m, p, r, v obligan a traducir; notas, sumaNotas y promedio no.");
        }
    }
}

using System;

using TareaSemana3.Nombramientos.Comun;

namespace TareaSemana3.Nombramientos.Demos.Prefijos
{
    // =====================================================================
    // DEMO 1: PREFIJOS Y MIEMBROS
    // Regla (Clean Code, cap. 2): no codifique el tipo ni el alcance en el
    // nombre. Los prefijos m_, str, int, b, arr, dbl son ruido: hoy los
    // editores resaltan tipos y alcance, y el nombre debe decir QUÉ es la
    // información, no de qué tipo es.
    // =====================================================================

    // ------------------------- VERSIÓN SUCIA ----------------------------
    // Problemas: m_ en miembros, notación húngara (str, _int, b, arr, dbl)
    // y método con prefijo Mtd_. Para entender cada línea hay que
    // "decodificar" prefijos que no aportan significado de negocio.
    public class EstudianteData
    {
        public string m_NombreCompleto = "Ana Martínez";
        public string strCarnet = "2021-1035";
        private int _intEdad = 20;
        private bool bMatriculada = true;

        public double Mtd_CalcularPromedio(double[] arrNotas)
        {
            double dblSuma = 0;
            foreach (double dblNota in arrNotas)
                dblSuma += dblNota;
            return dblSuma / arrNotas.Length;
        }

        public void MostrarResumen(double[] arrNotas)
        {
            Console.WriteLine($"  Alumna        : {m_NombreCompleto}");
            Console.WriteLine($"  strCarnet     : {strCarnet}");
            Console.WriteLine($"  _intEdad      : {_intEdad} años");
            Console.WriteLine($"  bMatriculada  : {bMatriculada}");
            Console.WriteLine($"  Promedio      : {Mtd_CalcularPromedio(arrNotas):0.00}");
        }
    }

    // ------------------------- VERSIÓN LIMPIA ---------------------------
    // Propiedades sin prefijos: el nombre declara el concepto del negocio.
    public class Estudiante
    {
        public string NombreCompleto { get; set; } = "Ana Martínez";
        public string Carnet { get; set; } = "2021-1035";
        public int Edad { get; set; } = 20;
        public bool Matriculada { get; set; } = true;

        public double CalcularPromedio(double[] notas)
        {
            double sumaNotas = 0;
            foreach (double nota in notas)
                sumaNotas += nota;
            return sumaNotas / notas.Length;
        }

        public void MostrarResumen(double[] notas)
        {
            Console.WriteLine($"  Alumna       : {NombreCompleto}");
            Console.WriteLine($"  Carnet       : {Carnet}");
            Console.WriteLine($"  Edad         : {Edad} años");
            Console.WriteLine($"  Matriculada  : {Matriculada}");
            Console.WriteLine($"  Promedio     : {CalcularPromedio(notas):0.00}");
        }
    }

    public static class Demo01PrefijosMiembros
    {
        public static void Ejecutar()
        {
            Presentacion.Encabezado("DEMO 1: PREFIJOS Y MIEMBROS");

            double[] notasDelPeriodo = { 85, 90, 78, 92 };

            Console.WriteLine("--- VERSIÓN SUCIA  (clase EstudianteData) ---");
            var estudianteSucio = new EstudianteData();
            estudianteSucio.MostrarResumen(notasDelPeriodo);

            Console.WriteLine();
            Console.WriteLine("--- VERSIÓN LIMPIA (clase Estudiante)    ---");
            var estudianteLimpio = new Estudiante();
            estudianteLimpio.MostrarResumen(notasDelPeriodo);

            Presentacion.ReglaAplicada(
                "los miembros no llevan m_ ni húngaro; el nombre dice QUÉ guarda, no de qué tipo es.");
        }
    }
}

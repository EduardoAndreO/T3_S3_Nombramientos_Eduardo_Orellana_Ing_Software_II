using System;

using TareaSemana3.Nombramientos.Comun;

namespace TareaSemana3.Nombramientos.Demos.NombresClases
{
    // =====================================================================
    // DEMO 3: NOMBRES DE CLASES
    // Regla (Clean Code, cap. 2): las clases son SUSTANTIVOS (frases
    // nominales): Estudiante, RegistroNotas, Boletin. Evite palabras vagas
    // como Data, Info, Manager/Mgr, Processor y los sufijos numéricos.
    // =====================================================================

    // ------------------------- VERSIÓN SUCIA ----------------------------
    // Cuatro nombres de clase malos y por qué:
    //   Data           -> vago: ¿qué data?
    //   MgrNotas       -> abreviatura de Manager: papel técnico, no negocio
    //   EstudianteInfo2-> "Info" vago + número mágico que dice poco
    //   ProcesaCosas   -> verbo genérico + "Cosas": no se sabe qué hace
    public class Data
    {
        public double Calcular(double[] valores)
        {
            double total = 0;
            foreach (double valor in valores)
                total += valor;
            return total / valores.Length;
        }
    }

    public class MgrNotas
    {
        public string Estado(double p)
        {
            return p >= 70 ? "Aprobado" : "Reprobado";
        }
    }

    public class EstudianteInfo2
    {
        public string Nom = "Luis Pérez";
    }

    public class ProcesaCosas
    {
        public void Mostrar(string texto)
        {
            Console.WriteLine($"  {texto}");
        }
    }

    // ------------------------- VERSIÓN LIMPIA ---------------------------
    // Nombres de clase: sustantivos concretos del dominio escolar.
    public class Estudiante
    {
        public string Nombre { get; set; } = "Luis Pérez";
    }

    public class RegistroNotas
    {
        public double CalcularPromedio(double[] notas)
        {
            double sumaNotas = 0;
            foreach (double nota in notas)
                sumaNotas += nota;
            return sumaNotas / notas.Length;
        }

        public string ObtenerEstadoAcademico(double promedio)
        {
            return promedio >= 70 ? "Aprobado" : "Reprobado";
        }
    }

    public class BoletinCalificaciones
    {
        public void Imprimir(Estudiante estudiante, double promedio, string estadoAcademico)
        {
            Console.WriteLine($"  Boletín de {estudiante.Nombre}");
            Console.WriteLine($"  Promedio: {promedio:0.00} | Estado: {estadoAcademico}");
        }
    }

    public static class Demo03NombresDeClases
    {
        public static void Ejecutar()
        {
            Presentacion.Encabezado("DEMO 3: NOMBRES DE CLASES");

            double[] notasDeLuis = { 72, 68, 91, 77 };

            Console.WriteLine("--- VERSIÓN SUCIA  (Data, MgrNotas, EstudianteInfo2, ProcesaCosas) ---");
            var data = new Data();
            var mgr = new MgrNotas();
            var info2 = new EstudianteInfo2();
            var procesa = new ProcesaCosas();
            double resultadoData = data.Calcular(notasDeLuis);
            procesa.Mostrar($"{info2.Nom}: promedio {resultadoData:0.00} | {mgr.Estado(resultadoData)}");
            procesa.Mostrar("¿Data de qué? ¿Mgr de qué? ¿Info2 de qué? Hay que adivinar.");

            Console.WriteLine();
            Console.WriteLine("--- VERSIÓN LIMPIA (Estudiante, RegistroNotas, BoletinCalificaciones) ---");
            var estudiante = new Estudiante();
            var registro = new RegistroNotas();
            var boletin = new BoletinCalificaciones();
            double promedio = registro.CalcularPromedio(notasDeLuis);
            string estado = registro.ObtenerEstadoAcademico(promedio);
            boletin.Imprimir(estudiante, promedio, estado);

            Presentacion.ReglaAplicada(
                "las clases son sustantivos del dominio; evite Data, Info, Manager y números que no dicen nada.");
        }
    }
}

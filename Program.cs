using System;

using TareaSemana3.Nombramientos.Demos.AsignacionesMentales;
using TareaSemana3.Nombramientos.Demos.AbrebiaturasSimetrias;
using TareaSemana3.Nombramientos.Demos.NoExcederAtractivo;
using TareaSemana3.Nombramientos.Demos.NombresClases;
using TareaSemana3.Nombramientos.Demos.NombresMetodos;
using TareaSemana3.Nombramientos.Demos.Prefijos;

namespace TareaSemana3.Nombramientos
{
    // =====================================================================
    // TAREA SEMANA 3 - NOMBRAMIENTOS (CLEAN CODE)
    // Aplicación de consola que demuestra 6 reglas de nombramiento del
    // libro "Clean Code" (Robert C. Martin, capítulo 2: Nombres con
    // significado). Cada demo muestra primero la versión SUCIA del código
    // y después la versión LIMPIA, con el mismo comportamiento de fondo:
    // solo cambia la calidad de los nombres.
    // =====================================================================
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
            }
            catch
            {
                // Si la consola no soporta UTF-8 el programa continúa igual.
            }

            // Modo de demostración continua: dotnet run -- all
            if (args.Length > 0 && args[0].Equals("all", StringComparison.OrdinalIgnoreCase))
            {
                EjecutarTodasLasDemos();
                return;
            }

            MostrarMenuInteractivo();
        }

        private static void MostrarMenuInteractivo()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("==================================================");
                Console.WriteLine(" TAREA SEMANA 3 - NOMBRAMIENTOS (CLEAN CODE)");
                Console.WriteLine(" Dominio de ejemplo: notas escolares");
                Console.WriteLine("==================================================");
                Console.WriteLine(" 1. Prefijos y miembros");
                Console.WriteLine(" 2. Asignaciones mentales");
                Console.WriteLine(" 3. Nombres de clases");
                Console.WriteLine(" 4. Nombres de métodos");
                Console.WriteLine(" 5. No exceder el atractivo");
                Console.WriteLine(" 6. Abreviaturas y simetrías");
                Console.WriteLine(" 7. Ejecutar TODAS las demos");
                Console.WriteLine(" 0. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine()?.Trim() ?? "0";
                Console.WriteLine();

                switch (opcion)
                {
                    case "1": Demo01PrefijosMiembros.Ejecutar(); break;
                    case "2": Demo02AsignacionesMentales.Ejecutar(); break;
                    case "3": Demo03NombresDeClases.Ejecutar(); break;
                    case "4": Demo04NombresDeMetodos.Ejecutar(); break;
                    case "5": Demo05NoExcederAtractivo.Ejecutar(); break;
                    case "6": Demo06AbrebiaturasSimetrias.Ejecutar(); break;
                    case "7": EjecutarTodasLasDemos(); break;
                    case "0":
                        Console.WriteLine("¡Hasta luego!");
                        return;
                    default:
                        Console.WriteLine("Opción no válida, intente de nuevo.");
                        break;
                }

                Console.WriteLine();
                Console.Write("Presione ENTER para volver al menú... ");
                Console.ReadLine();
            }
        }

        private static void EjecutarTodasLasDemos()
        {
            Demo01PrefijosMiembros.Ejecutar();
            Demo02AsignacionesMentales.Ejecutar();
            Demo03NombresDeClases.Ejecutar();
            Demo04NombresDeMetodos.Ejecutar();
            Demo05NoExcederAtractivo.Ejecutar();
            Demo06AbrebiaturasSimetrias.Ejecutar();

            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine(" FIN: el comportamiento es idéntico en las dos");
            Console.WriteLine(" versiones; la diferencia está en los nombres.");
            Console.WriteLine("==================================================");
        }
    }
}

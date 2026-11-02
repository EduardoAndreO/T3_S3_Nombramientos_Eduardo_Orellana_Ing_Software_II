using System;

namespace TareaSemana3.Nombramientos.Comun
{
    // =====================================================================
    // CLASE COMÚN DE PRESENTACIÓN
    // Centraliza los títulos de consola para que las demos solo se
    // preocupen por demostrar la regla de nombramiento.
    // =====================================================================
    public static class Presentacion
    {
        public static void Encabezado(string titulo)
        {
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine($" {titulo}");
            Console.WriteLine("==================================================");
        }

        public static void ReglaAplicada(string regla)
        {
            Console.WriteLine();
            Console.WriteLine($">> REGLA APLICADA: {regla}");
        }
    }
}

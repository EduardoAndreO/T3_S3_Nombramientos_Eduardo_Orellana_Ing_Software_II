using System;
using System.Collections.Generic;

using TareaSemana3.Nombramientos.Comun;

namespace TareaSemana3.Nombramientos.Demos.NoExcederAtractivo
{
    // =====================================================================
    // DEMO 5: NO EXCEDER EL ATRACTIVO  ("Don't be cute")
    // Regla (Clean Code, cap. 2): los nombres ingeniosos o graciosos solo
    // los entiende quien los inventó. La claridad gana: diga las cosas con
    // el nombre convencional del dominio, no con chistes ni metáforas.
    // =====================================================================

    // ------------------------- VERSIÓN SUCIA ----------------------------
    // ¿Quién adivinaría que MagiaNegra calcula el promedio o que
    // Chiripiorca vacía el registro? El autor sí; el equipo, nunca.
    public class NinjaDeNotas
    {
        private List<double> _notasCapturadas = new List<double> { 80, 65, 95 };
        private List<double> _respaldoSecreto = new List<double> { 80, 65, 95 };

        public double MagiaNegra()
        {
            if (_notasCapturadas.Count == 0)
                return 0;
            double hechizo = 0;
            foreach (double chispa in _notasCapturadas)
                hechizo += chispa;
            return hechizo / _notasCapturadas.Count;
        }

        public void KameHameHa(int objetivo)
        {
            _notasCapturadas.RemoveAt(objetivo);
        }

        public void Chiripiorca()
        {
            _notasCapturadas.Clear();
        }

        public void HolyHandGrenade()
        {
            _notasCapturadas = new List<double>(_respaldoSecreto);
        }

        public void RevelarEstado()
        {
            Console.WriteLine($"  Notas actuales: {string.Join(", ", _notasCapturadas)} | Promedio {MagiaNegra():0.00}");
        }
    }

    // ------------------------- VERSIÓN LIMPIA ---------------------------
    // Mismo comportamiento, nombres que el docente y el equipo entienden.
    public class RegistroEscolar
    {
        private List<double> _notasRegistradas = new List<double> { 80, 65, 95 };
        private List<double> _notasOriginales = new List<double> { 80, 65, 95 };

        public double CalcularPromedio()
        {
            if (_notasRegistradas.Count == 0)
                return 0;
            double sumaNotas = 0;
            foreach (double nota in _notasRegistradas)
                sumaNotas += nota;
            return sumaNotas / _notasRegistradas.Count;
        }

        public void QuitarNotaEn(int posicion)
        {
            _notasRegistradas.RemoveAt(posicion);
        }

        public void VaciarRegistro()
        {
            _notasRegistradas.Clear();
        }

        public void RestablecerRegistro()
        {
            _notasRegistradas = new List<double>(_notasOriginales);
        }

        public void MostrarEstado()
        {
            Console.WriteLine($"  Notas actuales: {string.Join(", ", _notasRegistradas)} | Promedio {CalcularPromedio():0.00}");
        }
    }

    public static class Demo05NoExcederAtractivo
    {
        public static void Ejecutar()
        {
            Presentacion.Encabezado("DEMO 5: NO EXCEDER EL ATRACTIVO");

            Console.WriteLine("--- VERSIÓN SUCIA  (clase NinjaDeNotas) ---");
            var ninja = new NinjaDeNotas();
            Console.WriteLine("  ninja.MagiaNegra();        // ¿promedio? ¿aleatorio?");
            Console.WriteLine("  ninja.KameHameHa(1);       // ¿borra? ¿ataca?");
            ninja.KameHameHa(1);
            ninja.RevelarEstado();
            ninja.Chiripiorca();
            Console.WriteLine("  ninja.Chiripiorca();       // tras ejecutarla...");
            ninja.RevelarEstado();
            ninja.HolyHandGrenade();
            Console.WriteLine("  ninja.HolyHandGrenade();   // ¿qué habrá hecho?");
            ninja.RevelarEstado();

            Console.WriteLine();
            Console.WriteLine("--- VERSIÓN LIMPIA (clase RegistroEscolar) ---");
            var registro = new RegistroEscolar();
            Console.WriteLine("  registro.QuitarNotaEn(1);");
            registro.QuitarNotaEn(1);
            registro.MostrarEstado();
            Console.WriteLine("  registro.VaciarRegistro();");
            registro.VaciarRegistro();
            registro.MostrarEstado();
            Console.WriteLine("  registro.RestablecerRegistro();");
            registro.RestablecerRegistro();
            registro.MostrarEstado();

            Presentacion.ReglaAplicada(
                "no sea gracioso: MagiaNegra es CalcularPromedio, Chiripiorca es VaciarRegistro y HolyHandGrenade es RestablecerRegistro.");
        }
    }
}

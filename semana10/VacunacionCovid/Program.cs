using System;
using System.Collections.Generic;
using System.Linq;

namespace VacunacionCovid
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Crear el conjunto de 500 ciudadanos
            HashSet<string> ciudadanos = new HashSet<string>();
            for (int i = 1; i <= 500; i++)
            {
                ciudadanos.Add("Ciudadano " + i);
            }

            // 2. Crear subconjunto ficticio de 75 vacunados con Pfizer
            HashSet<string> vacunadosPfizer = new HashSet<string>();
            for (int i = 1; i <= 75; i++)
            {
                vacunadosPfizer.Add("Ciudadano " + i);
            }

            // 3. Crear subconjunto ficticio de 85 vacunados con AstraZeneca
            HashSet<string> vacunadosAstra = new HashSet<string>();
            for (int i = 50; i < 135; i++) // se solapan algunos con Pfizer
            {
                vacunadosAstra.Add("Ciudadano " + i);
            }

            // --- Operaciones de teoría de conjuntos ---

            // a) No vacunados
            HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
            noVacunados.ExceptWith(vacunadosPfizer.Union(vacunadosAstra));

            // b) Con ambas vacunas
            HashSet<string> ambasVacunas = new HashSet<string>(vacunadosPfizer);
            ambasVacunas.IntersectWith(vacunadosAstra);

            // c) Solo Pfizer
            HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
            soloPfizer.ExceptWith(vacunadosAstra);

            // d) Solo AstraZeneca
            HashSet<string> soloAstra = new HashSet<string>(vacunadosAstra);
            soloAstra.ExceptWith(vacunadosPfizer);

            // --- Mostrar resultados ---
            Console.WriteLine(" Resultados de la campaña de vacunación:\n");
            Console.WriteLine($"1. No vacunados: {noVacunados.Count}");
            Console.WriteLine($"2. Con ambas vacunas: {ambasVacunas.Count}");
            Console.WriteLine($"3. Solo Pfizer: {soloPfizer.Count}");
            Console.WriteLine($"4. Solo AstraZeneca: {soloAstra.Count}");

            Console.WriteLine("\nEjemplo de ciudadanos en cada grupo:");
            Console.WriteLine("No vacunados -> " + string.Join(", ", noVacunados.Take(5)));
            Console.WriteLine("Ambas vacunas -> " + string.Join(", ", ambasVacunas.Take(5)));
            Console.WriteLine("Solo Pfizer -> " + string.Join(", ", soloPfizer.Take(5)));
            Console.WriteLine("Solo AstraZeneca -> " + string.Join(", ", soloAstra.Take(5)));

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}

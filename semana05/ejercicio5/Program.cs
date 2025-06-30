using System;
using System.Collections.Generic;
using System.Linq; 

namespace PriceAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Análisis de Precios ---");

            // 1. Almacenar los precios en una lista
            // Utilizamos List<double> para manejar números decimales, aunque los ejemplos sean enteros.
            List<double> prices = new List<double>
            {
                50, 75, 46, 22, 80, 65, 8
            };

            Console.WriteLine("Precios en la lista: " + string.Join(", ", prices));

            // Verificar si la lista no está vacía antes de intentar encontrar min/max
            if (prices.Any()) // prices.Any() es true si la lista contiene elementos
            {
                // 2. Encontrar el menor de los precios (mínimo)
                // Usamos el método Min() de LINQ, que es muy eficiente.
                double minPrice = prices.Min();

                // 3. Encontrar el mayor de los precios (máximo)
                // Usamos el método Max() de LINQ, que también es muy eficiente.
                double maxPrice = prices.Max();

                // 4. Mostrar por pantalla el menor y el mayor de los precios
                Console.WriteLine($"El precio más bajo es: {minPrice}");
                Console.WriteLine($"El precio más alto es: {maxPrice}");
            }
            else
            {
                Console.WriteLine("La lista de precios está vacía. No se pueden determinar el mínimo y el máximo.");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}
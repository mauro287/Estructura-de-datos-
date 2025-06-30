using System;
using System.Collections.Generic;
namespace LoteriaPrimitiva
{
    // Clase para manejar los números ganadores
    public class Sorteo
    {
        private List<int> numerosGanadores;

        public Sorteo()
        {
            numerosGanadores = new List<int>();
        }

        // Método para pedir los números al usuario
        public void PedirNumeros()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.Write("Introduce un número ganador: ");
                if (int.TryParse(Console.ReadLine(), out int numero))
                {
                    numerosGanadores.Add(numero);
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Intenta de nuevo.");
                    i--; // para repetir la iteración
                }
            }
        }

        // Método para ordenar y mostrar los números
        public void MostrarNumerosOrdenados()
        {
            numerosGanadores.Sort();
            Console.WriteLine("Los números ganadores son: " + string.Join(", ", numerosGanadores));
        }
    }

    // Clase principal
    class Program
    {
        static void Main(string[] args)
        {
            Sorteo sorteo = new Sorteo();
            sorteo.PedirNumeros();
            sorteo.MostrarNumerosOrdenados();
        }
    }
}


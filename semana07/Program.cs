using System;
using System.Collections.Generic;

class TorreDeHanoi
{
    static Stack<int> origen = new Stack<int>();
    static Stack<int> auxiliar = new Stack<int>();
    static Stack<int> destino = new Stack<int>();

    // Mostrar el estado actual de las torres
    static void MostrarTorres()
    {
        void ImprimirTorre(string nombre, Stack<int> torre)
        {
            Console.Write($"{nombre}: ");
            foreach (var disco in torre)
                Console.Write(disco + " ");
            Console.WriteLine();
        }

        Console.WriteLine("\nEstado actual de las torres:");
        ImprimirTorre("Origen", new Stack<int>(origen));
        ImprimirTorre("Auxiliar", new Stack<int>(auxiliar));
        ImprimirTorre("Destino", new Stack<int>(destino));
        Console.WriteLine("----------------------------");
    }

    // Algoritmo recursivo para mover discos
    static void ResolverHanoi(int n, Stack<int> desde, Stack<int> hacia, Stack<int> temp, string nombreDesde, string nombreHacia, string nombreTemp)
    {
        if (n == 1)
        {
            int disco = desde.Pop();
            hacia.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreDesde} a {nombreHacia}");
            MostrarTorres();
            return;
        }

        ResolverHanoi(n - 1, desde, temp, hacia, nombreDesde, nombreTemp, nombreHacia);
        ResolverHanoi(1, desde, hacia, temp, nombreDesde, nombreHacia, nombreTemp);
        ResolverHanoi(n - 1, temp, hacia, desde, nombreTemp, nombreHacia, nombreDesde);
    }

    static void Main(string[] args)
    {
        int cantidadDiscos = 3; // Puedes cambiar la cantidad aquí

        for (int i = cantidadDiscos; i >= 1; i--)
            origen.Push(i);

        MostrarTorres();
        ResolverHanoi(cantidadDiscos, origen, destino, auxiliar, "Origen", "Destino", "Auxiliar");

        Console.WriteLine("\n¡Resolución completa!");
    }
}


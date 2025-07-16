using System;
using System.Collections.Generic;

class AtraccionParque
{
    private int totalAsientos;
    private Queue<string> cola;
    private List<(int, string)> asientosOcupados;

    public AtraccionParque(int total = 30)
    {
        totalAsientos = total;
        cola = new Queue<string>();
        asientosOcupados = new List<(int, string)>();
    }

    public void AgregarPersona(string nombre)
    {
        cola.Enqueue(nombre);
        Console.WriteLine($"{nombre} se ha unido a la fila.");
    }

    public void AsignarAsientos()
    {
        Console.WriteLine("\n--- Asignando Asientos ---");
        while (cola.Count > 0 && asientosOcupados.Count < totalAsientos)
        {
            string persona = cola.Dequeue();
            int numeroAsiento = asientosOcupados.Count + 1;
            asientosOcupados.Add((numeroAsiento, persona));
            Console.WriteLine($"Asiento {numeroAsiento}: {persona}");
        }

        if (asientosOcupados.Count == totalAsientos)
        {
            Console.WriteLine("\nTodos los asientos han sido ocupados.");
        }
        else
        {
            Console.WriteLine("\nAún hay asientos disponibles.");
        }
    }

    public void MostrarReporte()
    {
        Console.WriteLine("\n--- Reporte de Asientos Ocupados ---");
        foreach (var asiento in asientosOcupados)
        {
            Console.WriteLine($"Asiento {asiento.Item1}: {asiento.Item2}");
        }

        Console.WriteLine("\n--- Personas en Espera ---");
        foreach (var persona in cola)
        {
            Console.WriteLine($"En espera: {persona}");
        }
    }
}

class Program
{
    static void Main()
    {
        AtraccionParque atraccion = new AtraccionParque();

        // Simulación de nombres
        for (int i = 1; i <= 34; i++)
        {
            atraccion.AgregarPersona($"Persona{i}");
        }

        atraccion.AsignarAsientos();
        atraccion.MostrarReporte();
    }
}

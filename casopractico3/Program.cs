using System;
using System.Collections.Generic;
using System.Diagnostics;

class TorneoFutbol
{
    private Dictionary<string, HashSet<string>> torneo;

    public TorneoFutbol()
    {
        torneo = new Dictionary<string, HashSet<string>>();
    }

    // Registrar equipo
    public void RegistrarEquipo(string nombre)
    {
        if (!torneo.ContainsKey(nombre))
        {
            torneo[nombre] = new HashSet<string>();
            Console.WriteLine($"Equipo '{nombre}' registrado con éxito.");
        }
        else
        {
            Console.WriteLine($"El equipo '{nombre}' ya existe.");
        }
    }

    // Registrar jugador
    public void RegistrarJugador(string equipo, string jugador)
    {
        if (torneo.ContainsKey(equipo))
        {
            if (torneo[equipo].Add(jugador)) // HashSet evita duplicados
                Console.WriteLine($"Jugador '{jugador}' agregado al equipo '{equipo}'.");
            else
                Console.WriteLine($"El jugador '{jugador}' ya estaba en el equipo '{equipo}'.");
        }
        else
        {
            Console.WriteLine($"El equipo '{equipo}' no existe.");
        }
    }

    // Reporte de equipos y jugadores
    public void MostrarReporte()
    {
        Console.WriteLine("\nReporte de Equipos y Jugadores");
        foreach (var equipo in torneo)
        {
            string jugadores = equipo.Value.Count > 0 ? string.Join(", ", equipo.Value) : "Sin jugadores";
            Console.WriteLine($"{equipo.Key}: {jugadores}");
        }
    }

    // Consulta de jugadores por equipo
    public void ConsultarEquipo(string equipo)
    {
        if (torneo.ContainsKey(equipo))
        {
            Console.WriteLine($"\nJugadores en {equipo}: {string.Join(", ", torneo[equipo])}");
        }
        else
        {
            Console.WriteLine($"El equipo '{equipo}' no existe.");
        }
    }
}

class Program
{
    static void Main()
    {
        Stopwatch cronometro = new Stopwatch();
        cronometro.Start();

        TorneoFutbol torneo = new TorneoFutbol();

        torneo.RegistrarEquipo("Barcelona");
        torneo.RegistrarEquipo("Emelec");

        torneo.RegistrarJugador("Barcelona", "Juan");
        torneo.RegistrarJugador("Barcelona", "Pedro");
        torneo.RegistrarJugador("Emelec", "Luis");
        torneo.RegistrarJugador("Emelec", "Pedro");
        torneo.RegistrarJugador("Emelec", "Luis"); // duplicado para probar HashSet

        torneo.MostrarReporte();
        torneo.ConsultarEquipo("Barcelona");

        cronometro.Stop();
        Console.WriteLine($"\nTiempo de ejecución: {cronometro.Elapsed.TotalMilliseconds} ms");
    }
}


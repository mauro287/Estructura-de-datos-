
using System;
using System.Collections.Generic; // Necesario para List<T>

public class Program
{
    public static void Main(string[] args)
    {
        // Crear una lista de tipo string para almacenar las asignaturas.
        //   Para este caso, almacenaremos solo una asignatura.
        List<string> asignaturas = new List<string>();

        // 2. Añadir la asignatura a la lista.
        asignaturas.Add("Matemáticas"); 

        // 3. Mostrar la asignatura en pantalla.
        Console.WriteLine("La asignatura registrada es:");
        // Como sabemos que solo hay una, podemos accederla directamente por su índice 0
        Console.WriteLine($"- {asignaturas[0]}");
        // Console.WriteLine("\nAsignaturas del curso:");
        // Para que la consola no se cierre inmediatamente al ejecutar
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}



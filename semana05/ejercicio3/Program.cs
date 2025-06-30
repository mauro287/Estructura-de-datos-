using System;
using System.Collections.Generic;
using System.Linq; 

namespace SubjectRepetition
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Iniciar con una lista de nombres de asignaturas (strings)
            List<string> subjects = new List<string>
            {
                "Matemáticas",
                "Física",
                "Química",
                "Historia",
                "Lengua"
            };

            // 2. Iterar la lista de atrás hacia adelante
            // Esto es crucial cuando se eliminan elementos de una lista por índice,
            // ya que al eliminar un elemento, los índices de los elementos posteriores cambian.
            // Iterar hacia atrás asegura que los índices no se invaliden.
            for (int i = subjects.Count - 1; i >= 0; i--)
            {
                string currentSubject = subjects[i];
                double score;
                bool isValidInput;

                do
                {
                    // 3. Obtener la nota para la asignatura actual
                    Console.Write($"¿Qué nota has sacado en {currentSubject}?: ");
                    isValidInput = double.TryParse(Console.ReadLine(), out score);

                    if (!isValidInput || score < 0 || score > 10) // Asumiendo notas de 0 a 10
                    {
                        Console.WriteLine("Entrada inválida. Por favor, ingrese un número entre 0 y 10.");
                    }
                } while (!isValidInput || score < 0 || score > 10);

                // 4. Si la nota es >= 5 (criterio de aprobación del ejemplo Python)
                if (score >= 5.0) // Usamos 5.0 para coincidir con el ejemplo de Python
                {
                    // Eliminar la asignatura de la lista
                    subjects.RemoveAt(i); // 'pop(i)' en Python es equivalente a 'RemoveAt(i)' en C# List
                }
            }

            // 5. Imprimir las asignaturas restantes (las que se deben repetir)
            // Utiliza string.Join para formatear la salida de la lista como una cadena.
            if (subjects.Any())
            {
                Console.WriteLine("Tienes que repetir " + string.Join(", ", subjects));
            }
            else
            {
                Console.WriteLine("¡Felicidades! No tienes asignaturas que repetir.");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}

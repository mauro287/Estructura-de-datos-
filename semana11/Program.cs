using System;
using System.Collections.Generic;

class Traductor
{
    static void Main(string[] args)
    {
        // Diccionario inglés -> español (puedes invertir según prefieras)
        Dictionary<string, string> diccionario = new Dictionary<string, string>()
        {
            {"time", "tiempo"},
            {"person", "persona"},
            {"year", "año"},
            {"way", "camino"},
            {"day", "día"},
            {"thing", "cosa"},
            {"man", "hombre"},
            {"world", "mundo"},
            {"life", "vida"},
            {"hand", "mano"},
            {"part", "parte"},
            {"child", "niño"},
            {"eye", "ojo"},
            {"woman", "mujer"},
            {"place", "lugar"},
            {"work", "trabajo"},
            {"week", "semana"},
            {"case", "caso"},
            {"point", "punto"},
            {"government", "gobierno"},
            {"company", "empresa"}
        };

        int opcion = -1;
        while (opcion != 0)
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionario);
                    break;

                case 2:
                    AgregarPalabra(diccionario);
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    // Traducir frase palabra por palabra
    static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("Ingrese una frase: ");
        string frase = Console.ReadLine();

        string[] palabras = frase.Split(' ', ',', '.', ';', ':', '!', '?');
        string[] separadores = frase.Split(new char[] { ' ' }, StringSplitOptions.None);

        Console.WriteLine("\n--- Traducción ---");
        foreach (string palabra in separadores)
        {
            // Limpiamos signos de puntuación para comparar
            string limpia = palabra.Trim(',', '.', ';', ':', '!', '?').ToLower();

            if (diccionario.ContainsKey(limpia))
            {
                // Sustituir palabra por traducción
                Console.Write(diccionario[limpia] + " ");
            }
            else
            {
                Console.Write(palabra + " ");
            }
        }
        Console.WriteLine("\n-------------------");
    }

    // Agregar nuevas palabras al diccionario
    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("Ingrese la palabra en inglés: ");
        string ingles = Console.ReadLine().ToLower();

        if (diccionario.ContainsKey(ingles))
        {
            Console.WriteLine("Esa palabra ya existe en el diccionario.");
            return;
        }

        Console.Write("Ingrese la traducción en español: ");
        string espanol = Console.ReadLine().ToLower();

        diccionario.Add(ingles, espanol);
        Console.WriteLine($"Palabra agregada: {ingles} -> {espanol}");
    }
}

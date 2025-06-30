using System;
using System.Linq; 

namespace PalindromeCheckerApp
{
    // Clase PalindromeChecker: Encapsula la lógica para verificar palíndromos.
    public class PalindromeChecker
    {
        // Método estático: No necesita una instancia de PalindromeChecker para ser llamado.
        // Recibe una palabra y devuelve true si es un palíndromo, false en caso contrario.
        public static bool IsPalindrome(string word)
        {
            // Normalizar la palabra:
            string normalizedWord = word.ToLower();

            // Convertir la cadena a un array de caracteres, invertirlo y luego convertirlo de nuevo a cadena.
            char[] charArray = normalizedWord.ToCharArray();
            Array.Reverse(charArray); // Invierte el array de caracteres en su lugar
            string reversedWord = new string(charArray);

            // Comparar la palabra normalizada con su versión invertida.
            return normalizedWord == reversedWord;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Verificador de Palíndromos ---");

            // 2. Pedir al usuario una palabra
            Console.Write("Introduce una palabra: ");
            string userInput = Console.ReadLine();

            // 3. Utilizar la clase PalindromeChecker para verificar si es un palíndromo
            bool isPalindrome = PalindromeChecker.IsPalindrome(userInput);

            // 4. Mostrar el resultado por pantalla
            if (isPalindrome)
            {
                Console.WriteLine("Es un palíndromo");
            }
            else
            {
                Console.WriteLine("No es un palíndromo");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}

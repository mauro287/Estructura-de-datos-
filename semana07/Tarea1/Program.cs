using System;
using System.Collections.Generic;

class Verificador
{
    public static bool EstaBalanceado(string expresion)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char simbolo in expresion)
        {
            if (simbolo == '(' || simbolo == '{' || simbolo == '[')
            {
                pila.Push(simbolo);
            }
            else if (simbolo == ')' || simbolo == '}' || simbolo == ']')
            {
                if (pila.Count == 0)
                    return false;

                char cima = pila.Pop();

                if ((simbolo == ')' && cima != '(') ||
                    (simbolo == '}' && cima != '{') ||
                    (simbolo == ']' && cima != '['))
                {
                    return false;
                }
            }
        }

        return pila.Count == 0;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese una expresión matemática:");
        string expresion = Console.ReadLine();

        if (EstaBalanceado(expresion))
        {
            Console.WriteLine("Fórmula balanceada.");
        }
        else
        {
            Console.WriteLine("Fórmula desbalanceada.");
        }
    }
}


using System;

// Definición de la clase Node (Nodo)
public class Node
{
    public int Data; // El dato que almacena el nodo
    public Node Next; // Referencia al siguiente nodo en la lista

    public Node(int data)
    {
        Data = data;
        Next = null; // Al inicio, no apunta a ningún otro nodo
    }
}

// Definición de la clase LinkedList (Lista Enlazada)
public class LinkedList
{
    public Node Head; // La cabeza de la lista (primer nodo)

    public LinkedList()
    {
        Head = null; // Al inicio, la lista está vacía
    }

    // Método para agregar un nodo al final de la lista (útil para pruebas)
    public void AddLast(int data)
    {
        Node newNode = new Node(data);
        if (Head == null)
        {
            Head = newNode;
            return;
        }

        Node current = Head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    // Método para imprimir los elementos de la lista (útil para pruebas)
    public void PrintList()
    {
        if (Head == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Node current = Head;
        Console.Write("Lista: ");
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("NULL");
    }

    // --- Aquí irán los métodos para los ejercicios ---

    // Ejercicio 2: Invertir una lista enlazada
    public void ReverseList()
    {
        // Implementación del método
    }

    // Ejercicio 3: Método de búsqueda
    public int SearchCount(int valueToSearch)
    {
        // Implementación del método
        return 0; // Valor de retorno provisional
    }
}

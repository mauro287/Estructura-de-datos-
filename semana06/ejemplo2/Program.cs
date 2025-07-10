using System;

public class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class ListaEnlazada
{
    public Node Head;

    // Método para agregar nodos al final de la lista
    public void Insertar(int data)
    {
        Node nuevo = new Node(data);
        if (Head == null)
        {
            Head = nuevo;
        }
        else
        {
            Node actual = Head;
            while (actual.Next != null)
            {
                actual = actual.Next;
            }
            actual.Next = nuevo;
        }
    }

    // Método para contar cuántas veces aparece un valor en la lista
    public int SearchCount(int valueToSearch)
    {
        if (Head == null)
        {
            Console.WriteLine($"El dato '{valueToSearch}' no fue encontrado. La lista está vacía.");
            return 0;
        }

        int count = 0;
        Node current = Head;

        while (current != null)
        {
            if (current.Data == valueToSearch)
            {
                count++; // Si el dato coincide, incrementamos el contador
            }
            current = current.Next; // Pasamos al siguiente nodo
        }

        if (count == 0)
        {
            Console.WriteLine($"El dato '{valueToSearch}' no fue encontrado en la lista.");
        }
        else
        {
            Console.WriteLine($"El dato '{valueToSearch}' fue encontrado {count} veces.");
        }

        return count; // Retornamos el total encontrado
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();

        // Insertamos algunos valores
        lista.Insertar(5);
        lista.Insertar(3);
        lista.Insertar(7);
        lista.Insertar(3);
        lista.Insertar(9);

        // Buscamos cuántas veces aparece el número 3
        lista.SearchCount(3);
    }
}

// Dentro de la clase LinkedList:

public int SearchCount(int valueToSearch)
{
    if (Head == null)
    {
        Console.WriteLine($"El dato '{valueToSearch}' no fue encontrado. La lista está vacía.");
        return 0; // No hay elementos para buscar
    }

    int count = 0;
    Node current = Head; // Empezamos desde la cabeza de la lista

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
        // Opcional: Podrías imprimir aquí también si quieres confirmar el conteo.
        // Console.WriteLine($"El dato '{valueToSearch}' fue encontrado {count} veces.");
    }

    return count; // Retornamos el número total de veces que se encontró el dato
}

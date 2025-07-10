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
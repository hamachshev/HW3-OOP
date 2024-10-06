namespace HeapSort;

public class Node<T> where T : IComparable<T> 
{
    public Node(T value)
    {
        Value = value;
    }

    public Node<T> Left { get; set; }
    public Node<T> Right { get; set; }
    public T Value { get; set; }

    public int CompareTo(Node<T> other)
    {
        return Value.CompareTo(other.Value);
    }
   
}
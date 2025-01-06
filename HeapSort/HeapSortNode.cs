namespace HeapSort;

public class HeapSortNode<T> where T : IComparable<T>
{
    static LinkedList<T> end = new LinkedList<T>();
    static Queue<Node<T>[]> queue = new Queue<Node<T>[]>();
    public static void Sort(T[] array)
    {
        Node<T> root = new Node<T>(array[0]);
        makeNodetree(array, 0,root);

        if (root != null)
            heapify(root);
       
        popAndReheapify(root);

        foreach (T item in end)
        {
            Console.Write(item + " ");
        }

    }

    private static void popAndReheapify(Node<T> root)
    {
        if (root != null)
        {
            end.AddLast(root.Value);
            Node<T> lastNodeRight = GetLeafNodes(root).Last();
            lastNodeRight.Right = root.Right;
            lastNodeRight.Left = root.Left;
            root = lastNodeRight;
            heapify(root);
            popAndReheapify(root);
        }
    }

    private static LinkedList<Node<T>> GetLeafNodes(Node<T> root)
    {
        LinkedList<Node<T>> leafNodes = new LinkedList<Node<T>>();
        queue.Enqueue([null, root]);
        while (queue.Count > 0)
        {
            Node<T> [] node = queue.Dequeue();
            if (node[1].Right == null && node[1].Left == null)
            {
                node[0].
                leafNodes.AddLast(node[1]);
                //does not work yet, spoke to professor said we will discuss in class and didnt end up discussing in class
            }

            if (node[1].Left != null)
            {
                queue.Enqueue([node[1], node[1].Left]);
            }
            if (node[1].Right != null)
            {
                queue.Enqueue([node[1], node[1].Right]);
            }
        }
        
        return leafNodes;
        
    }
    


    private static void makeNodetree(T[] array, int root, Node<T> rootNode)
    {

        int leftNodeIndex = root * 2 + 1;
        int rightNodeIndex = root * 2 + 2;

        if (leftNodeIndex < array.Length)
        {
            rootNode.Left = new Node<T>(array[leftNodeIndex]);
            makeNodetree(array, leftNodeIndex, rootNode.Left);
        }
        
        if (rightNodeIndex < array.Length)
        {
            rootNode.Right = new Node<T>(array[rightNodeIndex]);
            makeNodetree(array, rightNodeIndex, rootNode.Right);
        }
    }

    private static void heapify(Node<T> node)
    {
        if (node.Right == null || node.Left == null)
        {
            return;
        }

        if (node.Right != null)
        {
            heapify(node.Right);
        }

        if (node.Left != null)
        {
            heapify(node.Left);
        }

        if (node.Right != null && node.Right.CompareTo(node) > 0)
        {
            T temp = node.Value;
            node.Value = node.Right.Value;
            node.Right.Value = temp;
            heapify(node.Right);

        }

        if (node.Left != null && node.Left.Value.CompareTo(node.Value) > 0)
        {
            T temp = node.Value;
            node.Value = node.Left.Value;
            node.Left.Value = temp;
            heapify(node.Left);
        }



    }
}
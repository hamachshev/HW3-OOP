namespace HeapSort;

public class HeapSortClass
{
    public static void Sort(int[] unsorted)
    {
        for (int i = (unsorted.Length/2) - 1; i >= 0; i--) // from last parent node at Length/2 -1
        {
            heapify(unsorted, i, unsorted.Length); //heapify starting from bottom nodes and move up
        }
        
        Console.WriteLine(string.Join(" ", unsorted));

        for (int i = unsorted.Length - 1; i >= 0; i--)
        {
            //go from end and set top (ie highest number) of the heap to the end
            int tempLast = unsorted[i];
            unsorted[i] = unsorted[0]; 
            unsorted[0] = tempLast;
            
            heapify(unsorted, 0, i);
        }
        
        Console.WriteLine(string.Join(" ", unsorted));

   
    }

    private static void heapify(int[] array, int rootIndex, int length)
    {
        int largestIndex = rootIndex;
        int leftChildIndex = (2 * rootIndex) + 1;
        int rightChildIndex = (2 * rootIndex) + 2;

        if (leftChildIndex< length && array[leftChildIndex] > array[largestIndex])
        {
            largestIndex = leftChildIndex;
        }
        
        if (rightChildIndex< length &&array[rightChildIndex] > array[largestIndex])
        {
            largestIndex = rightChildIndex;
        }

        if (largestIndex != rootIndex)
        {
            int temp = array[rootIndex];
            array[rootIndex] = array[largestIndex];
            array[largestIndex] = temp;
            
            heapify(array, largestIndex, length);
        }
       
        
        
    }
}
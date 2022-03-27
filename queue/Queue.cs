namespace queue;

public class Queue<T>
{
    // private int size = 0;
    // private int last = 0;

    private T[] myArray = new T[0];

    public void Add(T value)
    {
        var size = myArray.Length + 1;
        Array.Resize<T>(ref myArray, size);
        myArray[size - 1] = value;
    }

    public T GetElement()
    {
        if (myArray.Length == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T value = myArray[0];
        myArray = myArray.Skip(1).ToArray();  
        return value;
    }

    public int Length()
    {
        return myArray.Length;
    }
}
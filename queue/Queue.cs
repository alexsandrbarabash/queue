namespace queue;

public class Queue<T>
{
    // private int size = 0;
    // private int last = 0;
    public delegate void HandlerAdd(T value);
    public event HandlerAdd Added;

    private T[] myArray = new T[0];
    public int Length = 0;

    public void Add(T value)
    {
        var size = myArray.Length + 1;
        Array.Resize<T>(ref myArray, size);
        myArray[size - 1] = value;
        this.Length = this.Length + 1;
        OnAdded(value);
    }

    public T GetElement()
    {
        if (myArray.Length == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T value = myArray[0];
        myArray = myArray.Skip(1).ToArray();
        this.Length = this.Length - 1;
        return value;
    }

    protected virtual void OnAdded(T value)
    {
        if (Added != null)
        {
            Added(value);
        }
    }
}
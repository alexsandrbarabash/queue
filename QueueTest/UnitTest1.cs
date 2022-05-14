using System;
using NUnit.Framework;
using queue;

namespace QueueTest;

public class Tests
{
    [Test]
    public void Add_Element_Correct()
    {
        var value = 1;
        var example = new Queue<int>();
        example.Enqueue(value);
        Assert.AreEqual(example.Count, 1);
        Assert.AreEqual(example.Peek(), value);
    }

    [Test]
    public void Count_4result()
    {
        var expected = 4;
        var example = new Queue<int>();
        example.Enqueue(1);
        example.Enqueue(1);
        example.Enqueue(1);
        example.Enqueue(1);
        Assert.AreEqual(example.Count, expected);
    }

    [Test]
    public void Remove_First_Element_After_Added_0Count()
    {
        var expected = 0;
        var example = new Queue<int>();
        example.Enqueue(1);
        example.Dequeue();
        Assert.AreEqual(example.Count, expected);
    }

    [Test]
    public void GetCorrectElement()
    {
        var example = new Queue<int>();
        example.Enqueue(1);
        example.Enqueue(2);
        example.Enqueue(3);
        Console.WriteLine(example.Peek());
        Assert.AreEqual(example.Peek(), 1);
        example.Dequeue();
        Assert.AreEqual(example.Peek(), 2);
        example.Dequeue();
        Assert.AreEqual(example.Peek(), 3);
    }

    [Test]
    public void GetEmptyQueue()
    {
        var example = new queue.Queue<int>();
        Assert.Throws<InvalidOperationException>(() => example.Peek());
    }


    [Test]
    public void Remove_From_Empty_Error()
    {
        var example = new Queue<int>();

        Assert.Throws<InvalidOperationException>(() => example.Dequeue());
    }

    [Test]
    public void Clear_Count_Must_Be_Zero()
    {
        var example = new Queue<int>();
        example.Enqueue(1);
        example.Enqueue(2);
        example.Enqueue(3);
        example.Clear();
        Assert.AreEqual(example.Count, 0);
    }

    [Test]
    public void Clear_Error_When_Get_Element()
    {
        var example = new Queue<int>();
        example.Enqueue(1);
        example.Enqueue(2);
        example.Enqueue(3);
        example.Clear();
        Assert.Throws<InvalidOperationException>(() => example.Dequeue());
    }
    
    [Test]
    public void TestCopyTo()
    {
        
        int[] arr = new int[3];
        int[] expectedArray = { 2, 1, 0 };
        int expectedCount = expectedArray.Length;

        var example = new Queue<int>();
        example.Enqueue(0);
        example.Enqueue(1);
        example.Enqueue(2);
        example.CopyTo(arr, 0);
        Console.WriteLine(arr);
        Assert.AreEqual(arr, expectedArray);
        Assert.AreEqual(arr.Length, expectedCount);
    }

    [Test]
    public void After_Peek_Count_Not_Change()
    {
        int expectedCount = 3;
        var example = new Queue<int>();
        example.Enqueue(0);
        example.Enqueue(1);
        example.Enqueue(2);
        example.Peek();
        Assert.AreEqual(example.Count, expectedCount);
    }

    [Test]
    public void Contains_Find()
    {
        var example = new Queue<int>();
        example.Enqueue(0);
        Assert.AreEqual(example.Contains(0), true);
    }
    
    [Test]
    public void Contains_Not_Find()
    {
        var example = new Queue<int>();
        example.Enqueue(0);
        Assert.AreEqual(example.Contains(1), false);
    }

    [Test]
    public void IEnumeratorTest()
    {
        int[] expectedArray = { 2, 1, 0 };
        var i = 0;


        var example = new Queue<int>();
        example.Enqueue(0);
        example.Enqueue(0);
        example.Enqueue(0);

        foreach (var item in example)
        {
            Assert.AreEqual(item, 0);
            i++;
        }
    }
}
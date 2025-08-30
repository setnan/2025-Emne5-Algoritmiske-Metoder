namespace Datastrukturer;

public class MyQueue<T>
{
    private T[] _items;
    private int _head;   // peker til første element
    private int _tail;   // posisjonen etter siste element
    private int _count;

    public MyQueue(int capacity = 4)
    {
        if (capacity < 1) throw new ArgumentOutOfRangeException(nameof(capacity));
        _items = new T[capacity];
        _head = 0;
        _tail = 0;
        _count = 0;
    }

    public bool IsEmpty => _count == 0;
    public int Count => _count;

    public void Enqueue(T item)
    {
        if (_count == _items.Length)
            Grow();

        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;
        _count++;
    }

    public T Dequeue()
    {
        if (IsEmpty) throw new InvalidOperationException("Queue is empty");
        var item = _items[_head];
        _items[_head] = default!; // hjelpe GC ved referansetyper
        _head = (_head + 1) % _items.Length;
        _count--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty) throw new InvalidOperationException("Queue is empty");
        return _items[_head];
    }

    private void Grow()
    {
        int newCap = _items.Length * 2;
        var newArr = new T[newCap];

        // kopier i kø-rekkefølge
        for (int i = 0; i < _count; i++)
            newArr[i] = _items[(_head + i) % _items.Length];

        _items = newArr;
        _head = 0;
        _tail = _count;
    }
}

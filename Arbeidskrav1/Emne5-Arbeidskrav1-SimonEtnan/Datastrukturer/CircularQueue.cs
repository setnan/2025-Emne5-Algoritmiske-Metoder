namespace Datastrukturer;

/// <summary>
/// En sirkulær kø med fast kapasitet (ringbuffer).
/// Kaster unntak ved overflyt eller underflyt.
/// </summary>
public class CircularQueue<T>
{
    private readonly T[] _items;
    private int _head;
    private int _tail;
    private int _count;

    /// <summary>
    /// Oppretter en ny sirkulær kø med gitt kapasitet.
    /// </summary>
    public CircularQueue(int capacity)
    {
        if (capacity < 1) throw new ArgumentOutOfRangeException(nameof(capacity));
        _items = new T[capacity];
    }

    /// <summary>Total kapasitet (fast størrelse).</summary>
    public int Capacity => _items.Length;

    /// <summary>Antall elementer i køen.</summary>
    public int Count => _count;

    /// <summary>Returnerer <c>true</c> hvis køen er tom.</summary>
    public bool IsEmpty => _count == 0;

    /// <summary>Returnerer <c>true</c> hvis køen er full.</summary>
    public bool IsFull => _count == _items.Length;

    /// <summary>
    /// Legger til et element bakerst. Kaster hvis køen er full.
    /// </summary>
    public void Enqueue(T item)
    {
        if (IsFull) throw new InvalidOperationException("Queue is full");
        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;
        _count++;
    }

    /// <summary>
    /// Fjerner og returnerer første element. Kaster hvis tom.
    /// </summary>
    public T Dequeue()
    {
        if (IsEmpty) throw new InvalidOperationException("Queue is empty");
        var item = _items[_head];
        _items[_head] = default!;
        _head = (_head + 1) % _items.Length;
        _count--;
        return item;
    }

    /// <summary>
    /// Returnerer første element uten å fjerne. Kaster hvis tom.
    /// </summary>
    public T Peek()
    {
        if (IsEmpty) throw new InvalidOperationException("Queue is empty");
        return _items[_head];
    }
}

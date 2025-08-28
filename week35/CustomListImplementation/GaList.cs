namespace CustomListImplimentation;

public class GaList<T>
{
    private T[] _items;
    private int _count;

    private const int DefaultCapacity = 4;
    public GaList(int capacity = 4)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");

        _items = new T[capacity];
        _count = 0;
    }

    public int Count => _count; // number of elements in the list

    public T this[int index]
    {
        get => (uint)index < (uint)_count
            ? _items[index]
            : throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");
        set
        {
            if ((uint)index >= (uint)_count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");
            _items[index] = value;
        }
    }

    private void EnsureCapacity(int min)
    {
        if (_items.Length < min) return; // current capacity is sufficient

        var capacity = _items.Length == 0
            ? DefaultCapacity
            : _items.Length * 2;

        if (capacity < min)
            capacity = min;

        Array.Resize(ref _items, capacity);
    }

    // [0,1,2,3] - indexes
    public void Add(T item)
    {
        EnsureCapacity(_count + 1);
        _items[_count++] = item;
    }
}
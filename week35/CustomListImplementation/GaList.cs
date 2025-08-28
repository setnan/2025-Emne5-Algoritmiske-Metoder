using System.Collections;

namespace CustomListImplimentation;

public class GaList<T> : IEnumerable<T>
{
    private T[] _items;
    private int _count;

    private const int DefaultCapacity = 4;
    public GaList(int capacity = 4)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");

        _items = new T[DefaultCapacity];
        _count = 0;
    }

    public int Count => _count; // number of elements in the list

    public T this[int index] // this er et keyword for å bruke indeksen som en array
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
        EnsureCapacity(_count + 1); // Første elementet havner på index 0
        _items[_count++] = item;    // Legger til elementet på neste ledige plass
    }

    // [0,1,2,3,4] - indexes
    // [40,10,20,30,0] - contents

    // remove index 2 => [40,10,30,0, 0]
    public bool RemoveAt(int index)
    {
        // validate index
        if ((uint)index >= (uint)_count)
            return false;

        Array.Copy(
            _items, // source Array
            index + 1, // source index
            _items, // destination Array
            index, // destination index
            _count - index - 1); // number of elements to copy

        _items[--_count] = default!; // clear the last item and sets it to default data type
        _count--;
        return true;
    }


    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _items[i];
            // som en brusautomat, henter ut en og en brus av gangen 
            // og leverer den på bordet før en returnerer og henter en til
            // "Lazy loading"
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
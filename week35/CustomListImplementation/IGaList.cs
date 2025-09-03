public interface IGaList<T>
{
    void Add(T item);
    void Remove(T item);
    T Get(int index);
    int Count { get; }
}
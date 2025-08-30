namespace Datastrukturer;

public interface ISinglyLinkedList<T>
{
    void AddFirst(T item);
    void AddLast(T item);
    bool Remove(T item);         // fjerner første forekomst
    bool Contains(T item);
    int Count { get; }
}

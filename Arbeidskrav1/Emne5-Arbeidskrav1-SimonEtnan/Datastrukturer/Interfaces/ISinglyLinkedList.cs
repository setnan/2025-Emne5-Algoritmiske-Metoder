namespace Datastrukturer.Interfaces
{
    public interface ISinglyLinkedList<T>
    {
        void AddFirst(T item);
        void AddLast(T item);
        bool Remove(T item);
        bool Contains(T item);

        int Count { get; }
    }
}
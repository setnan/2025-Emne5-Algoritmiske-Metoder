using System.Collections;
namespace Datastrukturer
{
    public class CircularQueue<T> : IQueue<T>
    {
        private readonly T[] _items;
        private int _head;
        private int _tail;
        private int _count;

        public bool IsEmpty => _count == 0;

        public CircularQueue(int capacity)
        {
            if (capacity <= 0) throw new ArgumentException("Capacity must be greater than zero", nameof(capacity));
            _items = new T[capacity];
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        public void Enqueue(T item)
        {
            if (_count == _items.Length)
            {
                throw new InvalidOperationException("Queue is full");
            }
            _items[_tail] = item;
            _tail = (_tail + 1) % _items.Length;
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue is empty");
            var item = _items[_head];
            _items[_head] = default!;
            _head = (_head + 1) % _items.Length;
            _count--;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue is empty");
            return _items[_head];
        }
        public IEnumerable<T> PrintCircularQueue()
        {

            for (int i = 0; i < _count; i++)
            {
                int index = (_head + i) % _items.Length;
                yield return _items[index];
            }
            
        }
    }
}
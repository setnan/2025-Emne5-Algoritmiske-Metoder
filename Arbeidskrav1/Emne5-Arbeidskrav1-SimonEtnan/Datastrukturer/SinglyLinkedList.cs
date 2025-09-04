
namespace Datastrukturer.Interfaces
{
    public class SinglyLinkedList<T> : ISinglyLinkedList<T>
    {
        private class Node
        {
            public T Value;
            public Node? Next;

            public Node(T value)
            {
            Value = value;
            }
        }

        private Node? _head;
        private Node? _tail;
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node(item); // oppretter en ny node

            if (_head == null)
            {
                _head = _tail = node;
            }
            else
            {
                node.Next = _head;
                _head = node;
            }
            Count++;

        }

        public void AddLast(T item)
        {
            var node = new Node(item);
            if (_tail == null)
            {
                _head = _tail = node;

            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }
            Count++;

        }
        
        public bool Contains(T item)
        {
            var comparer = EqualityComparer<T>.Default;
            var current = _head;

            while (current != null)
            {
                if (comparer.Equals(current.Value, item))
                    return true;
                current = current.Next;
            }
            return false;
        }


        public bool Remove(T item)
        {

            if (_head == null) return false;

            var comparer = EqualityComparer<T>.Default;

            // Fjerner fra head
            if (comparer.Equals(_head.Value, item)) // Sjekker om hodet er lik item
            {
                _head = _head.Next;
                if (_head == null) _tail = null; // listen ble tom
                Count--;
                return true;
            }

            var current = _head;
            while (current.Next != null && !comparer.Equals(current.Next.Value, item))
            {
                current = current.Next;
            }

            if (current.Next == null) return false; // ikke funnet

            // Hvis vi fjerner siste node må vi flytte tail
            if (current.Next == _tail) _tail = current;

            // Koble forbi noden som matches
            current.Next = current.Next.Next;
            Count--;
            return true;


        }

        public IEnumerable<(int, T)> PrintContent()
        {

            // viser indexen og verdien til hvert element
            var index = 0;
            var current = _head;
            while (current != null)
            {
                yield return (index++, current.Value);
                current = current.Next;
            }



        }
    }
}

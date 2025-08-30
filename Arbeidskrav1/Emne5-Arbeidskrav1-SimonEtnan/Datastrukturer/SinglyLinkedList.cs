using System.Collections;
using System.Collections.Generic;

namespace Datastrukturer;

public class SinglyLinkedList<T> : ISinglyLinkedList<T>, IEnumerable<T>
{
    private class Node
    {
        public T Value;
        public Node? Next;
        public Node(T value) => Value = value;
    }

    private Node? _head;
    private Node? _tail;

    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        var node = new Node(item) { Next = _head };
        _head = node;
        if (_tail is null) _tail = node;
        Count++;
    }

    public void AddLast(T item)
    {
        var node = new Node(item);
        if (_tail is null)
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

    public bool Remove(T item)
    {
        if (_head is null) return false;

        var cmp = EqualityComparer<T>.Default;
        Node? prev = null;
        Node? curr = _head;

        while (curr != null)
        {
            if (cmp.Equals(curr.Value, item))
            {
                if (prev is null) _head = curr.Next;
                else prev.Next = curr.Next;

                if (curr == _tail) _tail = prev;

                Count--;
                return true;
            }

            prev = curr;
            curr = curr.Next;
        }

        return false;
    }

    public bool Contains(T item)
    {
        var cmp = EqualityComparer<T>.Default;
        for (var n = _head; n != null; n = n.Next)
            if (cmp.Equals(n.Value, item)) return true;
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var n = _head; n != null; n = n.Next)
            yield return n.Value;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

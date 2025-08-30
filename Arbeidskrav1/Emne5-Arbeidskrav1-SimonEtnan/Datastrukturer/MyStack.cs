namespace Datastrukturer;

public class MyStack<T>
{
    private T[] _items;
    private int _top;

    public MyStack(int capacity = 4)
    {
        _items = new T[capacity];
        _top = 0;
    }

    public bool IsEmpty => _top == 0;

    public void Push(T item)
    {
        if (_top == _items.Length)
        {
            // Dobler størrelsen hvis full
            Array.Resize(ref _items, _items.Length * 2);
        }
        _items[_top++] = item;
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty");

        _top--;
        return _items[_top];
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty");

        return _items[_top - 1];
    }
}

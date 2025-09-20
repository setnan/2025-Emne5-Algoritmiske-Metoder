namespace Oppgave2;


public class BinarySearch<T>(IComparer<T>? comparer = null)
    where T : IComparable<T>
{
    private readonly IComparer<T> _comparer = comparer ?? Comparer<T>.Default;
    private Node<T>? _root = null;
    private int _count;

    // List<int> numbers = new() { 50, 60, 61, 70, 75, 80, 85, 100, 110, 115, 118, 120, 128, 130, 140 };
    public int Count => _count;
    public bool IsEmpty => _count == 0;

    public int IndexNumber;


    // klasse for binærsøk-tre for å finne index
    public int IndexOf(T value)
    {
        Node<T>? current = _root;
        while (current != null)
        {
            int cmp = _comparer.Compare(value, current.Value);
            if (cmp == 0) return true;
        }
        return
    }


    public void SearchingBinary(T value)
    {
        if (_root == null)
        {
            _root = new Node<T>(value);
            _count++;
            return;
        }

        // start from the root
        Node<T> current = _root;
        while (true)
        {
            int cmp = _comparer.Compare(value, current.Value);

            // go left
            if (cmp < 0)
            {
                if (current.Left == null)
                {
                    // vi kan legge til noden her
                    current.Left = new Node<T>(value);
                    _count++; // increment count of nodes when adding a new node and going left 
                    return;
                }
                current = current.Left; // fortsett nedover til venstre
            }
            else // go right
            {
                if (current.Right == null)
                {
                    // vi kan legge til noden her
                    current.Right = new Node<T>(value);
                    _count++;
                    return;
                }
                current = current.Right; // fortsett nedover til høyre
            }
        }
    }
    // klasse for binærsøk-tre for å finne index

    public int Contains(T indexValue)
    {
        Node<T>? current = _root;
        while (current != null) // så lenge det finnes noder å sjekke
        {
            int cmp = _comparer.Compare(indexValue, current.Value);
            if (cmp == 0) return indexValue; // vi fant verdien

            // gå venstre eller høyre avhengig av sammenligningen
            current = (cmp < 0)
                ? current.Left
                : current.Right;
        }

        return false;
    }
}
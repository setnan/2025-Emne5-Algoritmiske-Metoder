using Datastrukturer;

namespace Datastrukturer;

public class SinglyLinkedList<T> : ISinglyLinkedList<T>, IEnumerable<T>



class Program
{
    static void Main()
    {
        // --- SinglyLinkedList ---
        var list = new SinglyLinkedList<int>();
        list.AddFirst(2);         // [2]
        list.AddLast(5);          // [2,5]
        list.AddFirst(1);         // [1,2,5]
        Console.WriteLine($"List Count: {list.Count}"); // 3
        Console.WriteLine($"Contains(2): {list.Contains(2)}"); // True
        Console.WriteLine($"Contains(9): {list.Contains(9)}"); // False

        Console.WriteLine("------------");
        Console.Write("List items: ");
        foreach (var x in list) Console.Write($"{x} "); // 1 2 5
        Console.WriteLine();

        Console.WriteLine("------------");
        Console.WriteLine($"Remove(2): {list.Remove(2)}");   // True, [1,5]
        Console.WriteLine($"Remove(9): {list.Remove(9)}");   // False
        Console.WriteLine($"Count after removes: {list.Count}"); // 2

        Console.WriteLine("------------");
        Console.Write("List now: ");
        foreach (var x in list) Console.Write($"{x} "); // 1 5
        Console.WriteLine();

        // --- Kanttilfelle-tester ---
        var s = new MyStack<int>();
        try { s.Pop(); throw new Exception("Pop skulle kaste exception."); }
        catch (InvalidOperationException) { Console.WriteLine("Stack underflow OK"); }

        var q2 = new MyQueue<int>(1);
        q2.Enqueue(42);
        Console.WriteLine(q2.Dequeue() == 42 ? "Queue OK" : "Queue FEIL");

        var cq2 = new CircularQueue<int>(2);
        cq2.Enqueue(1); cq2.Enqueue(2);
        try { cq2.Enqueue(3); throw new Exception("CQ enqueue skulle kaste ved full."); }
        catch (InvalidOperationException) { Console.WriteLine("CQ overflow OK"); }
        Console.WriteLine(cq2.Dequeue() == 1 ? "CQ OK" : "CQ FEIL");
    }
}

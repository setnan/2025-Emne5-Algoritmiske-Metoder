using System.Runtime.ConstrainedExecution;
using Datastrukturer.Interfaces;
using System.Linq;

namespace Datastrukturer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nCircular Queue test:");
            Console.WriteLine("-----------------------------");

            int capacity = 4;
            var cq = new CircularQueue<int>(capacity);

            Console.WriteLine($"Kapasitet er satt til {capacity}");

            try
            {
                cq.Enqueue(10);
                cq.Enqueue(20);
                cq.Enqueue(30);
                cq.Enqueue(40);
                cq.Enqueue(50);
                cq.Enqueue(60); // Dette skal kaste en feil
                Console.WriteLine($"Etter enqueue: {string.Join(", ", cq.PrintCircularQueue())}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Kunne ikke legge til alle elementer: {ex.Message}");
            }
            Console.WriteLine($"Nåværende elementer: {string.Join(", ", cq.PrintCircularQueue())}");
            Console.WriteLine($"Dequeue: {cq.Dequeue()}");
            Console.WriteLine($"Etter dequeue: {string.Join(", ", cq.PrintCircularQueue())}");

            cq.Enqueue(50);
            Console.WriteLine($"Etter enqueue(50): {string.Join(", ", cq.PrintCircularQueue())}");

            // Ser på topp-element
            Console.WriteLine($"Peek (topp element): {cq.Peek()}");

            // Tømmer køen helt
            while (!cq.IsEmpty)
            {
                Console.WriteLine($"Dequeue: {cq.Dequeue()}");
            }
            Console.WriteLine($"Er køen tom? {cq.IsEmpty}");
            // vise at køen er tom

            Console.WriteLine("\n-----------------------------");

            Console.WriteLine("\nSingly linked list test:\n-----------------------------");
            var list = new SinglyLinkedList<int>();
            list.AddLast(230);
            list.AddLast(231);
            Console.WriteLine($"Contains(33): {list.Contains(33)}");
            Console.WriteLine($"Antall elementer i listen? {list.Count}");

            // Legger til elementer først i sist i listen
            list.AddFirst(10);
            list.AddFirst(20);
            list.AddFirst(30);
            Console.WriteLine("Elementer i listen:");
            foreach (var item in list.PrintContent())
            {
                Console.WriteLine($"Index: {item.Item1}, Verdi: {item.Item2}");
            }
            Console.WriteLine("-----------------");
            list.AddLast(240);
            list.AddLast(250);
            list.AddLast(260);

            Console.WriteLine("-----------------");
            Console.WriteLine("Elementer i listen:");
            foreach (var item in list.PrintContent())
            {
                Console.WriteLine($"Index: {item.Item1}, Verdi: {item.Item2}");
            }

            Console.WriteLine("Antall elementer i listen: " + list.Count);
            Console.WriteLine($"Er tallet 10 i listen:{list.Contains(10)}");
            list.Remove(10);
            Console.WriteLine($"Hvor mange elementer er det i listen Før AddLast: {list.Count}");


            list.AddLast(33);
            list.AddLast(44);
            Console.WriteLine($"Hvor mange elementer er det i listen etter AddLast: {list.Count}");
            Console.WriteLine($"Er tallet 10 i listen:{list.Contains(10)}");

            Console.WriteLine("-----------------");
            Console.WriteLine("Elementer i listen:");
            foreach (var item in list.PrintContent())
            {
                Console.WriteLine($"Index: {item.Item1}, Verdi: {item.Item2}");
            }

            Console.WriteLine($"Hvor mange elementer er det i listen: {list.Count}");

            Console.WriteLine("\n-----------------");
            Console.WriteLine("Test av Contains");
            Console.WriteLine($"Contains(33): {list.Contains(33)}");
            Console.WriteLine($"Contains(99): {list.Contains(99)}");

        }
    }
}

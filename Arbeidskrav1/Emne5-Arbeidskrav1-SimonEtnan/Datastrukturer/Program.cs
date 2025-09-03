using System.Runtime.ConstrainedExecution;
using Datastrukturer.Interfaces;
using System.Linq;

namespace Datastrukturer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nCircular Queue test:\n-----------------------------");
            var capacity = 4;
            var cq = new CircularQueue<int>(capacity);




            Console.WriteLine("----------------------");

            Console.WriteLine($"Kapasitet er satt til {capacity}");
            Console.WriteLine($"Her er listen i sin helhet: {string.Join(", ", cq.PrintCircularQueue())}");
            cq.Enqueue(10);
            cq.Enqueue(20);
            cq.Enqueue(30);

            Console.WriteLine("Henter ut element:");
            Console.WriteLine(cq.Dequeue());

            cq.Enqueue(50);

            Console.WriteLine("Topp element er: " + cq.Peek());

            while (!cq.IsEmpty)
            {
                Console.WriteLine("Henter ut element: " + cq.Dequeue());
            }

            Console.WriteLine($"Her er listen i sin helhet: {string.Join(", ", cq.PrintCircularQueue())}");

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

namespace DemoDataStructures
{
    public static class Demo
    {
        public static void ArrayDemo()
        {
            int[] numbers = new int[5];
            numbers[0] = 10;
            numbers[1] = 20;
            numbers[2] = 30;
            numbers[3] = 40;
            numbers[4] = 50;

            // [10, 20, 30, 40, 50] - contents
            // [0 , 1, 2, 3, 4] - Indexes
            Console.WriteLine("Array contents:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            // Resize (dobler lengden)
            Array.Resize(ref numbers, newSize: numbers.Length * 2);
            Console.WriteLine("Array contents with new length:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            // Create new array with initial values
            var copy = (int[])numbers.Clone();
            copy[0] = 1;
            Console.WriteLine("Copy contents:");
            for (int i = 0; i < copy.Length; i++)
            {
                Console.WriteLine(copy[i]);
            }
        }

        public static void ListDemo()
        {
            var list = new List<string>();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("D");
            list.Add("E");

            Console.WriteLine($"List contents: {string.Join(", ", list)}");
            // [0, 1, 2, 3, 4] -> indexes

            list.RemoveAt(2); // remove item at index 2 ("C")
            Console.WriteLine($"List contents after removing index 2: {string.Join(", ", list)}");

            list.Insert(2, "Z"); // insert value "Z" at index 2
            Console.WriteLine($"List contents after inserting 'Z' at index 2: {string.Join(", ", list)}");

            list.Insert(2, "Y"); // insert value "Y" at index 2
            Console.WriteLine($"List contents after inserting 'Y' at index 2: {string.Join(", ", list)}");

            list[2] = "X"; // change value at index 2
            Console.WriteLine($"List contents after changing index 2 to 'X': {string.Join(", ", list)}");
        }

        public static void LinkedListDemo()
        {
            var linkedList = new LinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddLast(5);

            Console.WriteLine($"LinkedList contents: {string.Join(", ", linkedList)}");

            linkedList.AddFirst(0);
            Console.WriteLine($"LinkedList contents after adding 0 at the beginning: {string.Join(", ", linkedList)}");

            var node = linkedList.First!.Next; // get the second node (neste person)
            linkedList.AddAfter(node!, 100); // add 100 after the second node
            Console.WriteLine($"LinkedList contents after adding 100: {string.Join(", ", linkedList)}");

        }

        public static void StackDemo()
        {

            // LIFO - Last In, First Out
            var stack = new Stack<string>();
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");
            Console.WriteLine($"Stack contents: {string.Join(", ", stack)}");

            var item = stack.Pop(); // removes and returns the top item ("C")
            Console.WriteLine($"Popped from stack: {item}");
        }

        public static void QueueDemo()
        {
            // FIFO - First In, First Out
            var queue = new Queue<string>();
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");
            Console.WriteLine($"Queue contents: {string.Join(", ", queue)}");

            var item = queue.Dequeue(); // removes and returns the first item ("A")
            Console.WriteLine($"Dequeued from queue: {item}");
            Console.WriteLine($"Queue contents after dequeue: {string.Join(", ", queue)}");
        }   


    }
    
}
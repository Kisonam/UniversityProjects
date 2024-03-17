using BinarySort;

internal class Program
{
        static void Main(string[] args)
        {
            
            int[] elements = { 45, 27, 67, 36, 56, 15, 75, 31, 53, 39, 64 };
            BinaryTree tree = new BinaryTree();

            foreach (int element in elements)
            {
                tree.Insert(element);
            }

            Console.WriteLine("Wartości drzewa w porządku inorder:");
            tree.InorderTraversal();

        Console.ReadLine();
        }
}
using AVL_Sort;

internal class Program
{
    public static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();

        // Drukowanie zawartości drzewa z poprzednich laboratoriów
        tree.Insert(5);
        tree.Insert(3);
        tree.Insert(7);
        tree.Insert(2);
        tree.Insert(4);
        tree.Insert(6);
        tree.Insert(8);

        Console.WriteLine("Inorder Traversal:");
        tree.InorderTraversal();

        // Dodanie elementów, które sprawiają, że to drzewo jest niezrównoważone
        tree.Insert(9);
        tree.Insert(10);
        tree.Insert(11);

        Console.WriteLine("\n\nInorder Traversal after unbalancing:");
        tree.InorderTraversal();

        // Przywracanie równowagi drzewu
        Console.WriteLine("\n\nRebalancing the tree...");
        tree.Balance();

        Console.WriteLine("\n\nInorder Traversal after balancing:");
        tree.InorderTraversal();

        // Drukowanie zawartości drzewa za pomocą przechodzenia postorder
        Console.WriteLine("\n\nPostorder Traversal:");
        tree.PostorderTraversal();

        Console.ReadKey();
    }
}
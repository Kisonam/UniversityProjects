
namespace BinarySort
{
	public class BinaryTree
    {
        Node? root;

        public BinaryTree()
        {
            root = null; 
        }

        public void Insert(int value)
        {
            root = InsertRec(root, value);
        }

        private Node InsertRec(Node root, int value)
        {
            if (root == null)
            {
                root = new Node(value);
                return root;
            }

            if (value < root.Value)
                root.Left = InsertRec(root.Left, value);
            else if (value > root.Value)
                root.Right = InsertRec(root.Right, value);

            return root;
        }

        public void InorderTraversal()
        {
            InorderTraversal(root);
        }

        private void InorderTraversal(Node root)
        {
            if (root != null)
            {
                InorderTraversal(root.Left);
                Console.WriteLine(root.Value);
                InorderTraversal(root.Right);
            }
        }
    }
}


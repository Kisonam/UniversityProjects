using System;
namespace AVL_Sort
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
            Balance();
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

        private int Height(Node? node)
        {
            if (node == null)
                return 0;
            return Math.Max(Height(node.Left), Height(node.Right)) + 1;
        }

        private void RotateRight(ref Node parent)
        {
            Node pivot = parent.Left!;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            parent = pivot;
        }

        private void RotateLeft(ref Node parent)
        {
            Node pivot = parent.Right!;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            parent = pivot;
        }

        public void Balance()
        {
            Balance(ref root);
        }

        private void Balance(ref Node? node)
        {
            if (node == null)
                return;

            int balanceFactor = Height(node.Right) - Height(node.Left);

            if (balanceFactor > 1)
            {
                if (Height(node.Right!.Right) >= Height(node.Right.Left))
                    RotateLeft(ref node);
                else
                {
                    RotateRight(ref node.Right);
                    RotateLeft(ref node);
                }
            }
            else if (balanceFactor < -1)
            {
                if (Height(node.Left!.Left) >= Height(node.Left.Right))
                    RotateRight(ref node);
                else
                {
                    RotateLeft(ref node.Left);
                    RotateRight(ref node);
                }
            }
        }

        public void InorderTraversal()
        {
            InorderTraversal(root);
        }

        private void InorderTraversal(Node? root)
        {
            if (root != null)
            {
                InorderTraversal(root.Left);
                Console.WriteLine(root.Value);
                InorderTraversal(root.Right);
            }
        }

        public void PostorderTraversal()
        {
            PostorderTraversal(root);
        }

        private void PostorderTraversal(Node? root)
        {
            if (root != null)
            {
                PostorderTraversal(root.Left);
                PostorderTraversal(root.Right);
                Console.WriteLine(root.Value);
            }
        }
    }
}


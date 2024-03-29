using System;
namespace AVL_Sort
{
	public class Node
	{
        public int Value;
        public Node? Left;
        public Node? Right;

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
}


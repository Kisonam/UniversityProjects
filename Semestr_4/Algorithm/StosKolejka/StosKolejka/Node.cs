using System;
namespace StosKolejka
{
	public class Node
	{
        public (string, string) Data { get; set; }
        public Node Next { get; set; }

        public Node((string, string) data)
        {
            Data = data;
            Next = null;
        }
    }
}


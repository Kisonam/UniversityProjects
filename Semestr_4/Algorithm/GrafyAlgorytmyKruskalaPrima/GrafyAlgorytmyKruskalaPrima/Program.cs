// See https://aka.ms/new-console-template for more information
class Graph
{
    private int V;
    private List<Tuple<int, int>>[] adj;

    public Graph(int v)
    {
        V = v;
        adj = new List<Tuple<int, int>>[v];
        for (int i = 0; i < v; i++)
            adj[i] = new List<Tuple<int, int>>();
    }

    public void AddEdge(int source, int destination, int weight)
    {
        adj[source].Add(Tuple.Create(destination, weight));
        adj[destination].Add(Tuple.Create(source, weight));
    }

    public void PrimMST()
    {
        bool[] mstSet = new bool[V];
        int[] parent = new int[V];
        int[] key = new int[V];

        for (int i = 0; i < V; i++)
        {
            key[i] = int.MaxValue;
            parent[i] = -1;
        }

        key[0] = 0;

        for (int count = 0; count < V - 1; count++)
        {
            int u = MinKey(key, mstSet);
            mstSet[u] = true;

            foreach (var item in adj[u])
            {
                int v = item.Item1;
                int weight = item.Item2;
                if (!mstSet[v] && weight < key[v])
                {
                    parent[v] = u;
                    key[v] = weight;
                }
            }
        }

        Console.WriteLine("Minimalne Drzewo Rozpinające - Prim:");
        for (int i = 1; i < V; i++)
        {
            Console.WriteLine($"{parent[i]} -- {i} == {key[i]}");
        }
    }

    private int MinKey(int[] key, bool[] mstSet)
    {
        int min = int.MaxValue, minIndex = -1;

        for (int v = 0; v < V; v++)
            if (!mstSet[v] && key[v] < min)
            {
                min = key[v];
                minIndex = v;
            }

        return minIndex;
    }
}
internal class Program
{
    static void Main()
    {
        Graph g = new Graph(5);

        g.AddEdge(0, 1, 4);
        g.AddEdge(0, 2, 1);
        g.AddEdge(1, 2, 2);
        g.AddEdge(1, 3, 5);
        g.AddEdge(2, 3, 8);
        g.AddEdge(2, 4, 10);
        g.AddEdge(3, 4, 2);

        g.PrimMST();
    }
}
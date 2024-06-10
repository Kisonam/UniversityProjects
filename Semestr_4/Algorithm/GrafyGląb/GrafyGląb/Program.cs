// See https://aka.ms/new-console-template for more information

internal class Program
{
    // Struktura grafu
    class Graph
    {
        private int V; // Liczba węzłów
        private List<int>[] adj; // Listy sąsiedztwa

        // Konstruktor grafu
        public Graph(int v)
        {
            V = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; i++)
                adj[i] = new List<int>();
        }

        // Funkcja dodająca krawędź do grafu
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }

        // Funkcja DFS używająca rekurencji
        private void DFSUtil(int v, bool[] visited)
        {
            // Oznacz obecny węzeł jako odwiedzony i wypisz go
            visited[v] = true;
            Console.Write(v + " ");

            // Rekurencyjnie odwiedzaj wszystkie wierzchołki sąsiednie
            foreach (int n in adj[v])
            {
                if (!visited[n])
                    DFSUtil(n, visited);
            }
        }

        // Funkcja DFS do wywołania przez użytkownika
        public void DFS(int v)
        {
            // Oznacz wszystkie węzły jako nieodwiedzone (false)
            bool[] visited = new bool[V];

            // Wywołaj rekurencyjną funkcję DFS
            DFSUtil(v, visited);
        }
    }

    static void Main()
    {
        // Przykładowy graf
        Graph g = new Graph(6); // Zakładając, że węzły są numerowane od 0 do 4

        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 3);
        g.AddEdge(1, 4);
        g.AddEdge(2, 3);
        g.AddEdge(3, 4);
        g.AddEdge(4, 5);

        Console.WriteLine("Przeszukiwanie w głąb (DFS) zaczynając od węzła 0:");

        g.DFS(0);
        Console.WriteLine();
        g.DFS(1);
        Console.WriteLine();
        g.DFS(2);
        Console.WriteLine();
        g.DFS(3);

    }
}
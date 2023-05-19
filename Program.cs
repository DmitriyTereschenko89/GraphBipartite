namespace GraphBipartite
{
    internal class Program
    {
        public class GraphBipartite
        {
            private bool isBipartite;
            private void DFS(int[][] graph, int[] colors, int node, int color)
            {
                colors[node] = color;
                foreach(int adj in graph[node])
                {
                    if (colors[adj] == 0)
                    {
                        DFS(graph, colors, adj, -color);
                    }
                    else if (colors[adj] != -color)
                    {
                        isBipartite = false;
                        return;
                    }
                }
            }

            public bool IsBipartite(int[][] graph)
            {
                isBipartite = true;
                int n = graph.Length;
                int[] colors = new int[n];
                for (int node = 0; node < n; ++node)
                {
                    if (colors[node] == 0)
                    {
                        DFS(graph, colors, node, 1);
                    }
                }
                return isBipartite;
            }
        }
        static void Main(string[] args)
        {
            GraphBipartite graphBipartite = new();
            Console.WriteLine(graphBipartite.IsBipartite(new int[][]
            {
                new int[] { 1, 2, 3 }, new int[] { 0, 2 }, new int[] { 0, 1, 3 }, new int[] { 0, 2 }
            }));
            Console.WriteLine(graphBipartite.IsBipartite(new int[][]
            {
                new int[] { 1, 3 }, new int[] { 0, 2 }, new int[] { 1, 3 }, new int[] { 0, 2 }
            }));
            Console.WriteLine(graphBipartite.IsBipartite(new int[][]
            {
                new int[] { 4, 1 }, new int[] { 0, 2 }, new int[] { 1, 3 }, new int[] { 2, 4 }, new int[] { 3, 0 }
            }));
        }
    }
}
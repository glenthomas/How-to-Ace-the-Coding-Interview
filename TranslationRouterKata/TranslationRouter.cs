namespace TranslationRouterKata
{
    internal class TranslationRouter
    {
        private readonly Dictionary<string, List<string>> graph = new();

        public TranslationRouter(List<(string from, string to)> supportedPairs)
        {
            foreach (var (from, to) in supportedPairs)
            {
                if (!graph.ContainsKey(from))
                {
                    graph[from] = new List<string>();
                }
                if (!graph.ContainsKey(to))
                {
                    graph[to] = new List<string>();
                }
                graph[from].Add(to);
                graph[to].Add(from);
            }
        }

        public List<string> FindShortestPath(string from, string to)
        {
            if (!graph.ContainsKey(from) || !graph.ContainsKey(to))
            {
                return new List<string>();
            }

            var queue = new Queue<string>();
            var visited = new HashSet<string>();
            var parent = new Dictionary<string, string>();

            queue.Enqueue(from);
            visited.Add(from);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current == to)
                {
                    return ReconstructPath(parent, from, to);
                }

                foreach (var neighbour in graph[current])
                {
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(neighbour);
                        parent[neighbour] = current;
                        queue.Enqueue(neighbour);
                    }
                }
            }

            return new List<string>(); // No path found
        }

        private List<string> ReconstructPath(Dictionary<string, string> parent, string start, string end)
        {
            var path = new List<string>();
            string current = end;

            while (current != start)
            {
                path.Add(current);
                current = parent[current];
            }

            path.Add(start);
            path.Reverse();
            return path;
        }
    }
}

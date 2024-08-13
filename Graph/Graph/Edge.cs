namespace Graph
{
    /// <summary>
    /// Ребро
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// Отсюда.
        /// </summary>
        public Vertex From { get; set; }
        /// <summary>
        /// Сюда.
        /// </summary>
        public Vertex To { get; set; }


        public int Weight { get; set; }

        public Edge(Vertex from, Vertex to, int weight = 1)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"({From}; {To})";
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;

namespace Graph
{
    public class Graph
    {
        /// <summary>
        /// Вершины
        /// </summary>
        List<Vertex> Vertexes = new List<Vertex>();
        /// <summary>
        /// Ребра
        /// </summary>
        List<Edge> Edges = new List<Edge>();

        public int VertexCount => Vertexes.Count;
        public int EdgesCount => Edges.Count;


        public void AddVertex(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }
        public void AddEdge(Vertex from, Vertex to)
        {
            var edge = new Edge(from, to);
            Edges.Add(edge);
        }





        /// <summary>
        /// Делаем таблицу смежности.
        /// </summary>
        /// <returns></returns>
        public int[,] GetMatrix()
        {
            var matrix = new int[Vertexes.Count, Vertexes.Count];
            foreach (var edge in Edges)
            {
                var row = edge.From.Number;
                var column = edge.To.Number;

                matrix[row - 1, column - 1] = edge.Weight;
            }
            return matrix;
        }


        /// <summary>
        /// Собираем список ребер куда может идти ребро х
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public List<Vertex> GetVertexListls(Vertex vertex)
        {
            var result = new List<Vertex>();

            foreach (var edge in Edges)
            {
                if (edge.From == vertex)
                {
                    result.Add(edge.To);
                }
            }
            return result;
        }


        /// <summary>
        /// есть ли такая связь или нету, путь от старта до финиша.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public bool Wave(Vertex start, Vertex finish)
        {
            var list = new List<Vertex>
            {
                start
            };


            for (int i = 0; i < list.Count; i++)
            {
                var vertex = list[i];
                foreach (var v in GetVertexListls(vertex))
                {
                    if (!list.Contains(v))
                    {
                        list.Add(v);
                    }
                }
            }
            return list.Contains(finish);
        }

    }
}
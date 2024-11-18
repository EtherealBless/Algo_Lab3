using System;
using System.Collections.Generic;

namespace Lab3.LabCollections.YunPart.TREE_STACK_AND_OTHER.TopologicalSort
{
    public class Graph
    {
        private int vertices;
        private List<int>[] adjacencyList;

        public Graph(int vertices)
        {
            this.vertices = vertices;
            adjacencyList = new List<int>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                adjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            adjacencyList[v].Add(w);
        }

        public List<int>[] GetAdjacencyList()
        {
            return adjacencyList;
        }

        public int GetVertices()
        {
            return vertices;
        }
    }
}

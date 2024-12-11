using System;
using System.Collections.Generic;

public class DijkstraShortestPath
{
    public static int[] Dijkstra(int[,] graph, int startNode)
    {
        int n = graph.GetLength(0); 
        int[] distances = new int[n]; 
        bool[] visited = new bool[n]; 

        
        for (int i = 0; i < n; i++)
        {
            distances[i] = int.MaxValue;
            visited[i] = false;
        }

        distances[startNode] = 0;

        for (int i = 0; i < n - 1; i++)
        {
            
            int u = FindMinDistance(distances, visited);
            visited[u] = true;

            
            for (int v = 0; v < n; v++)
            {
                if (!visited[v] && graph[u, v] != 0 &&
                    distances[u] != int.MaxValue &&
                    distances[u] + graph[u, v] < distances[v])
                {
                    distances[v] = distances[u] + graph[u, v];
                }
            }
        }

        return distances;
    }

    
    private static int FindMinDistance(int[] distances, bool[] visited)
    {
        int minDistance = int.MaxValue;
        int minIndex = -1;

        for (int i = 0; i < distances.Length; i++)
        {
            if (!visited[i] && distances[i] <= minDistance)
            {
                minDistance = distances[i];
                minIndex = i;
            }
        }

        return minIndex;
    }

    
    public static void TestDijkstra()
    {
        Console.WriteLine("Введите количество узлов в графе:");
        int nodesCount = int.Parse(Console.ReadLine());

        int[,] graph = new int[nodesCount, nodesCount];
        Console.WriteLine("Введите матрицу смежности (разделяя значения пробелом):");

        for (int i = 0; i < nodesCount; i++)
        {
            string[] row = Console.ReadLine().Split(' ');
            for (int j = 0; j < nodesCount; j++)
            {
                graph[i, j] = int.Parse(row[j]);
            }
        }

        Console.WriteLine("Введите начальный узел:");
        int startNode = int.Parse(Console.ReadLine());

        int[] distances = Dijkstra(graph, startNode);

        Console.WriteLine("Кратчайшие расстояния от узла {0}:", startNode);
        for (int i = 0; i < distances.Length; i++)
        {
            Console.WriteLine($"До узла {i}: {distances[i]}");
        }
    }

    
    public static void Main()
    {
        TestDijkstra();
    }
}

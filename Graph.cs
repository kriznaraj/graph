using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
	public class Node<T> : IComparable<Node<T>> where T : struct
	{
		public T data;
		public int distance;

		public int CompareTo(Node<T> other)
		{
			return this.distance.CompareTo(other.distance);
		}
	}

	public class Graph<T> where T : struct
	{
		private Dictionary<T, List<T>> graph;

		public Dictionary<T, List<T>> InitGraph(bool undirected = false)
		{
			graph = new Dictionary<T, List<T>>();

			Action<T,T> addNode = (src,dest) => {
				if (!graph.ContainsKey(src))
					graph.Add(src, new List<T>());

				graph[src].Add(dest);
			};

			var n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				var tmp = Console.ReadLine().Split(' ').Select(Parse).ToArray();
				addNode(tmp[0], tmp[1]);

				if(undirected) 
				{
					addNode(tmp[1], tmp[0]);
				}
			}

			return graph;
		}

		private static T Parse(string text)
		{
			return (T)Convert.ChangeType(text, typeof(T));
		}

		public IEnumerable<T> ToplogicalSort()
		{
			var visited = new Dictionary<T, bool>();
			var sorted = new List<T>();

			foreach (var item in graph.Keys)
			{
				TopologicalSort(visited, sorted, item);
			}

			sorted.Reverse();
			return sorted;
		}

		private void TopologicalSort(Dictionary<T, bool> visited, List<T> sorted, T node)
		{
			if (!visited.ContainsKey(node))
			{
				visited.Add(node, true);
				if (graph.ContainsKey(node))
				{
					foreach (var item in graph[node])
					{
						TopologicalSort(visited, sorted, item);
					}
				}
				sorted.Add(node);
			}
		}
	}
}

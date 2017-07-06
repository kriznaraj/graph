using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
	public class Graph<T> where T : struct
	{

		private Dictionary<T, List<T>> graph;
		public Dictionary<T, List<T>> InitGraph()
		{
			graph = new Dictionary<T, List<T>>();

			var n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				var tmp = Console.ReadLine().Split(' ').Select(Parse).ToArray();
				if (!graph.ContainsKey(tmp[0]))
					graph.Add(tmp[0], new List<T>());

				graph[tmp[0]].Add(tmp[1]);
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
				TS(visited, sorted, item);
			}

			sorted.Reverse();
			return sorted;
		}

		private void TS(Dictionary<T, bool> visited, List<T> sorted, T node)
		{
			if (!visited.ContainsKey(node))
			{
				visited.Add(node, true);
				if (graph.ContainsKey(node))
				{
					foreach (var item in graph[node])
					{
						TS(visited, sorted, item);
					}
				}
				sorted.Add(node);
			}
		}
	}
}

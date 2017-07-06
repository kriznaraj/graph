using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph<char>();
            graph.InitGraph();
            var sorted = graph.ToplogicalSort();

            foreach (var item in sorted)
            {
                Console.WriteLine(item);
            }
            
            Console.ReadKey();
        }
    }
}

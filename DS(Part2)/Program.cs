using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DS_Part2_
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("graph.txt");
            Graph graph = new Graph();
            graph.AddNode(int.Parse(reader.ReadLine().Split()[0]));
            string input = reader.ReadLine();
            while (input != "\n" && input != null)
            {
                graph.Connect(int.Parse(input.Split()[0]), int.Parse(input.Split()[1]));
                input = reader.ReadLine();
            }
            graph.FindEilerCycles();
            Console.ReadKey();
        }
    }
}

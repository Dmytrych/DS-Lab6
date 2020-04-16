using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DS_Lab6_1_
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
                graph.Connect(int.Parse(input.Split()[0]), int.Parse(input.Split()[1]), int.Parse(input.Split()[2]));
                input = reader.ReadLine();
            }
            Stack<int> EilerCycle = new Stack<int>();
            graph.FindGamiltonCycles(0, ref EilerCycle);
            foreach  (int i in new Stack<int>(EilerCycle))
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }
    }
}

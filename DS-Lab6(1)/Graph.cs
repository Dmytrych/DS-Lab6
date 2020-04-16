using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Lab6_1_
{
    class Graph
    {
        public List<List<Connection>> connections;
        private int connectionNum = 0;
        public Graph()
        {
            connections = new List<List<Connection>>();
        }
        public void AddNode()
        {
            connections.Add(new List<Connection>());
        }
        public void AddNode(int num)
        {
            for (int i = 0; i < num; i++)
            {
                connections.Add(new List<Connection>());
            }
        }
        public void Connect(int index1, int index2, int value)
        {
            if(index1 < connections.Count && index2 < connections.Count)
            {
                connections[index1].Add(new Connection(index1, index2, value));
                connections[index2].Add(new Connection(index2, index1, value));
                connectionNum++;
            }
        }
        public void RemoveNode(int index) //Beta Version
        {
            connections.Remove(connections[index]);
        }
        public void FindGamiltonCycles(int index, ref Stack<int> answer)
        {
            answer.Push(index);
            foreach(Connection c in connections[index])
            {
                if (!answer.Contains(c.InNode))
                {
                    FindGamiltonCycles(c.InNode, ref answer);
                }
            }
            if (answer.Count != connections.Count)
                answer.Pop();
            else if (index == answer.Peek())
            {
                bool connectedToStartingVert = false;
                foreach (Connection c in connections[answer.Peek()])
                {
                    if (c.InNode == new Stack<int>(answer).Peek())
                    {
                        connectedToStartingVert = true;
                        break;
                    }
                }
                if (!connectedToStartingVert)
                {
                    Console.WriteLine("Нет Гамильтонова цикла");
                    Console.WriteLine("Гамильтонов путь:");
                }
            }
            if (answer.Count == 0)
                Console.WriteLine("Не существует Гамильтонова пути");
        }
    }
}

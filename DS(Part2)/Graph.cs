using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Part2_
{
    class Graph
    {
        public List<List<Connection>> connections;
        private int connectionCount = 0;
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
        public Connection Connect(int index1, int index2)
        {
            if(index1 < connections.Count && index2 < connections.Count)
            {
                Connection temp = new Connection(index1, index2);
                connections[index1].Add(temp);
                connections[index2].Add(temp);
                connectionCount++;
                return temp;
            }
            return null;
        }
        public void DeleteConnection(int index1, int index2)
        {
            Connection toDelete = null;
            foreach(Connection c in connections[index1])
            {
                if((c.NodeOne == index1 && c.NodeTwo == index2) || (c.NodeOne == index2 && c.NodeTwo == index1))
                {
                    toDelete = c;
                    break;
                }
            }
            if(toDelete != null)
            {
                connections[index1].Remove(toDelete);
                connections[index2].Remove(toDelete);
            }
        }
        public void RemoveNode(int index) //Beta Version
        {
            connections.Remove(connections[index]);
        }
        public void FindEilerCycles()
        {
            bool eilerCycle = true;
            bool eilerPath = true;
            int changeCounter = 0;
            int[] unpairedIndex = new int[2];
            for (int i = 0; i < connections.Count; i++)
            {
                if(connections[i].Count % 2 != 0)
                {
                    eilerCycle = false;
                    if (changeCounter < 2)
                    {
                        unpairedIndex[changeCounter] = i;
                    }
                    if (changeCounter < 3)
                    {
                        eilerPath = !eilerPath;
                    }
                    changeCounter++;
                }
            }
            if(!eilerPath && !eilerCycle)
            {
                Console.WriteLine("Не Эйлеров граф");
                return;
            }
            else if (eilerCycle)
            {
                List<Connection> visited = new List<Connection>();
                Visit(0, visited);
                Console.WriteLine("Эйлеров цикл:");
                foreach (Connection c in visited)
                {
                    Console.WriteLine(c.NodeOne + " - " + c.NodeTwo);
                }
            }
            else if (eilerPath)
            {
                Connection tempConnection = Connect(unpairedIndex[0], unpairedIndex[1]);
                List<Connection> visited = new List<Connection>();
                Visit(0, visited);
                //for (int i = 0; i < visited.IndexOf(tempConnection); i++)
                //{
                //    visited.Add(visited[i]);
                //}
                //visited.RemoveRange(0, visited.IndexOf(tempConnection) + 1);
                //DeleteConnection(unpairedIndex[0], unpairedIndex[1]);
                Console.WriteLine("Эйлеров путь:");
                foreach(Connection c in visited)
                {
                    Console.WriteLine(c.NodeOne + " - " + c.NodeTwo);
                }
            }
        }
        public void Visit(int currentVert, List<Connection> visited)
        {
            foreach(Connection c in connections[currentVert])
            {
                if (!visited.Contains(c))
                {
                    visited.Add(c);
                    if (c.NodeOne == currentVert)
                        Visit(c.NodeTwo, visited);
                    else Visit(c.NodeOne, visited);
                }
            }
            if(visited.Count != connectionCount)
            {
                visited.RemoveAt(visited.Count - 1);
            }
        }
    }
}

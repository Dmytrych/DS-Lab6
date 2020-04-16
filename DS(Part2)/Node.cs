using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Part2_
{
    class Connection
    {
        public int NodeOne { get; private set; }
        public int NodeTwo { get; private set; }
        public Connection(int index1, int index2)
        {
            NodeOne = index1;
            NodeTwo = index2;
        }
    }
}

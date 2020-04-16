using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DS_Lab6_1_
{
    class Connection : IComparable
    {
        public int OutNode { get; private set; }
        public int InNode { get; private set; }
        public int Value { get; private set; }
        public Connection(int outNode, int inNode, int value)
        {
            OutNode = outNode;
            InNode = inNode;
            Value = value;
        }
        public int CompareTo(object ob)
        {
            return this.OutNode.CompareTo((ob as Connection).OutNode);
        }
        public void SetValue(int newValue)
        {
            Value = newValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Graph
{
    public class Node
    {
        public string name;
        public List<Node> children = new List<Node>();

        public Node(string name)
        {
            this.name = name;
        }

        public Node AddChildren(string value)
        {
            Node child = new Node(value);
            children.Add(child);
            return child;      
        
        }
    }
}

using System.Collections.Generic;

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

        public List<string> DepthFirstSearch(List<string> array)
        {
            array.Add(this.name);
            foreach (var child in this.children)
            {
                child.DepthFirstSearch(array);
            }
            return array;
        }


        //TODO: Work in progress
        public List<string> DepthFirstSearchIterative(List<string> array)
        {
            HashSet<string> visited = new HashSet<string>();

            var stack = new Stack<Node>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                var popedValue = stack.Pop();
                array.Add(popedValue.name);

                if (!visited.Contains(popedValue.name))
                {
                    visited.Add(popedValue.name);
                }

                for (int i = 0; i < popedValue.children.Count; i++)
                {
                    var child = popedValue.children[i];
                    if (!visited.Contains(child.name))
                    {
                        stack.Push(child);
                    }
                }

            }
            
            return array;
        }

        public List<string> BreadthFirstSearch(List<string> array)
        {
            HashSet<string> visited = new HashSet<string>();
            var queue = new Queue<Node>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentValue = queue.Dequeue();

                if (!visited.Contains(currentValue.name))
                {
                    visited.Add(currentValue.name);
                }
                array.Add(currentValue.name);

                foreach (var child in currentValue.children)
                {
                    if (!visited.Contains(child.name))
                    {
                        queue.Enqueue(child);
                    }
                }

            }          

            return array;
        }

        public Node AddChildren(string value)
        {
            Node child = new Node(value);
            children.Add(child);
            return child;      
        
        }
    }
}

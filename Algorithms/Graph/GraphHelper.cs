using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Graph
{
    public class GraphHelper
    {
        public static int MaxDepth(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            int depth = 0;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++) //Loop All level Sibblings
                {
                   var currentNode = queue.Dequeue();
                    foreach (var child in currentNode.children)
                    {
                        queue.Enqueue(child);
                    }
                }

                depth++;
            }
            return depth;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Algorithms.BST
{
    public class BSTHelper
    {
        public static int FindClosestValueInBst(BST tree, int target)
        {
            BST currentNode = tree;
            int closest = int.MaxValue;

            while (currentNode != null)
            {
                if (Math.Abs(target- closest) > Math.Abs(target - currentNode.value))
                {
                    closest = currentNode.value;
                }

                if (target > currentNode.value)
                {
                    currentNode = currentNode.right;
                }
                else if(target < currentNode.value)
                {
                    currentNode = currentNode.left;
                }
                else
                {
                    break;
                }
            }

            return closest;
        }

        public static List<int> BranchSums(BinaryTree root)
        {
            var output = new List<int>();
            BranchSumHelper(root,0, output);          
            return output;
        }

        private static void BranchSumHelper(BinaryTree node, int runningSum, List<int> result)
        {         
            if (node == null)
            {
                return;
            }

            runningSum += node.value;

            if (node.left == null && node.right == null)
            {
                result.Add(runningSum);
                return;
            }

            BranchSumHelper(node.left, runningSum, result);
            BranchSumHelper(node.right, runningSum, result);

        }

        public static int NodeDepths(BinaryTree root)
        {
            return NodeDepthHelper(root, 0);
        }

        private static int NodeDepthHelper(BinaryTree node, int depth)
        {
            if (node == null)
            {
                return 0;
            }          

            return depth + NodeDepthHelper(node.left, depth+ 1) + NodeDepthHelper(node.right, depth + 1);

        }

    }
}

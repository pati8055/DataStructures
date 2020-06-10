using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

namespace Algorithms.BST
{
    public class TreeHelper
    {
        public static int FindClosestValueInBst(Tree tree, int target)
        {
            Tree currentNode = tree;
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

        public static bool IsSameTree(Tree p, Tree q)
        {

            if (p == null && q == null)
            {
                return true;
            }
            
            if (p == null || q== null)
            {
                return false;
            }

            if (p.value != q.value)
            {
                return false;
            }

            return IsSameTree(p.left,q.left) && IsSameTree(p.right, q.right);
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

        #region Tree Traversals

        //Inorder (Left, Root, Right) 
        public List<int> InorderTraversal(Tree root)
        {
            List<int> result = new List<int>();
            Stack<Tree> stack = new Stack<Tree>();
            Tree current = root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                current = stack.Pop();
                result.Add(current.value);
                current = current.right;
            }
            return result;
        }

        //Preorder(Root, Left, Right) 
        public IList<int> PreorderTraversal(Tree root)
        {
            List<int> result = new List<int>();
            Stack<Tree> stack = new Stack<Tree>();
            Tree current = root;

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    result.Add(current.value);
                    stack.Push(current);
                    current = current.left;
                }
                  current = stack.Pop();
                  current = current.right;                
            }
            return result;
        }

        //Postorder (Left, Right, Root)
        public List<int> PostorderTraversal(Tree root)
        {
            List<int> result = new List<int>();
            Stack<Tree> stack = new Stack<Tree>();
            Tree current = root;

            stack.Push(current);

            while (current != null || stack.Count > 0)
            {                
                result.Add(current.value);
                while (current != null)
                {
                    current = current.left;
                }
                current = stack.Pop();
                current = current.right;
            }
            return result;
        }
        #endregion

    }
}

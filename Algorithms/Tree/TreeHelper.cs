using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Algorithms.BST
{
    public class TreeHelper
    {
        public static int FindClosestValueInBst(Tree tree, int target)
        {
            Tree current = tree;
            int closest = tree.value;

            while (current != null)
            {
                if (Math.Abs(target- closest) > Math.Abs(target - current.value))
                {
                    closest = current.value;
                }

                if (target > current.value)
                {
                    current = current.right;
                }
                else if(target < current.value)
                {
                    current = current.left;
                }
                else
                {
                    break;
                }
            }

            return closest;
        }

        public static int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            /* get the height of left and right sub trees */
            int lheight = HeightTree(root.left);
            int rheight = HeightTree(root.right);

            /* get the diameter of left and right subtrees */
            int ldiameter = DiameterOfBinaryTree(root.left);
            int rdiameter = DiameterOfBinaryTree(root.right);

            /* Return max of following three 
              1) Diameter of left subtree 
             2) Diameter of right subtree 
             3) Height of left subtree + height of right subtree*/
            return Math.Max(lheight + rheight ,Math.Max(ldiameter, rdiameter));
        }

        private static int HeightTree(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftHeight = HeightTree(root.left);
            int rightHeight = HeightTree(root.right);

            return (1 + Math.Max(leftHeight, rightHeight));
        }

        public static int RangeSumBST(TreeNode root, int L, int R)
        {
            int result = 0;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode poppedItem = stack.Pop();

                if (poppedItem != null)
                {
                    if (poppedItem.val >= L && poppedItem.val <= R)
                    {
                        result += poppedItem.val;
                    }

                    if (poppedItem.val > L)
                    {
                        stack.Push(poppedItem.left);
                    }

                    if (poppedItem.val < R)
                    {
                        stack.Push(poppedItem.right);
                    }
                }
            }

            return result;
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

        public bool IsSymmetric(Tree root)
        {
            return IsSymmetric(root, root);
        }
        private bool IsSymmetric(Tree root1,Tree root2)
        {
            if (root1 == null && root2 == null)
            {
                return true;
            }

            if (root1 == null || root2 == null)
            {
                return false;
            }

            if (root1.value != root2.value)
            {
                return false;
            }

            return IsSymmetric(root1.left,root2.right)
                && IsSymmetric(root1.right, root2.left);
        }


        public static bool IsValidBST(Tree root)
        {
            return IsValidBSTHelper(root,null, null);

        }
        private static bool IsValidBSTHelper(Tree root,int? minVal,int? maxVal)
        {
            if (root == null)
            {
                return true;
            }
            int value = root.value;

            if (minVal != null && value <= minVal)
            {
                return false;
            }

            if (maxVal != null && value >= maxVal)
            {
                return false;
            }

            return IsValidBSTHelper(root.right,value,maxVal) && IsValidBSTHelper(root.left,minVal,value);
        }

        public static int MaxDepth(Tree root)
        {
            if (root == null)
            {
                return 0;
            }

            int left = 1 + MaxDepth(root.left);
            int right = 1 + MaxDepth(root.right);

            return Math.Max(left, right);
        }              

        public int MinDepth(Tree root)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.right == null && root.left == null)
            {
                return 1;
            }

            // If left subtree is NULL, recur for right subtree  
            if (root.left == null)
            {
                return MinDepth(root.right) + 1;
            }

            // If right subtree is NULL, recur for left subtree  
            if (root.right == null)
            {
                return MinDepth(root.left) + 1;
            }

            return Math.Min(MinDepth(root.left), MinDepth(root.right)) + 1;
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

        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            TreeNode right = InvertTree(root.right);
            TreeNode left = InvertTree(root.left);

            root.right = left;
            root.left = right;
            return root;
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
        public IList<int> PreorderTraversal(TreeNode root)
        {            
            List<int> result =new List<int>();
            if (root == null)
            {
                return result;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                result.Add(node.val);
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
                if (node.left != null)
                {
                    stack.Push(node.left);
                }
            }
            return result;
        }

        //Postorder(Left, Right, root) 
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
            {
                return result;
            }

            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();

            stack1.Push(root);
            while (stack1.Count > 0)
            {
                TreeNode node = stack1.Pop();

                if (node.left != null) //This is key difference Left & Right
                {
                    stack1.Push(node.left);
                }

                if (node.right != null)
                {
                    stack1.Push(node.right);
                }              

                stack2.Push(node);
            }

            while (stack2.Count > 0)
            {
                TreeNode node = stack2.Pop();
                result.Add(node.val);
            }
            return result;
        }

        public static IList<IList<int>> LevelOrder(Tree root)
        {
            var result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            Queue<Tree> queue = new Queue<Tree>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var level = new List<int>();
                var count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var peekValue = queue.Dequeue();
                    level.Add(peekValue.value);
                    if (peekValue.left != null)
                    {
                        queue.Enqueue(peekValue.left);
                    }

                    if (peekValue.right != null)
                    {
                        queue.Enqueue(peekValue.right);
                    }
                }

                result.Add(level);
            }

            return result;
        }

        public static IList<IList<int>> ZigzagLevelOrder(Tree root)
        {
            var result = new List<IList<int>>();

            if (root == null)
            {
                return result;
            }

            Queue<Tree> queue = new Queue<Tree>();
            queue.Enqueue(root);
            bool zigzag = false;
            while (queue.Count > 0)
            {
                var level = new LinkedList<int>();
                int count = queue.Count;

                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();

                    if (zigzag)
                    {
                        level.AddFirst(node.value);
                    }
                    else
                    {
                        level.AddLast(node.value);
                    }

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                result.Add(level.ToList());
                zigzag = !zigzag;
            }

            return result;
        }
        #endregion

        #region Tree Construction
        public static Tree SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0)
            {
                return null;
            }

            return ConstructBinaryTreeFromArray(nums, 0, nums.Length - 1);

        }
        private static Tree ConstructBinaryTreeFromArray(int[] nums,int left, int right)
        {
            if (left > right)
            {
                return null;
            }
            int midpoint = left + (right - left) / 2; //TO Avoid integer overflow
            Tree root = new Tree(nums[midpoint]);
            root.left = ConstructBinaryTreeFromArray(nums, left, midpoint - 1);
            root.right = ConstructBinaryTreeFromArray(nums, midpoint + 1, right);
            return root;
        }

        public static TreeNode BstFromPreorder(int[] preorder)
        {
            int[] inOrder = (int[])preorder.Clone();
            Array.Sort(inOrder);
            return BuildTreeHelper(0, 0, inOrder.Length - 1, preorder, inOrder);
        }

        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return BuildTreeHelper(0, 0, inorder.Length - 1, preorder, inorder);
        }
        private static TreeNode BuildTreeHelper(int preStart,int inStart,int inEnd ,int[] preorder, int[] inorder)
        {
            if (preStart > preorder.Length -1 || inStart > inEnd)
            {
                return null;
            }

            TreeNode root = new TreeNode(preorder[preStart]);

            int inIndex = 0;

            for (int i = inStart; i <= inEnd; i++)
            {
                if (root.val == inorder[i])
                {
                    inIndex = i;
                }
            }

            root.left = BuildTreeHelper(preStart + 1, inStart, inIndex - 1, preorder, inorder);
            //(inIndex - inStart) is the size of root's left subtree.
            root.right = BuildTreeHelper(preStart + (inIndex - inStart) + 1, inIndex + 1, inEnd, preorder, inorder);

            return root;
        }


        public static string Tree2str(TreeNode t)
        {
            if (t ==  null)
            {
                return string.Empty;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            HashSet<TreeNode> visited = new HashSet<TreeNode>();
            var resultString = new StringBuilder();
            stack.Push(t);
            
            while (stack.Count > 0)
            {
                var peekedValue = stack.Peek();

                if (visited.Contains(peekedValue))
                {
                   stack.Pop();
                   resultString.Append(")");
                }
                else
                {
                    visited.Add(peekedValue);
                    resultString.Append("(" + peekedValue.val);
                    if (peekedValue.right != null && peekedValue.left == null)
                    {
                        resultString.Append("()");
                    }
                    if (peekedValue.right != null)
                    {
                        stack.Push(peekedValue.right);
                    }

                    if (peekedValue.left != null)
                    {
                        stack.Push(peekedValue.left);
                    }
                }
            }

            return resultString.ToString().Substring(1, resultString.Length-1);
        }

        #endregion
    }
}

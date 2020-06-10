using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.BST
{
    public class Tree
    {
        public int value;
        public Tree left;
        public Tree right;

        public Tree(int value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
    }

    public class BinaryTree
    {
        public int value;
        public BinaryTree left;
        public BinaryTree right;

        public BinaryTree(int value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
    }
}

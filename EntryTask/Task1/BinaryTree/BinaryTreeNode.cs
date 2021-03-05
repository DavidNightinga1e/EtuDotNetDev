using System;

namespace Task1.BinaryTree
{
    internal class BinaryTreeNode<TK, TV> where TK : IComparable<TK>
    {
        internal TK Key;
        internal TV Value;
        internal BinaryTreeNode<TK, TV> Lower;
        internal BinaryTreeNode<TK, TV> Higher;
    }
}
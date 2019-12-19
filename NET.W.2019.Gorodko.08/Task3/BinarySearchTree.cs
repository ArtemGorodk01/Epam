using System;
using System.Collections.Generic;

namespace Task3
{
    /// <summary>
    /// Provides working with binary search tree.
    /// </summary>
    /// <typeparam name="T">The type of elements of the tree.</typeparam>
    public class BinarySearchTree<T>
    {
        #region Private fields

        private Node<T> root;

        private Func<T, T, int> compare;

        #endregion

        #region Constructor

        /// <summary>
        /// Initials the new tree.
        /// </summary>
        /// <param name="value">The value for the root.</param>
        /// <param name="comparer">The comparer.</param>
        public BinarySearchTree(T value, IComparer<T> comparer = null)
        {
            this.root = new Node<T>(value);
            var tempComparer = comparer ?? Comparer<T>.Default;
            compare = tempComparer.Compare;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Adds new value to the binary tree.
        /// </summary>
        /// <param name="value">The value to add.</param>
        public void AddElement(T value)
        {
            root = AddElement(root, value);
        }

        /// <summary>
        /// Deletes all elements from binary tree.
        /// </summary>
        public void DeleteAll()
        {
            root = null;
        }

        /// <summary>
        /// Preorder traverse.
        /// </summary>
        /// <returns>Preorder traverse.</returns>
        public IEnumerable<T> Preorder() => Preorder(root);

        /// <summary>
        /// Inorder traverse.
        /// </summary>
        /// <returns>Inorder traverse.</returns>
        public IEnumerable<T> Inorder() => Inorder(root);

        /// <summary>
        /// Postorder traverse.
        /// </summary>
        /// <returns>Postorder traverse.</returns>
        public IEnumerable<T> Postorder() => Postorder(root);

        #endregion

        #region Private methods

        private IEnumerable<T> Preorder(Node<T> node)
        {
            yield return node.Value;

            if (node.Left != null)
            {
                foreach (var item in Preorder(node.Left))
                {
                    yield return item;
                }
            }

            if (node.Right != null)
            {
                foreach (var item in Preorder(node.Right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> Inorder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var item in Inorder(node.Left))
                {
                    yield return item;
                }
            }

            yield return node.Value;

            if (node.Right != null)
            {
                foreach (var item in Inorder(node.Right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> Postorder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var item in Postorder(node.Left))
                {
                    yield return item;
                }
            }

            if (node.Right != null)
            {
                foreach (var item in Postorder(node.Right))
                {
                    yield return item;
                }
            }

            yield return node.Value;
        }

        private Node<T> AddElement(Node<T> node, T value)
        {
            if (node == null)
            {
                return new Node<T>(value);
            }

            if (this.compare(value, node.Value) < 0)
            {
                node.Left = AddElement(node.Left, value);
            }
            else
            {
                node.Right = AddElement(node.Right, value);
            }

            return node;
        }

        #endregion

        #region Node

        /// <summary>
        /// The node of the tree.
        /// </summary>
        /// <typeparam name="Q">Type of the tree.</typeparam>
        internal class Node<Q>
        {
            /// <summary>
            /// Initials new node.
            /// </summary>
            /// <param name="value">The value.</param>
            public Node(Q value)
            {
                this.Value = value;
                this.Left = null;
                this.Right = null;
            }

            /// <summary>
            /// The value.
            /// </summary>
            public Q Value { get; }

            /// <summary>
            /// Left node.
            /// </summary>
            public Node<Q> Left { get; set; }

            /// <summary>
            /// Right node.
            /// </summary>
            public Node<Q> Right { get; set; }
        }

        #endregion
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    /// <summary>
    /// Provides working with bimary search tree.
    /// </summary>
    /// <typeparam name="T">The type of elements of the tree.</typeparam>
    public class BinarySearchTree<T>
    {
        #region Private fields

        private Node<T> root;

        private Func<T, T, int> compare;

        #endregion

        #region Constructor

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
            var newNode = new Node<T>(value);

            Node<T> tempNode = this.root;
            while (tempNode != null)
            {
                if (this.compare(newNode.Value, tempNode.Value) < 0)
                {
                    tempNode = tempNode.Left;
                }
                else
                {
                    tempNode = tempNode.Right;
                }
            }

            tempNode = newNode;
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
            yield return root.Value;

            foreach (var item in Preorder(node.Left))
            {
                yield return item;
            }

            foreach (var item in Preorder(node.Right))
            {
                yield return item;
            }
        }

        private IEnumerable<T> Inorder(Node<T> node)
        {
            foreach (var item in Inorder(node.Left))
            {
                yield return item;
            }

            yield return root.Value;

            foreach (var item in Inorder(node.Right))
            {
                yield return item;
            }
        }

        private IEnumerable<T> Postorder(Node<T> node)
        {
            foreach (var item in Postorder(node.Left))
            {
                yield return item;
            }

            foreach (var item in Postorder(node.Right))
            {
                yield return item;
            }

            yield return root.Value;
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

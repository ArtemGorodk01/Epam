using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Task3.Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        #region Int tests

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 1, 5, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 5 }, new int[] { 1, 2, 5, 3, 4, 5 })]
        public void Inorder_TypeParameterIsInt_ComparerIsDefault(int[] expected, int[] parameters)
        {
            var tree = new BinarySearchTree<int>(parameters[0]);
            for (int i = 1; i < parameters.Length; i++)
            {
                tree.AddElement(parameters[i]);
            }

            var areSame = AreSame<int>(tree.Inorder(), expected, (a, b) => a == b);

            Assert.IsTrue(areSame);
        }

        [TestCase(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, new int[] { 2, 1, 5, 3, 4 })]
        [TestCase(new int[] { 5, 5, 4, 3, 2, 1 }, new int[] { 1, 2, 5, 3, 4, 5 })]
        public void Inorder_TypeParameterIsInt_ComparerIsCustom(int[] expected, int[] parameters)
        {
            var comparer = new CustomIntComparer();
            var tree = new BinarySearchTree<int>(parameters[0], comparer);
            for (int i = 1; i < parameters.Length; i++)
            {
                tree.AddElement(parameters[i]);
            }

            var areSame = AreSame<int>(tree.Inorder(), expected, (a, b) => a == b);

            Assert.IsTrue(areSame);
        }

        [TestCase(new int[] { 3, 2, 1, 4, 6, 5, 7 }, new int[] { 3, 4, 6, 7, 5, 2, 1 })]
        public void Preorder_TypeParameterIsInt_ComparerIsDefault(int[] expected, int[] parameters)
        {
            var tree = new BinarySearchTree<int>(parameters[0]);
            for (int i = 1; i < parameters.Length; i++)
            {
                tree.AddElement(parameters[i]);
            }

            var areSame = AreSame<int>(tree.Preorder(), expected, (a, b) => a == b);

            Assert.IsTrue(areSame);
        }

        [TestCase(new int[] { 1, 2, 5, 7, 6, 4, 3 }, new int[] { 3, 4, 6, 7, 5, 2, 1 })]
        public void Postorder_TypeParameterIsInt_ComparerIsDefault(int[] expected, int[] parameters)
        {
            var tree = new BinarySearchTree<int>(parameters[0]);
            for (int i = 1; i < parameters.Length; i++)
            {
                tree.AddElement(parameters[i]);
            }

            var areSame = AreSame<int>(tree.Postorder(), expected, (a, b) => a == b);

            Assert.IsTrue(areSame);
        }

        #endregion

        #region String methods

        [TestCase(new string[] { "1", "2", "3", "4", "5" }, new string[] { "1", "2", "3", "4", "5" })]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, new string[] { "2", "1", "5", "3", "4" })]
        [TestCase(new string[] { "1", "2", "3", "4", "5", "5" }, new string[] { "1", "2", "5", "3", "4", "5" })]
        public void Inorder_TypeParameterIsString_ComparerIsDefault(string[] expected, string[] parameters)
        {
            var tree = new BinarySearchTree<string>(parameters[0]);
            for (int i = 1; i < parameters.Length; i++)
            {
                tree.AddElement(parameters[i]);
            }

            var areSame = AreSame(tree.Inorder(), expected, (a, b) => a == b);

            Assert.IsTrue(areSame);
        }

        [TestCase(new string[] { "5", "4", "3", "2", "1" }, new string[] { "1", "2", "3", "4", "5" })]
        [TestCase(new string[] { "5", "4", "3", "2", "1" }, new string[] { "2", "1", "5", "3", "4" })]
        [TestCase(new string[] { "5", "5", "4", "3", "2", "1" }, new string[] { "1", "2", "5", "3", "4", "5" })]
        public void Inorder_TypeParameterIsString_ComparerIsCustom(string[] expected, string[] parameters)
        {
            var comparer = new CustomStringComparer();
            var tree = new BinarySearchTree<string>(parameters[0], comparer);
            for (int i = 1; i < parameters.Length; i++)
            {
                tree.AddElement(parameters[i]);
            }

            var areSame = AreSame(tree.Inorder(), expected, (a, b) => a == b);

            Assert.IsTrue(areSame);
        }

        [TestCase(new string[] { "3", "2", "1", "4", "6", "5", "7" }, new string[] { "3", "4", "6", "7", "5", "2", "1" })]
        public void Preorder_TypeParameterIsString_ComparerIsDefault(string[] expected, string[] parameters)
        {
            var tree = new BinarySearchTree<string>(parameters[0]);
            for (int i = 1; i < parameters.Length; i++)
            {
                tree.AddElement(parameters[i]);
            }

            var areSame = AreSame(tree.Preorder(), expected, (a, b) => a == b);

            Assert.IsTrue(areSame);
        }

        [TestCase(new string[] { "1", "2", "5", "7", "6", "4", "3" }, new string[] { "3", "4", "6", "7", "5", "2", "1" })]
        public void Postorder_TypeParameterIsString_ComparerIsDefault(string[] expected, string[] parameters)
        {
            var tree = new BinarySearchTree<string>(parameters[0]);
            for (int i = 1; i < parameters.Length; i++)
            {
                tree.AddElement(parameters[i]);
            }

            var areSame = AreSame(tree.Postorder(), expected, (a, b) => a == b);

            Assert.IsTrue(areSame);
        }

        #endregion

        #region Book tests

        [Test]
        public void Inorder_TypeParameterIsBook_ComparerIsDefault()
        {
            var tree = new BinarySearchTree<Book>(new Book() { Pages = 1 });
            for (int i = 2; i < 5; i++)
            {
                tree.AddElement(new Book() { Pages = i });
            }

            var expected = new Book[4];
            for (int i = 0; i < 4; i++)
            {
                expected[i] = new Book() { Pages = i + 1 };
            }

            var areSame = AreSame(tree.Inorder(), expected, (a, b) => a.Pages == b.Pages);

            Assert.IsTrue(areSame);
        }

        [Test]
        public void Inorder_TypeParameterIsBook_ComparerIsCustom()
        {
            var tree = new BinarySearchTree<Book>(new Book() { Pages = 1 }, new CustomBookComparer());
            for (int i = 2; i < 5; i++)
            {
                tree.AddElement(new Book() { Pages = i });
            }

            var expected = new Book[4];
            for (int i = 3; i >-1 ; i--)
            {
                expected[i] = new Book() { Pages = i + 1 };
            }

            var areSame = AreSame(tree.Inorder(), expected, (a, b) => a.Pages == b.Pages);

            Assert.IsTrue(areSame);
        }

        #endregion

        #region Point tests

        [Test]
        public void Inorder_TypeParameterIsPoint_ComparerIsCustom()
        {
            var tree = new BinarySearchTree<Point>(new Point() { X = 0 }, new CustomPointComparer());
            for (int i = 1; i < 5; i++)
            {
                tree.AddElement(new Point() { X = i });
            }

            var expected = new Point[5];
            for (int i = 1; i < 5; i++)
            {
                expected[i] = new Point() { X = i };
            }

            var areSame = AreSame(tree.Inorder(), expected, (a, b) => a.X == b.X);

            Assert.IsTrue(areSame);
        }

        #endregion

        #region Help methods

        private bool AreSame<T>(IEnumerable<T> arg1, IEnumerable<T> arg2, Func<T, T, bool> compare)
        {
            var enumerator1 = arg1.GetEnumerator();
            var enumerator2 = arg2.GetEnumerator();

            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                if (!compare.Invoke(enumerator1.Current, enumerator2.Current))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Help classes

        internal class CustomIntComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y - x;
            }
        }

        internal class CustomStringComparer : IComparer<String>
        {
            public int Compare(string x, string y)
            {
                return Comparer<string>.Default.Compare(y, x);
            }
        }

        internal class Book : IComparable<Book>
        {
            public int CompareTo(Book book)
            {
                return this.Pages - book.Pages;
            }

            public int Pages { get; set; }
        }

        internal class CustomBookComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                return x.Pages - y.Pages;
            }
        }

        internal struct Point
        {
            public int X;
        }

        internal class CustomPointComparer : IComparer<Point>
        {
            public int Compare(Point x, Point y)
            {
                return x.X - y.X;
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;

namespace HW
{
    class Node<T>
        where T : IComparable
    {
        public T value;
        public int valueCount;
        public Node<T> left;
        public Node<T> right;

        public Node(T _value, Node<T> _left = null, Node<T> _right = null)
        {
            value = _value;
            valueCount = 1;
            left = _left;
            right = _right;
        }

        public void InsertValue(T newValue)
        {
            int res = newValue.CompareTo(value);
            if (res > 0)
            {
                if (right != null)
                    right.InsertValue(newValue);
                else
                    right = new Node<T>(newValue);
            }
            else if (res < 0)
            {
                if (left != null)
                    left.InsertValue(newValue);
                else
                    left = new Node<T>(newValue);
            }
            else
            {
                valueCount++;
            }
        }

        public override string ToString()
        {
            return $"{value}->{valueCount}";
        }
    }

    class SortedBinaryTree<T>
        where T : IComparable
    {
        public Node<T> root = null;
        public bool IsEmpty { get => root == null; }
        public void Insert(T value)
        {
            if (!IsEmpty)
                root.InsertValue(value);
            else
                root = new Node<T>(value);
        }

        public void Inorder(Node<T> root)
        {
            if (root == null)
                return;
            Inorder(root.left);
            Console.Write(root + " ");
            Inorder(root.right);
        }

        public void Preorder(Node<T> root)
        {
            if (root == null)
                return;
            Console.Write(root + " ");
            Preorder(root.left);
            Preorder(root.right);
        }

        public void Postorder(Node<T> root)
        {
            if (root == null)
                return;
            Postorder(root.left);
            Postorder(root.right);
            Console.Write(root + " ");
        }

        public void Cascade(Node<T> root)
        {
            Queue<Node<T>> nodesToPrint = new();
            nodesToPrint.Enqueue(root);
            while (nodesToPrint.Count > 0)
            {
                Node<T> node = nodesToPrint.Dequeue();

                if (node.left != null)
                    nodesToPrint.Enqueue(node.left);

                if (node.right != null)
                    nodesToPrint.Enqueue(node.right);

                Console.Write(node + " ");
            }
            Console.WriteLine();
        }

        public void Print()
        {
            if (!IsEmpty)
                Inorder(root);
            else
                Console.WriteLine("Tree is empty");
        }

        public void Clear()
        {
            root = null;
        }

        public Node<T> Find(T value)
        {
            return Find(root, value);
        }

        private Node<T> Find(Node<T> root, T value)
        {
            if (root == null)
                return null;
            int res = root.value.CompareTo(value);
            if (res == 0)
                return root;
            else if (res >= 1)
                return Find(root.left, value);
            else
                return Find(root.right, value);
        }

        public void Delete(T val)
        {
            root = Delete(root, val);
        }

        T GetRightMin(Node<T> root)
        {
            Node<T> temp = root;
            while (temp.left != null)
                temp = temp.left;

            return temp.value;
        }

        private Node<T> Delete(Node<T> root, T val)
        {
            if (root == null)
                return null;
            if (root.value.CompareTo(val) < 0)
                root.right = Delete(root.right, val);
            else if (root.value.CompareTo(val) > 0)
                root.left = Delete(root.left, val);
            else
            {
                if (root.left == null && root.right == null)
                {
                    return null;
                }
                else if (root.left == null)
                {
                    return root.right;
                }
                else if (root.right == null)
                {
                    return root.left;
                }
                else
                {
                    T rightMin = GetRightMin(root.right);
                    root.value = rightMin;
                    root.right = Delete(root.right, rightMin);
                }

            }
            return root;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SortedBinaryTree<int> binaryTree = new();
            binaryTree.Insert(100);
            binaryTree.Insert(50);
            binaryTree.Insert(200);
            binaryTree.Insert(150);
            binaryTree.Insert(300);
            binaryTree.Cascade(binaryTree.root);
            binaryTree.Delete(300);
            binaryTree.Cascade(binaryTree.root);
            binaryTree.Delete(100);
            binaryTree.Cascade(binaryTree.root);

            binaryTree.Insert(100);
            binaryTree.Insert(300);
            binaryTree.Insert(300);
            binaryTree.Cascade(binaryTree.root);

            binaryTree.Inorder(binaryTree.root);
            Console.WriteLine();
            binaryTree.Preorder(binaryTree.root);
            Console.WriteLine();
            binaryTree.Postorder(binaryTree.root);
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;

namespace BinarisKeresoFa
{
    public class BinaryExpressionTree
    {
        public enum Operator
        {
            Add = 43, // +
            Sub = 45, // -
            Mul = 42, // *
            Div = 47, // /
            Pow = 94 // ^
        }

        public abstract class Node
        {
            private char _data;
            private Node _left;
            private Node _right;

            public char Data => _data;
            public Node Left => _left;
            public Node Right => _right;

            protected Node(char data, Node left, Node right)
            {
                _data = data;
                _left = left;
                _right = right;
            }

            protected Node(char data) : this(data, null,null)
            {
                
            }
        }

        public class OperandNode : Node
        {
            public OperandNode(char data) : base(data)
            {
            }
        }

        public class OperatorNode : Node
        {
            private Operator _operator;

            public Operator Operator => _operator;

            public OperatorNode(char data, Node left, Node right) : base(data, left, right)
            {
                _operator = data switch
                {
                    '+' => Operator.Add,
                    '-' => Operator.Sub,
                    '*' => Operator.Mul,
                    '/' => Operator.Div,
                    '^' => Operator.Pow,
                    _ => _operator
                };
            }
        }

        private Node _root;

        public Node Root => _root;

        public BinaryExpressionTree(Node root)
        {
            _root = root;
        }

        public static BinaryExpressionTree Build(string expression) => Build(expression.ToCharArray());

        public static BinaryExpressionTree Build(char[] expression)
        {
            Stack<Node> data = new Stack<Node>();
            foreach (char item in expression)
            {
                int num = item - '0';
                if (0 <= num && num <= 9)
                {
                    data.Push(new OperandNode(item));
                }
                else
                {
                    data.Push(new OperatorNode(item, data.Pop(), data.Pop()));
                }
            }
            return new BinaryExpressionTree(data.Pop());
        }
    }
}
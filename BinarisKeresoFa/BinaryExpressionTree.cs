using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

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

        private BinaryExpressionTree(Node root)
        {
            _root = root;
        }

        public static BinaryExpressionTree Build(string expression) => Build(expression.ToCharArray());

        public static BinaryExpressionTree Build(char[] expression)
        {
            Stack<Node> data = new Stack<Node>();
            for (var index = 0; index < expression.Length; index++)
            {
                var t = expression[index];
                char item = t;
                int num = item - '0';
                if (0 <= num && num <= 9)
                {
                    data.Push(new OperandNode(item));
                }
                else if (num == (int) Operator.Add ||
                         num == (int) Operator.Div ||
                         num == (int) Operator.Mul ||
                         num == (int) Operator.Pow ||
                         num == (int) Operator.Sub)
                {
                    Node tmp = data.Pop();
                    data.Push(new OperatorNode(item, data.Pop(), tmp));
                }
                else
                {
                    throw new InvalidExpressionException(expression.ToString(), index);
                }
            }

            return new BinaryExpressionTree(data.Pop());
        }

        public override string ToString() => -_root.Data == null ? String.Empty : this.ToString(_root); //  _root.Left == null && _root.Right == null 

        public string ToString(Node node)
        {
            string tmp = String.Empty;
            if (node.Left != null)
                tmp += ToString(node.Left);
            if (node.Right != null)
                tmp += ToString(node.Right);
            return tmp + node.Data;
        }

        public string Convert() => _root == null ? string.Empty : this.Convert(_root);

        public string Convert(Node node)
        {
            string tmp = String.Empty;
            if (node.Left != null)
                tmp += Convert(node.Left);
            tmp += node.Data;
            if (node.Right != null)
                tmp += Convert(node.Right);
            return node is OperatorNode ? $"({tmp})" : tmp;
        }

        public double Evaluate() => _root == null ? 0 : this.Evaluate(_root);

        public double Evaluate(Node node)
        {
            if (node == null)
                return 0;
            if (node is OperatorNode)
                return node.Data;
            double left = Evaluate(node.Left);
            double right = Evaluate(node.Right);
            return node.Data switch
            {
                '+' => left + right,
                '-' => left - right,
                '*' => left * right,
                '/' => left / right,
                '^' => Math.Pow(left, right),
                _ => throw new InvalidExpressionException("Nem elfogadott operátor.", node.Data) // TODO ide kéne még valami szerintem, de nem értem a feladatot....
            };
        }
    }
}
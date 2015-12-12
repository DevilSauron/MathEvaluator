using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEvaluator.Parsing.AST
{
    public class NumberNode : IAstNode<int>
    {
        private int value;

        public NumberNode(int value)
        {
            this.value = value;
        }

        public int Evaluate()
        {
            return value;
        }
    }

    public class AddNode : IAstNode<int>
    {
        private IAstNode<int> left;
        private IAstNode<int> right;

        public AddNode(IAstNode<int> left, IAstNode<int> right)
        {
            this.left = left;
            this.right = right;
        }

        public int Evaluate()
        {
            return left.Evaluate() + right.Evaluate();
        }
    }

    public class SubNode : IAstNode<int>
    {
        private IAstNode<int> left;
        private IAstNode<int> right;

        public SubNode(IAstNode<int> left, IAstNode<int> right)
        {
            this.left = left;
            this.right = right;
        }

        public int Evaluate()
        {
            return left.Evaluate() - right.Evaluate();
        }
    }

    public class MulNode : IAstNode<int>
    {
        private IAstNode<int> left;
        private IAstNode<int> right;

        public MulNode(IAstNode<int> left, IAstNode<int> right)
        {
            this.left = left;
            this.right = right;
        }

        public int Evaluate()
        {
            return left.Evaluate() * right.Evaluate();
        }
    }

    public class DivNode : IAstNode<int>
    {
        private IAstNode<int> left;
        private IAstNode<int> right;

        public DivNode(IAstNode<int> left, IAstNode<int> right)
        {
            this.left = left;
            this.right = right;
        }

        public int Evaluate()
        {
            return left.Evaluate() / right.Evaluate();
        }
    }

    public class NegNode : IAstNode<int>
    {
        private IAstNode<int> node;

        public NegNode(IAstNode<int> node)
        {
            this.node = node;
        }

        public int Evaluate()
        {
            return -1 * node.Evaluate();
        }
    }
}

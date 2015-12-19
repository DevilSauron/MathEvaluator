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
        private Guid id = Guid.NewGuid();

        public NumberNode(int value)
        {
            this.value = value;
        }

        public int Evaluate()
        {
            return value;
        }

        public string SubTreeDot()
        {
            return String.Format("node_{0} [label=\"{1}\"]\n", id.ToString().Replace('-', '_'), value);
        }

        public string GetGuid()
        {
            return id.ToString().Replace('-', '_');
        }
    }

    public class AddNode : IAstNode<int>
    {
        private IAstNode<int> left;
        private IAstNode<int> right;
        private Guid id = Guid.NewGuid();

        public AddNode(IAstNode<int> left, IAstNode<int> right)
        {
            this.left = left;
            this.right = right;
        }

        public int Evaluate()
        {
            return left.Evaluate() + right.Evaluate();
        }

        public string SubTreeDot()
        {
            string ret = String.Format("node_{0} [label=\"+\"]\n", GetGuid());
            ret += left.SubTreeDot();
            ret += right.SubTreeDot();
            ret += "\n" + String.Format("node_{0} -> node_{1}\nnode_{0} -> node_{2}\n", GetGuid(), left.GetGuid(), right.GetGuid());
            return ret;
        }

        public string GetGuid()
        {
            return id.ToString().Replace('-', '_');
        }
    }

    public class SubNode : IAstNode<int>
    {
        private IAstNode<int> left;
        private IAstNode<int> right;
        private Guid id = Guid.NewGuid();

        public SubNode(IAstNode<int> left, IAstNode<int> right)
        {
            this.left = left;
            this.right = right;
        }

        public int Evaluate()
        {
            return left.Evaluate() - right.Evaluate();
        }

        public string SubTreeDot()
        {
            string ret = String.Format("node_{0} [label=\"-\"]\n", GetGuid());
            ret += left.SubTreeDot();
            ret += right.SubTreeDot();
            ret += "\n" + String.Format("node_{0} -> node_{1}\nnode_{0} -> node_{2}\n", GetGuid(), left.GetGuid(), right.GetGuid());
            return ret;
        }

        public string GetGuid()
        {
            return id.ToString().Replace('-', '_');
        }
    }

    public class MulNode : IAstNode<int>
    {
        private IAstNode<int> left;
        private IAstNode<int> right;
        private Guid id = Guid.NewGuid();

        public MulNode(IAstNode<int> left, IAstNode<int> right)
        {
            this.left = left;
            this.right = right;
        }

        public int Evaluate()
        {
            return left.Evaluate() * right.Evaluate();
        }

        public string SubTreeDot()
        {
            string ret = String.Format("node_{0} [label=\"*\"]\n", GetGuid());
            ret += left.SubTreeDot();
            ret += right.SubTreeDot();
            ret += "\n" + String.Format("node_{0} -> node_{1}\nnode_{0} -> node_{2}\n", GetGuid(), left.GetGuid(), right.GetGuid());
            return ret;
        }

        public string GetGuid()
        {
            return id.ToString().Replace('-', '_');
        }
    }

    public class DivNode : IAstNode<int>
    {
        private IAstNode<int> left;
        private IAstNode<int> right;
        private Guid id = Guid.NewGuid();

        public DivNode(IAstNode<int> left, IAstNode<int> right)
        {
            this.left = left;
            this.right = right;
        }

        public int Evaluate()
        {
            return left.Evaluate() / right.Evaluate();
        }

        public string SubTreeDot()
        {
            string ret = String.Format("node_{0} [label=\"/\"]\n", GetGuid());
            ret += left.SubTreeDot();
            ret += right.SubTreeDot();
            ret += "\n" + String.Format("node_{0} -> node_{1}\nnode_{0} -> node_{2}\n", GetGuid(), left.GetGuid(), right.GetGuid());
            return ret;
        }

        public string GetGuid()
        {
            return id.ToString().Replace('-', '_');
        }
    }

    public class NegNode : IAstNode<int>
    {
        private IAstNode<int> node;
        private Guid id = Guid.NewGuid();

        public NegNode(IAstNode<int> node)
        {
            this.node = node;
        }

        public int Evaluate()
        {
            return -1 * node.Evaluate();
        }

        public string SubTreeDot()
        {
            string ret = String.Format("node_{0} [label=\"-\"]\n", GetGuid());
            ret += node.SubTreeDot();
            ret += "\n" + String.Format("node_{0} -> node_{1}\n", GetGuid(), node.GetGuid());
            return ret;
        }

        public string GetGuid()
        {
            return id.ToString().Replace('-', '_');
        }
    }
}

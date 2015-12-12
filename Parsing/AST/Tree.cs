using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEvaluator.Parsing.AST
{
    public class Tree<T>
    {
        private IAstNode<T> top;

        public Tree(IAstNode<T> top)
        {
            this.top = top;
        }

        public T Walk()
        {
            return top.Evaluate();
        }
    }
}

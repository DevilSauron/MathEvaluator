using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEvaluator.Parsing.AST
{
    public interface IAstNode<T>
    {
        T Evaluate();
        string SubTreeDot();
        string GetGuid();
    }
}

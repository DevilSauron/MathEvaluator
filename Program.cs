using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathEvaluator.Parsing;
using MathEvaluator.Parsing.AST;

namespace MathEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string test = "-(1 + 2 * 3) + (-2 * (3 + 3))";
                Lexer lexer = new Lexer(test);
                TokenStream stream = lexer.Tokenize();
                Parser parser = new Parser(stream);
                Tree<int> tree = parser.Parse();

                Console.WriteLine(String.Format("Input: {0}\nResult: {1}\n\nDOT notation:\n\n{2}", test, tree.Walk(), tree.GetDot()));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            Console.ReadKey(true);
        }
    }
}

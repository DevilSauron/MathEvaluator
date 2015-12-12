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
                string test = "2 * 5 * (-(10 + 10 - 10 * 5)) / (8 - 4 - 5 * 7)";
                Lexer lexer = new Lexer(test);
                TokenStream stream = lexer.Tokenize();
                Parser parser = new Parser(stream);
                Tree<int> tree = parser.Parse();

                Console.WriteLine(String.Format("Input: {0}\nResult: {1}", test, tree.Walk()));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            Console.ReadKey(true);
        }
    }
}

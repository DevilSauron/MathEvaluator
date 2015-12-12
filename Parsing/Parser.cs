using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathEvaluator.Parsing.AST;

namespace MathEvaluator.Parsing
{
    /*
    parse = exp EOF
    exp = addExp
    addExp = mulExp (('+' | '-') mulExp)*
    mulExp = unaryExp (('*' | '/') unaryExp)*
    unaryExp = '-' atom | atom
    atom = Number | '(' exp ')'
    Number = 0..9 //IN LEXER
    */
    public class Parser
    {
        private TokenStream stream;

        public Parser(TokenStream input)
        {
            stream = input;
        }

        public Tree<int> Parse()
        {
            var tree = new Tree<int>(parseExp());
            stream.Expect(TokenType.EOF); //It must end with <EOF>
            return tree;
        }

        private IAstNode<int> parseExp()
        {
            return parseAddExp();
        }

        private IAstNode<int> parseAddExp()
        {
            IAstNode<int> left = parseMulExp(); //Parse the LHS, it's always there

            while (stream.Match(TokenType.Add) || stream.Match(TokenType.Sub))
            {
                //RHS is present
                var tok = stream.Read(); //Eat '+' or '-'
                var right = parseMulExp(); //Parse the RHS

                if (tok.Matches(TokenType.Add))
                    left = new AddNode(left, right);
                else if (tok.Matches(TokenType.Sub))
                    left = new SubNode(left, right);
            }

            return left;
        }

        private IAstNode<int> parseMulExp()
        {
            IAstNode<int> left = parseUnaryExp(); //Parse the LHS, it's always there

            while (stream.Match(TokenType.Mul) || stream.Match(TokenType.Div))
            {
                //RHS is present
                var tok = stream.Read(); //Eat '*' or '/'
                var right = parseUnaryExp(); //Parse the RHS

                if (tok.Matches(TokenType.Mul))
                    left = new MulNode(left, right);
                else if (tok.Matches(TokenType.Div))
                    left = new DivNode(left, right);
            }

            return left;
        }

        private IAstNode<int> parseUnaryExp()
        {
            if (stream.Match(TokenType.Sub))
            {
                //Unary with minus
                stream.Expect(TokenType.Sub); //Eat '-'
                return new NegNode(parseAtom());
            }
            else
            {
                //Unary without minus
                return parseAtom();
            }
        }

        private IAstNode<int> parseAtom()
        {
            if (stream.Match(TokenType.Number))
            {
                //This atom is a number
                int number = Int32.Parse(stream.Expect(TokenType.Number).Value); //Eat the number and save it
                return new NumberNode(number);
            }
            else
            {
                //This atom is a nested expression
                stream.Expect(TokenType.LPar); //Eat '('
                var inner = parseExp(); //Parse the inner expression
                stream.Expect(TokenType.RPar); //Eat ')' 
                return inner;
            }
        }
    }
}

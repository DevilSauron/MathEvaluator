using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEvaluator.Parsing
{
    public class Lexer
    {
        private string input;
        private int position = 0;

        public Lexer(string input)
        {
            this.input = input;
        }

        public TokenStream Tokenize()
        {
            List<Token> tokens = new List<Token>();

            while (position < input.Length)
            {
                if (Char.IsWhiteSpace(input[position]))
                {
                    position++;
                    continue;
                }

                switch (input[position])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        tokens.Add(parseNumber());
                        continue;
                    case '+':
                        tokens.Add(new Token(TokenType.Add, "+"));
                        break;
                    case '-':
                        tokens.Add(new Token(TokenType.Sub, "-"));
                        break;
                    case '*':
                        tokens.Add(new Token(TokenType.Mul, "*"));
                        break;
                    case '/':
                        tokens.Add(new Token(TokenType.Div, "/"));
                        break;
                    case '(':
                        tokens.Add(new Token(TokenType.LPar, "("));
                        break;
                    case ')':
                        tokens.Add(new Token(TokenType.RPar, ")"));
                        break;
                    default:
                        throw new ParseError(String.Format("Lexing Error: Unknown character '{0}'", input[position]));
                }

                position++;
            }
            tokens.Add(new Token(TokenType.EOF, "<EOF>"));
            return new TokenStream(tokens);
        }

        private Token parseNumber()
        {
            string ret = "";

            while (position < input.Length)
            {
                if (Char.IsDigit(input[position]))
                    ret += input[position];
                else
                    return new Token(TokenType.Number, ret);

                position++;
            }

            return new Token(TokenType.Number, ret);
        }
    }
}

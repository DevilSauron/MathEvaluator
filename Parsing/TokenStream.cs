using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEvaluator.Parsing
{
    public class TokenStream
    {
        private int position = 0;
        private List<Token> tokens;

        public TokenStream(List<Token> tokens)
        {
            this.tokens = tokens;
        }

        public Token Peek() => tokens[position];
        public Token Read() => tokens[position++];
        public bool Match(TokenType type) => Peek().Matches(type);

        public bool Accept(TokenType type)
        {
            if(Match(type))
            {
                Read();
                return true;
            }
            return false;
        }

        public Token Expect(TokenType type)
        {
            if (Match(type))
                return Read();
            throw new ParseError(String.Format("Parse error: Expected '{0}', given '{1}'", type, Peek().Type));
        }

        public override string ToString()
        {
            string ret = "";

            for(int i = 0; i < tokens.Count; i++)
            {
                ret += tokens[i];

                if (i == position)
                    ret += "\t<\n";
                else
                    ret += "\n";
            }

            return ret;
        }
    }
}

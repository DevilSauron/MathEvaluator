using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathEvaluator.Parsing
{
    public class Token
    {
        public TokenType Type { get; private set; }
        public string Value { get; private set; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            return string.Format("({0}, '{1}')", Type, Value);
        }

        public bool Matches(Token that)
        {
            return this.Type == that.Type;
        }

        public bool Matches(TokenType type)
        {
            return this.Type == type;
        }
    }

    public enum TokenType
    {
        Number, // 123
        Add, // +
        Sub, // -
        Mul, // *
        Div, // /
        LPar, // (
        RPar, // )
        EOF //<EOF>
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.FileReader
{
    public class TokenizedLine
    {
        public TokenizedLine (List<String> tokens, LineType type)
        {
            Tokens = tokens;
            Type = type;
        }
        public List<String> Tokens { get; private set; }
        public LineType Type { get; private set; }
    }
}

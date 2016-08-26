using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Trains.Util;
using System.Linq;

namespace Trains.FileReader
{
    public class RegexEngine
    {

        public TokenizedLine ExtractTokens(string line)
        {
            line = Regex.Replace(line, @"\s+", "");
            foreach (var pattern in RegexPatterns.Patterns)
            {
                Match match = Regex.Match(line, pattern.Value);
                if (match.Groups.Count > 1)
                {
                    var tokens = new List<string>();
                    for (int i = 1; i < match.Groups.Count; i++)
                        foreach (Capture capture in match.Groups[i].Captures)
                        {
                            tokens.Add(capture.Value);
                        }
                    return new TokenizedLine(tokens, pattern.Key);
                }
            }
            return new TokenizedLine(new List<string>(), LineType.InvalidLine);
        }

    }
}

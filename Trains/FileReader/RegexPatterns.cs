using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Util;

namespace Trains.FileReader
{

    public static class RegexPatterns
    {
        const string DistanceOfRoutePattern = "(?:Thedistanceoftheroute)(?:([A-Z])-)+(?:([A-z]).$)";
        public static ImmutableDictionary<LineType, string> Patterns = ImmutableDictionary.CreateBuilder<LineType, string>()
            .AddFluent(LineType.DistanceOfRoutePattern, DistanceOfRoutePattern)
            .ToImmutable();

    }

    public enum LineType
    {
        DistanceOfRoutePattern,
        InvalidLine
    }
}

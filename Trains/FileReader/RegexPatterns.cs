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
        const string DistanceOfRoutePattern = "(?:^Thedistanceoftheroute)(?:([A-Z])-)+(?:([A-z]).$)";
        const string MaxNumberOfStops = "(?:^Thenumberoftripsstartingat)([A-Z])(?:andendingat)([A-Z])(?:withamaximumof([0-9]+)stops.$)";
        const string ExactNumberOfStops = "(?:^Thenumberoftripsstartingat)([A-Z])(?:andendingat)([A-Z])(?:withexactly([0-9]+)stops.$)";
        public static ImmutableDictionary<LineType, string> Patterns = ImmutableDictionary.CreateBuilder<LineType, string>()
            .AddFluent(LineType.DistanceOfRoutePattern, DistanceOfRoutePattern)
            .AddFluent(LineType.MaxNumberOfStops, MaxNumberOfStops)
            .AddFluent(LineType.ExactNumberOfStops, ExactNumberOfStops)
            .ToImmutable();

    }

    public enum LineType
    {
        DistanceOfRoutePattern,
        MaxNumberOfStops,
        ExactNumberOfStops,
        InvalidLine
    }
}

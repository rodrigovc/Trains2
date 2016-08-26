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
        const string DistanceOfRoutePattern = @"(?:^Thedistanceoftheroute)(?:([A-Z])-)+(?:([A-z]).$)";
        const string MaxNumberOfStops = @"(?:^Thenumberoftripsstartingat)([A-Z])(?:andendingat)([A-Z])(?:withamaximumof([0-9]+)stops.$)";
        const string ExactNumberOfStops = @"(?:^Thenumberoftripsstartingat)([A-Z])(?:andendingat)([A-Z])(?:withexactly([0-9]+)stops.$)";
        const string ShortestPath = @"(?:^Thelengthoftheshortestroute\(intermsofdistancetotravel\)from)([A-Z])(?:to)([A-Z])(?:.$)";
        const string RoutesSmallerThan = @"(?:^Thenumberofdifferentroutesfrom)([A-Z])(?:to)([A-Z])(?:withadistanceoflessthan)([0-9]+)(?:.$)";
        const string Graph = @"(?:^Graph:)(?:(?:(?:([A-Z]{2}[0-9]+)(?:,))*([A-Z]{2}[0-9]+)(?:$))|(?:$))";
        public static ImmutableDictionary<LineType, string> Patterns = ImmutableDictionary.CreateBuilder<LineType, string>()
            .AddFluent(LineType.DistanceOfRoute, DistanceOfRoutePattern)
            .AddFluent(LineType.MaxNumberOfStops, MaxNumberOfStops)
            .AddFluent(LineType.ExactNumberOfStops, ExactNumberOfStops)
            .AddFluent(LineType.ShortestPath, ShortestPath)
            .AddFluent(LineType.RoutesSmallerThan, RoutesSmallerThan)
            .AddFluent(LineType.Graph, Graph)
            .ToImmutable();

    }

    public enum LineType
    {
        DistanceOfRoute,
        MaxNumberOfStops,
        ExactNumberOfStops,
        ShortestPath,
        RoutesSmallerThan,
        Graph,
        InvalidLine
    }
}

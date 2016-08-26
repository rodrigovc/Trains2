using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains;
using Trains.GraphObjects;
using Trains.FileReader;
using Trains.Util;
using System.Collections.Generic;

namespace TrainsTest
{
    [TestClass]
    public class RegexPatternsTest
    {
        
        private void assertPattern(string line,  TokenizedLine tokens)
        {
            RegexEngine engine = new RegexEngine();
            var tokenizedLine = engine.ExtractTokens(line);
            Assert.AreEqual(tokenizedLine.Type, tokens.Type);
            Assert.AreEqual(tokenizedLine.Tokens.Count, tokens.Tokens.Count);
            for(int i = 0; i < tokenizedLine.Tokens.Count; i++)
            {
                Assert.AreEqual(tokens.Tokens[i], tokenizedLine.Tokens[i]);
            }
        }

        [TestMethod]
        public void DistanceOfRoutePatternTest()
        {
            Func<List<string>,TokenizedLine> expectedResult = a => new TokenizedLine(a, LineType.DistanceOfRoute);
            (new Tuple<string, TokenizedLine>[] {
            Tuple.Create("The distance of the route A-B- C.", expectedResult(new List<string>() { "A","B","C" })),
            Tuple.Create("The distance of the route A - D - C.", expectedResult(new List<string>() { "A","D","C" })),
            Tuple.Create("The distance of the route A - D.", expectedResult(new List<string>() { "A","D" })),
            Tuple.Create("The distance of the route A - E - B - C - D.", expectedResult(new List<string>() { "A","E","B","C","D" })),
            Tuple.Create("The distance of the route A - E - D.", expectedResult(new List<string>() { "A","E","D" }))})
            .ForEach(l => assertPattern(l.Item1, l.Item2));
        }

        [TestMethod]
        public void DistanceOfRoutePatternTestFailure()
        {
            var expectedResult = new TokenizedLine(new List<string>(), LineType.InvalidLine);
            (new Tuple<string, TokenizedLine>[] {
            Tuple.Create("The distance of the route A-B- C", expectedResult),
            Tuple.Create("The distance of the route A.", expectedResult),
            Tuple.Create("The distance of the route.", expectedResult),
            Tuple.Create("The distance of the route ADFDFD - D - C.", expectedResult),
            Tuple.Create("The distance of the sdfa route A - D.", expectedResult),
            Tuple.Create("The distance of the route A - 3 - 8 - C - D.", expectedResult) })
            .ForEach(l => assertPattern(l.Item1, l.Item2));
        }

        [TestMethod]
        public void MaxNumberOfStopsPatternTest()
        {
            Func<List<string>, TokenizedLine> expectedResult = a => new TokenizedLine(a, LineType.MaxNumberOfStops);
            (new Tuple<string, TokenizedLine>[] {
            Tuple.Create("The number of trips starting at C and ending at C with a maximum of 3 stops.", 
            expectedResult(new List<string>() { "C","C","3" })),
            Tuple.Create("The number of trips starting at C and ending at B with a maximum of 55 stops.", 
            expectedResult(new List<string>() { "C","B","55" })),
            Tuple.Create("The number of trips starting at A and ending at B with a maximum of 150 stops.", 
            expectedResult(new List<string>() { "A","B","150" }))})
            .ForEach(l => assertPattern(l.Item1, l.Item2));
        }

        [TestMethod]
        public void MaxNumberOfStopsPatternTestFailure()
        {
            var expectedResult = new TokenizedLine(new List<string>(), LineType.InvalidLine);
            (new Tuple<string, TokenizedLine>[] {
            Tuple.Create("The number of trips starting at C and ending at CA with a maximum of 3 stops.", expectedResult),
            Tuple.Create("The number of trips stating at C and ending at B with a maximum of 55 stops.", expectedResult)})
            .ForEach(l => assertPattern(l.Item1, l.Item2));
        }

        [TestMethod]
        public void ExactNumberOfStopsPatternTest()
        {
            Func<List<string>, TokenizedLine> expectedResult = a => new TokenizedLine(a, LineType.ExactNumberOfStops);
            (new Tuple<string, TokenizedLine>[] {
            Tuple.Create("The number of trips starting at A and ending at C with exactly 7 stops.",
            expectedResult(new List<string>() { "A","C","7" })),
            Tuple.Create("The number of trips starting at D and ending at E with exactly 45 stops.",
            expectedResult(new List<string>() { "D","E","45" })),
            Tuple.Create("The number of trips starting at B and ending at B with exactly 88 stops.",
            expectedResult(new List<string>() { "B","B","88" }))})
            .ForEach(l => assertPattern(l.Item1, l.Item2));
        }

        [TestMethod]
        public void ExactNumberOfStopsPatternTestFailure()
        {
            var expectedResult = new TokenizedLine(new List<string>(), LineType.InvalidLine);
            (new Tuple<string, TokenizedLine>[] {
            Tuple.Create("The number of trips starting at AB and ending at C with exactly 7 stops.", expectedResult),
            Tuple.Create("The number of trips starting at D and ending at E with exatly 45 stops.", expectedResult)})
            .ForEach(l => assertPattern(l.Item1, l.Item2));
        }

        [TestMethod]
        public void ShortestPathPatternTest()
        {
            Func<List<string>, TokenizedLine> expectedResult = a => new TokenizedLine(a, LineType.ShortestPath);
            (new Tuple<string, TokenizedLine>[] {
            Tuple.Create("The length of the shortest route (in terms of distance to travel) from A to C.",
            expectedResult(new List<string>() { "A","C" })),
            Tuple.Create("The length of the shortest route (in terms of distance to travel) from B to B.",
            expectedResult(new List<string>() { "B","B" })),
            Tuple.Create("The length of the shortest route (in terms of distance to travel) from E to A.",
            expectedResult(new List<string>() { "E","A" }))})
            .ForEach(l => assertPattern(l.Item1, l.Item2));
        }

        [TestMethod]
        public void ShortestPathPatternTestFailure()
        {
            var expectedResult = new TokenizedLine(new List<string>(), LineType.InvalidLine);
            (new Tuple<string, TokenizedLine>[] {
            Tuple.Create("The length of the shortest route (in terms of distance to travel) from AS to CX.", expectedResult),
            Tuple.Create("The length of the shortest roue (in terms of distance to travel) from A to C.", expectedResult)})
            .ForEach(l => assertPattern(l.Item1, l.Item2));
        }

        [TestMethod]
        public void RoutesSmallerThanPatternTest()
        {
            Func<List<string>, TokenizedLine> expectedResult = a => new TokenizedLine(a, LineType.RoutesSmallerThan);
            (new Tuple<string, TokenizedLine>[] {
            Tuple.Create("The number of different routes from C to C with a distance of less than 30.",
            expectedResult(new List<string>() { "C","C","30" })),
            Tuple.Create("The number of different routes from A to E with a distance of less than 555555555.",
            expectedResult(new List<string>() { "A","E", "555555555" })),
            Tuple.Create("The number of different routes from D to B with a distance of less than 456.",
            expectedResult(new List<string>() { "D","B","456" }))})
            .ForEach(l => assertPattern(l.Item1, l.Item2));
        }

        [TestMethod]
        public void RoutesSmallerThanPatternTestFailure()
        {
            var expectedResult = new TokenizedLine(new List<string>(), LineType.InvalidLine);
            (new Tuple<string, TokenizedLine>[] {
            Tuple.Create("The number of different routes from C to C with a distance of less than 30A.", expectedResult),
            Tuple.Create("The number of different routes from CV to C with a distance of less than 30.", expectedResult)})
            .ForEach(l => assertPattern(l.Item1, l.Item2));
        }

        [TestMethod]
        public void GraphPatternTest()
        {
            Func<List<string>, TokenizedLine> expectedResult = a => new TokenizedLine(a, LineType.Graph);
            (new Tuple<string, TokenizedLine>[] {
            Tuple.Create("Graph: AB5, BC4, CD8, DC88, DE6, AD5, CE2, EB3, AE7",
            expectedResult(new List<string>() { "AB5", "BC4", "CD8", "DC88", "DE6", "AD5", "CE2", "EB3", "AE7" })),
            Tuple.Create("Graph: AB57", expectedResult(new List<string>() { "AB57"})),
            Tuple.Create("Graph: ", expectedResult(new List<string>())),
            Tuple.Create("Graph: AD5, CE2, EB3, AE766",
            expectedResult(new List<string>() { "AD5", "CE2", "EB3", "AE766" }))})
            .ForEach(l => assertPattern(l.Item1, l.Item2));
        }

        [TestMethod]
        public void GraphPatternTestFailure()
        {
            var expectedResult = new TokenizedLine(new List<string>(), LineType.InvalidLine);
            (new Tuple<string, TokenizedLine>[] {
            Tuple.Create("Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2 EB3, AE7", expectedResult),
            Tuple.Create("Graph: AB5,", expectedResult),
            Tuple.Create("Grah: ", expectedResult),
            Tuple.Create("Graph: AD5, CE2, EAB3, AE7", expectedResult)})
            .ForEach(l => assertPattern(l.Item1, l.Item2));
        }



    }
}

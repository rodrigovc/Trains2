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
            Func<List<string>,TokenizedLine> expectedResult = a => new TokenizedLine(a, LineType.DistanceOfRoutePattern);
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
            Tuple.Create("The distance of the route ADFDFD - D - C.", expectedResult),
            Tuple.Create("The distance of the sdfa route A - D.", expectedResult),
            Tuple.Create("The distance of the route A - 3 - 8 - C - D.", expectedResult) })
            .ForEach(l => assertPattern(l.Item1, l.Item2));
        }

        [TestMethod]
        public void MaxNumberOfStopsTest()
        {
            Func<List<string>, TokenizedLine> expectedResult = a => new TokenizedLine(a, LineType.MaxNumberOfStops);
            (new Tuple<string, TokenizedLine>[] {
            Tuple.Create("The number of trips starting at C and ending at C with a maximum of 3 stops.", 
            expectedResult(new List<string>() { "C","C","3" })),
            Tuple.Create("The number of trips starting at C and ending at B with a maximum of 55 stops.", 
            expectedResult(new List<string>() { "C","B","55" })),
            Tuple.Create("The number of trips starting at A and ending at B with a maximum of 150 stops.", 
            expectedResult(new List<string>() { "A","B","150" }))}).ForEach(l => assertPattern(l.Item1, l.Item2));
        }

        [TestMethod]
        public void ExactNumberOfStopsTest()
        {
            Func<List<string>, TokenizedLine> expectedResult = a => new TokenizedLine(a, LineType.ExactNumberOfStops);
            (new Tuple<string, TokenizedLine>[] {
            Tuple.Create("The number of trips starting at A and ending at C with exactly 7 stops.",
            expectedResult(new List<string>() { "A","C","7" })),
            Tuple.Create("The number of trips starting at D and ending at E with exactly 45 stops.",
            expectedResult(new List<string>() { "D","E","45" })),
            Tuple.Create("The number of trips starting at B and ending at B with exactly 88 stops.",
            expectedResult(new List<string>() { "B","B","88" }))}).ForEach(l => assertPattern(l.Item1, l.Item2));
        }


        /*[TestMethod]
        public void EqualityTestSuccess()
       {
            var id = Guid.NewGuid();
            var node1 = new Node() { Id = id };
            var node2 = new Node() { Id = id };
            var node3 = node1;
            var nodecmp = new NodeComparer();
            Assert.IsTrue(nodecmp.Equals(node1, node2));
            Assert.IsTrue(nodecmp.Equals(node2, node3));
            Assert.IsTrue(nodecmp.Equals(node2, node3));
        }*/


    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains;
using Trains.GraphObjects;
using Trains.FileReader;
using Trains.Util;

namespace TrainsTest
{
    [TestClass]
    public class RegexPatternsTest
    {
        
        private void assertPatternSuccess(string line, params string[] values)
        {
            RegexEngine engine = new RegexEngine();
            var tokenizedLine = engine.ExtractTokens("The distance of the route A-B- C.");
            Assert.AreEqual(tokenizedLine.Count, values.Length);
            for(int i = 0; i < tokenizedLine.Count; i++)
            {
                Assert.AreEqual(values[i], tokenizedLine[i]);
            }
        }

        [TestMethod]
        public void DistanceOfRoutePatternTest()
        {
            (new Tuple<string, string[]>[] {
            Tuple.Create("The distance of the route A-B- C.", new string [] { "A","B","C" }),
            Tuple.Create("The distance of the route A - D - C.", new string [] { "A", "D", "C"}),
            Tuple.Create("The distance of the route A - D.", new string [] { "A","D"}),
            Tuple.Create("The distance of the route A - E - B - C - D.", new string [] { "A","E","B", "C", "D" }),
            Tuple.Create("The distance of the route A - E - D.", new string [] { "A","E","D" }) })
            .ForEach(l => assertPatternSuccess(l.Item1, l.Item2));
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

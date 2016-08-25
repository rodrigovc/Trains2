using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trains;
using Trains.GraphObjects;

namespace TrainsTest
{
    [TestClass]
    public class NodeComparerTest
    {


        [TestMethod]
        public void EqualityTestFailure()
        {
            var node1 = new Node() { Id = Guid.NewGuid() };
            var node2 = new Node() { Id = Guid.NewGuid() };
            var nodecmp = new NodeComparer();
            Assert.IsFalse(nodecmp.Equals(node1, node2));
        }

        [TestMethod]
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
        }

       
    }
}

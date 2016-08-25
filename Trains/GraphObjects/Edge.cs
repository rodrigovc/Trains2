using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.GraphObjects;

namespace Trains.GraphObjects
{
    public class Edge : IEqualityComparer<Edge>
    {
        public Node Destination { get; set; }
        public int Distance { get; set; }

        public bool Equals(Edge x, Edge y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(Edge obj)
        {
            throw new NotImplementedException();
        }
    }
}

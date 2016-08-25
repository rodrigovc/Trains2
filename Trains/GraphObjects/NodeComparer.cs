using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.GraphObjects
{
    public class NodeComparer : IEqualityComparer<Node>
    {
        public bool Equals(Node x, Node y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(Node obj)
        {
            throw new NotImplementedException();
        }
    }
}

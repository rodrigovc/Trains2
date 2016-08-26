using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Graph;
using Trains.Graph.Interfaces;

namespace Trains.GraphObjects
{
    public class Edge<TNode, TEdge> : IEdge<TNode, TEdge>
        where TNode : INode<TNode, TEdge>
        where TEdge : IEdge<TNode, TEdge>
    {
        TNode destination;
        TEdge distance;
        public Edge(TNode destination, TEdge distance)
        {
            this.destination = destination;
            this.distance = distance;
        }


        public TNode Destination {
            get
            {
                return destination;
            }
        }

        public TEdge Distance
        {
            get
            {
                return distance;
            }
        }
    }
}

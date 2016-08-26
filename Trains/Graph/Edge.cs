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
        public Edge(TNode destination, TEdge distance)
        {
            Destination = destination;
            Distance = distance;
        }

        public TNode Destination { get; private set; }
        public TEdge Distance { get; private set; }

    }
}

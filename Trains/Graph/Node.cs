using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains;
using Trains.Graph;
using Trains.Graph.Interfaces;

namespace Trains.GraphObjects
{
    public class GraphNode<TNode, TEdge> : INode<TNode, TEdge>
        where TNode : INode<TNode, TEdge>
        where TEdge : IEdge<TNode, TEdge>
    {

        public GraphNode(TNode node) : this (node, new Dictionary<TNode, TEdge>()) { }

        public GraphNode(TNode node, IDictionary<TNode, TEdge> neighbours)
        {
            Node = node;
            Neighbours = neighbours;
        }

        public TNode Node { get; private set; }

        public IDictionary<TNode, TEdge> Neighbours { get; private set; }

        public GraphNode<TNode, TEdge> AddNeighbour(TNode destination, TEdge distance)
        {
            Neighbours.Add(destination, distance);
            return this;
        }
    }
}

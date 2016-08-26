using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Graph;
using Trains.Graph.Interfaces;

namespace Trains.Graph
{
    public class Graph<TNode, TEdge> : IGraph<TNode, TEdge>
        where TNode : INode<TNode, TEdge>
        where TEdge : IEdge<TNode, TEdge>
    {
        public Graph() : this (new List<TNode>()) { }

        public Graph(IList<TNode> nodes)
        {
           Nodes = nodes;
        }

        public IList<TNode> Nodes { get; private set; }

        public Graph<TNode,TEdge> Add(TNode node)
        {
            Nodes.Add(node);
            return this;
        }
    }
}

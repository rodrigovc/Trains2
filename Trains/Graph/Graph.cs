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
        IList<TNode> nodes;
        public Graph() : this (new List<TNode>()) { }

        public Graph(IList<TNode> nodes)
        {
            this.nodes = nodes;
        }

        public IList<TNode> Nodes
        {
            get
            {
                return nodes;
            }
        }

        public Graph<TNode,TEdge> Add(TNode node)
        {
            nodes.Add(node);
            return this;
        }
    }
}

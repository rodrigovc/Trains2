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
    public class Node<TNode, TEdge> : INode<TNode, TEdge>
        where TNode : INode<TNode, TEdge>
        where TEdge : IEdge<TNode, TEdge>
    {
        TNode node;
        IDictionary<TNode, TEdge> neighbours;

        public Node (TNode node) : this (node, new Dictionary<TNode, TEdge>()) { }

        public Node(TNode node, IDictionary<TNode, TEdge> neighbours)
        {
            this.node = node;
            this.neighbours = neighbours;
        }

        public TNode INode
        {
            get
            {
                return node;
            }
        }

        public IDictionary<TNode, TEdge> Neighbours
        {
            get
            {
                return neighbours;
            }
        }

        public Node<TNode, TEdge> AddNeighbour(TNode destination, TEdge distance)
        {
            neighbours.Add(destination, distance);
            return this;
        }
    }
}

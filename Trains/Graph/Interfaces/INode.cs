using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Graph.Interfaces;

namespace Trains.Graph.Interfaces
{
    public interface INode<TNode, TEdge> 
        where TNode : INode<TNode, TEdge>
        where TEdge : IEdge<TNode, TEdge>
    {
        TNode Node { get; }

        IDictionary<TNode, TEdge> Neighbours { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains.Graph.Interfaces;

namespace Trains.Graph.Interfaces
{

    public interface IEdge<out TNode, out TEdge> 
        where TNode : INode<TNode, TEdge>
        where TEdge : IEdge<TNode,TEdge>
    {
        TEdge Distance { get; }

        TNode Destination { get; }
    }
}
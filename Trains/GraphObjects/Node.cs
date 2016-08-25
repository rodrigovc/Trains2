using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trains;
using Trains.GraphObjects;

namespace Trains.GraphObjects
{
    public class Node 
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        //Nodes neighbors indexed by id
        public HashSet<Edge> Neighbors;

    }
}

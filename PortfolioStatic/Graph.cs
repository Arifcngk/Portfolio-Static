using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioStatic
{
    internal class Graph
    {
        public List<Node> Nodes { get; }

        public Graph()
        {
            Nodes = new List<Node>();
        }

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }

        public void AddEdge(Node kaynak, Node hedef)
        {
            Edge edge = new Edge(kaynak, hedef);
            kaynak.KomsuEkle(edge);
            hedef.KomsuEkle(edge);
        }

        public void Temizle()
        {
            Nodes.Clear();
        }
    }
}

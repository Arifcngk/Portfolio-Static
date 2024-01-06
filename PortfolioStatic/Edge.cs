using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioStatic
{
    internal class Edge
    {
        public Node Kaynak { get; }
        public Node Hedef { get; }

        public Edge(Node kaynak, Node hedef)
        {
            Kaynak = kaynak;
            Hedef = hedef;
        }


    }
}

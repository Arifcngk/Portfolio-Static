using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioStatic
{
    internal class Node
    {
        //Property'lerimize sadece get atıyoruz ki, daha sonra atanma yapılamasın.
        public string DersAdi { get; }
        public string Ogretmen { get; }
        public string Sinif { get; }
        public string Saat { get; }
        public string Gun { get; }
        public List<Edge> Komsular { get; }

        public Node(string dersAdi, string ogretmen, string sinif, string saat, string gun)
        {
            DersAdi = dersAdi;
            Ogretmen = ogretmen;
            Sinif = sinif;
            Saat = saat;
            Gun = gun;
            Komsular = new List<Edge>();
        }

        public void KomsuEkle(Edge edge)
        {
            Komsular.Add(edge);
        }
    }
}

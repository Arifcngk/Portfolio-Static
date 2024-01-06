using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioStatic
{
    //Dersleri gerekli inputlardan çekmek için gerekli Class
    internal class Lesson
    {
        public string Ad { get; }
        public string Ogretmen { get; }
        public string Sinif { get; }
        public string Saat { get; } 
        public string Gun { get; }

        public Lesson(string ad, string ogretmen, string sinif, string saat, string gun)
        {
            Ad = ad;
            Ogretmen = ogretmen;
            Sinif = sinif;
            Saat = saat;
            Gun = gun;
        }
    }
}

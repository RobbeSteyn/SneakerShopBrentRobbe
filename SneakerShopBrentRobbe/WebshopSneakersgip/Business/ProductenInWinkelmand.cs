using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebshopSneakersgip.Business
{
    public class ProductenInWinkelmand
    {
        public string Foto { get; set; }
        public int ProductID { get; set; }
        public string Naam { get; set; }
        public int Aantal { get; set; }
        public double Prijs { get; set; }
        public double Totaal { get; set; }
    }
}
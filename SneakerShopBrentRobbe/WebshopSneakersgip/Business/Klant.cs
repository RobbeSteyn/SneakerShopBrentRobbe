using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebshopSneakersgip.Business
{
    public class Klant
    {
        public int KlantID { get; set; }
        public string Klantnaam { get; set; }
        public string Adres { get; set; }
        public int Postcode { get; set; }
        public string Gemeente { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
    }
}
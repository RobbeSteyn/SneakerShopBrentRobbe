using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using WebshopSneakersgip.Business;

namespace WebshopSneakersgip.Persistence
{
    public class Persistencecode
    {
        string connstr = "server=localhost; user id=root; password=Fantic28; database=dbsneakers";

        //Persistence code om een product met bijhorende informatie op te halen.
        public List<Product> LoadProductenData()
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr); 
            conn.Open();

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "SELECT * FROM tblproducten";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();

            //Lijst aanmaken en doorsturen naar de Business laag.
            List<Product> lijst = new List<Product>();
            while (dtr.Read())
            {
                Product product = new Product();
                product.ProductID = Convert.ToInt32(dtr["ProductID"]);
                product.Naam = dtr["Naam"].ToString();
                product.Voorraad = Convert.ToInt32(dtr["Voorraad"]);
                product.Prijs = Convert.ToDouble(dtr["Prijs"]);
                product.Foto = dtr["Foto"].ToString();

                lijst.Add(product);
            }
            conn.Close();
            return lijst;
        }

        //Persistence code om te controleren of het product al in het winkelmandje zit.
        public bool CheckInWinkelmand(int ProductID)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            //Benoemen van de query en deze ook uitvoeren.
            string qry = "SELECT * FROM tblWinkelmand WHERE ProductID = " + ProductID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            //indien het product al in het winkelmandje zit geven we een false en kan hij het niet toevoegen, 
            //anders geven we een true.

            if (dtr.HasRows)
            {
                conn.Close();
                return false;
            }
            else
            {
                conn.Close();
                return true;
            }
        }

        //Persistence code voor het updaten van de voorraad na het toevoegen van een product.
        public void UpdateVoorraadMin(int ProductID, int _aantal, int _voorraad)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Het aanmaken van een nieuwe voorraad en deze vullen.
            int newvoorraad = _voorraad - _aantal;

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "UPDATE tblproducten SET Voorraad=" + newvoorraad + " WHERE ProductID=" + ProductID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Persistence code voor het tonen van het winkelmandje.
        public bool CheckWinkelmand()
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "SELECT * FROM tblWinkelmand";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();

            //Indien het winkelmandje een product bevat geven we een true en tonen we het winkelmandje,
            //anders geven we een false en tonen we dat het winkelmandje leeg is.
            if (dtr.HasRows)
            {
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }           
        }

        //Persistence code om het product toe te voegen aan het Winkelmandje.
        public void UploadToWinkelmand(Winkelmand w)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();   

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "INSERT into tblwinkelmand (KlantID, ProductID, Aantal) values (" + w.KlantID + ", " + w.ProductID + ", " + w.Aantal + ")";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Persistence code voor het verwijderen van een product uit het winkelmandje.
        public void DeleteFromWinkelmand(int ProductID, int KlantID)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "DELETE from tblwinkelmand where KlantID = " + KlantID + " AND ProductID = " + ProductID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Persistence code voor het tonen van de voorraad op de webpagina "toevoegen.aspx".
        public int LoadVoorraad()
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "SELECT voorraad FROM tblProducten";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            dtr.Read();

            //Het vullen van de propertie met de juiste gegevens uit de databank.
            int _voorraad = Convert.ToInt32(dtr["Voorraad"]);
            conn.Close();
            return _voorraad;
        }

        //Persistence code voor het updaten van de voorraad in de catalogus na het verwijderen van een product in het winkelmandje.
        public void UpdateVoorraadPlus(int ProductID, int _aantal, int _voorraad)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Het aanmaken van een nieuwe voorraad en deze vullen.
            int newvoorraad = _voorraad + _aantal;

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "UPDATE tblproducten SET Voorraad=" + newvoorraad + " WHERE ProductID=" + ProductID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Persistence code voor het ophalen van de klantgegevens.
        public string[] LoadKlantData(int KlantID)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "SELECT * FROM tblKlanten WHERE KlantID=" + KlantID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();

            //array aanmaken en doorsturen naar de Business laag.           
            string[] array = new string[4];
            while (dtr.Read())
            {
                array[0] = dtr["Voornaam"].ToString() + " " + dtr["Naam"].ToString();
                array[1] = dtr["Adres"].ToString();
                array[2] = dtr["Postcode"].ToString();
                array[3] = dtr["Gemeente"].ToString();
            }
       
            conn.Close();
            return array;
        }

        //Persistence code voor het ophalen van de juiste foto bij het juiste product.
        public string LoadFoto(int ProductID)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "SELECT Foto FROM tblProducten WHERE ProductID = '" + ProductID + "'";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            dtr.Read();

            //Het vullen van de propertie met de juiste gegevens uit de databank.
            string _foto = dtr["Foto"].ToString();
            conn.Close();
            return _foto;
        }

        //Persistence code voor het ophalen van de gegevens van de producten in het winkelmandje.
        public List<ProductenInWinkelmand> LoadFromProductenInWinkelmand(int KlantID)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "SELECT tblproducten.ProductID, Foto, Naam, Aantal, Prijs FROM tblProducten INNER JOIN tblWinkelmand ON tblProducten.ProductID = tblWinkelmand.ProductID WHERE KlantID=" + KlantID; 
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();

            //Lijst aanmaken en doorsturen naar de Business laag.
            List<ProductenInWinkelmand> Lijst = new List<ProductenInWinkelmand>();

            while (dtr.Read())
            {
                ProductenInWinkelmand Piw = new ProductenInWinkelmand();
                Piw.Foto = dtr["Foto"].ToString();
                Piw.ProductID = Convert.ToInt32(dtr["ProductID"]);
                Piw.Naam = dtr["Naam"].ToString();
                Piw.Aantal = Convert.ToInt32(dtr["Aantal"]);
                Piw.Prijs = Convert.ToDouble(dtr["Prijs"]);
                Piw.Totaal = Convert.ToDouble(dtr["Prijs"]) * Convert.ToDouble(dtr["Aantal"]);

                Lijst.Add(Piw);
            }
            conn.Close();
            return Lijst;
        }

        //Persistence code voor de totale prijzen te berekenen zoals BTWExcl, de BTW en BTWIncl.
        public Totalen BerekenTotalen()
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "select sum(Aantal * Prijs) as totaalExclBTW, 0.21 * sum(Aantal * Prijs) as BTW, sum(Aantal * Prijs) + 0.21 * sum(Aantal * Prijs) as totaalInclBTW " +
                         "from tblwinkelmand inner join tblProducten on tblWinkelmand.ProductID = tblProducten.ProductID";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();

            //De berekende totalen doorsturen naar de Business laag.
            Totalen tot = new Totalen();
            while (dtr.Read())
            {          
                tot.TotaalExclBTW = Convert.ToDouble(dtr["totaalExclBTW"]);
                tot.BTW = Convert.ToDouble(dtr["BTW"]);
                tot.TotaalInclBTW = Convert.ToDouble(dtr["totaalInclBTW"]);             
            }
            conn.Close();
            return tot;
        }

        //Persistence code voor het aanmaken van een bestelling.
        public void UploadOrder(DateTime datum, int KlantID)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Het aanmaken van een juiste datum voor weg te kunnen schrijven naar de databank.
            string juisteDatum = datum.ToString("yyyy-MM-dd hh:mm:ss");

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "INSERT INTO tblOrder (Orderdatum, KlantID) VALUES ('" + juisteDatum + "', " + KlantID + ")";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Persistence code voor het ophalen van een bestelling.
        public int LoadOrderID(DateTime datum)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Het aanmaken van een juiste datum voor weg te kunnen schrijven naar de databank.
            string juistedatum = datum.ToString("yyyy-MM-dd hh:mm:ss");

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "SELECT OrderID FROM tblorder WHERE Orderdatum = '" + juistedatum+ "'";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            dtr.Read();

            //Het vullen van de propertie met de juiste gegevens uit de databank.
            int _orderid = Convert.ToInt32(dtr["OrderID"]);
            conn.Close();
            return _orderid;
        }

        //Persistence code voor het ophalen van de prijs van bepaald product.
        public double LoadPrijs(int ProductID)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "SELECT Prijs FROM tblProducten WHERE ProductID = "  + ProductID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            dtr.Read();

            //Het vullen van de propertie met de juiste gegevens uit de databank.
            double _prijs = Convert.ToDouble(dtr["Prijs"]);
            conn.Close();
            return _prijs;
        }

        //Persistence code voor toevoegen van de bestellingsgegevens per product.
        public void UploadOrderLijn(int orderid, int productid, int aantal, double prijs)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "INSERT INTO tblorderlijn  (OrderID, ProductID, Aantal, Prijs) VALUES (" + orderid + ", " + productid + ", " + aantal + ", " + prijs + ")";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Persistence code voor het ophalen van het e-mailadres van de klant.
        public string LoadMail(int KlantID)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "SELECT Mail FROM tblKlanten WHERE KlantID=" + KlantID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();

            //string aanmaken en doorsturen naar de Business laag.           
            dtr.Read();

            //Het vullen van de propertie met de juiste gegevens uit de databank.
            string _mail = dtr["Mail"].ToString();
            conn.Close();
            return _mail;
        }

        //Persistence code voor het controleren van de login gegevens.
        public bool checkCredentials(string GebrNaam, string Wachtwoord)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "SELECT * FROM tblklanten WHERE GebruikersNaam= '" + GebrNaam + "' and binary Wachtwoord='" + Wachtwoord + "'";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();

            //Het aanmaken van een bool en de vlag op true zetten indien de gegevens overeenkomen,
            //anders staat de vlag op false.
            bool flag;
            if (dtr.HasRows)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            conn.Close();
            return flag;
        }

        //Persistence code voor het ophalen van de gebruikersnaam.
        public int getClientId(string gebrnaam)
        {
            //Aanmaken van een connectie en deze ook openen.
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();

            //Benoemen van de query en deze ook uitvoeren.
            string qry = "SELECT KlantId FROM tblklanten WHERE GebruikersNaam= '" + gebrnaam + "'";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();

            //Het vullen van de propertie met de juiste gegevens uit de databank.
            int klantnr = 0;
            while (dtr.Read())
            {
                klantnr = Convert.ToInt32(dtr["KlantId"]);
            }
            conn.Close();
            return klantnr;
        }

    }
}
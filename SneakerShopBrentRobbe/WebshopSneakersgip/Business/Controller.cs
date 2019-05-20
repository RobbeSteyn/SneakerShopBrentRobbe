using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebshopSneakersgip.Persistence;

namespace WebshopSneakersgip.Business
{
    public class Controller
    {
        Persistencecode _pers = new Persistencecode();

        public List<Product> LoadProductenData()
        {
            return _pers.LoadProductenData();
        }

        public string LoadFoto(int productid)
        {
            return _pers.LoadFoto(productid);
        }

            public bool CheckInWinkelmand(int ProductID)
        {
            return _pers.CheckInWinkelmand(ProductID);
        }

        public void UpdateVoorraadMin(int pid, int _a, int _v)
        {
            _pers.UpdateVoorraadMin(pid, _a, _v);
        }

        public bool CheckWinkelmand()
        {
            return _pers.CheckWinkelmand();
        }

        public void UploadToWinkelmand(int kid, int pid, int aant)
        {
            Winkelmand w = new Winkelmand();
            w.KlantID = kid; w.ProductID = pid; w.Aantal = aant;
            _pers.UploadToWinkelmand(w);
        }

        public void DeleteFromWinkelmand(int pid, int kid)
        {
            _pers.DeleteFromWinkelmand(pid, kid);
        }

        public int LoadVoorraad()
        {
            return _pers.LoadVoorraad();
        }

        public void UpdateVoorraadPlus(int pid, int _a, int _v)
        {
            _pers.UpdateVoorraadPlus(pid, _a, _v);
        }

        public List<ProductenInWinkelmand> LoadFromProductenInWinkelmand(int KlantID)
        {
            return _pers.LoadFromProductenInWinkelmand(KlantID);
        }

        public string[] LoadFromKlanten(int KlantID)
        {
            return _pers.LoadKlantData(KlantID);
        }

        public Totalen BerekenTotalen()
        {
            return _pers.BerekenTotalen();
        }

        public void UploadOrder(DateTime datum, int KlantID)
        {
            _pers.UploadOrder(datum, KlantID);
        }

        public int LoadOrderID(DateTime datum)
        {
            return _pers.LoadOrderID(datum);
        }

        public double LoadPrijs(int ProductID)
        {
            return _pers.LoadPrijs(ProductID);
        }

        public void UploadOrderlijn(int orderid, int productid, int aantal, double prijs)
        {
            _pers.UploadOrderLijn(orderid, productid, aantal, prijs);
        }

        public string LoadMail(int klantid)
        {
            return _pers.LoadMail(klantid);
        }

        public bool controleerAanmeldgegevens(string gebrnaam, string ww)
        {
            return _pers.checkCredentials(gebrnaam, ww);
        }

        public int haalKlantNrOp(string gebrnaam)
        {
            return _pers.getClientId(gebrnaam);
        }

    }
}
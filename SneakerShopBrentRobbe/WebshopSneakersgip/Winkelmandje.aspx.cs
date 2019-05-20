using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopSneakersgip.Business;

namespace WebshopSneakersgip
{
    public partial class Winkelmandje : System.Web.UI.Page
    {
        Controller _cont = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {  
            //Het controleren van het winkelmandje en de klantgegevens vullen met de gevulde array.
            if (_cont.CheckWinkelmand() == true)
            {
                lblKlantID.Text = Session["KlantID"].ToString();
                lblNaam.Text = _cont.LoadFromKlanten(Convert.ToInt32(Session["KlantID"]))[0];
                lblAdres.Text = _cont.LoadFromKlanten(Convert.ToInt32(Session["KlantID"]))[1];
                lblPcGe.Text = _cont.LoadFromKlanten(Convert.ToInt32(Session["KlantID"]))[2] + " " +
                _cont.LoadFromKlanten(Convert.ToInt32(Session["KlantID"]))[3];

                lblDatum.Text = DateTime.Now.ToLongDateString();

                //Het ophalen van het winkelmandje van de betreffende klant.
                gvWinkelmand.DataSource = _cont.LoadFromProductenInWinkelmand(Convert.ToInt32(Session["KlantID"]));
                gvWinkelmand.DataBind();

                lblExclBTW.Text = "€ " + Convert.ToString(_cont.BerekenTotalen().TotaalExclBTW);
                lblBTW.Text = "€ " + Convert.ToString(_cont.BerekenTotalen().BTW);
                lblInclBTW.Text = "€ " + Convert.ToString(_cont.BerekenTotalen().TotaalInclBTW);
            }
            else
            {
                //Het sluiten van de betreffende webpagina en "MandjeLeeg.aspx" openen.
                Response.Redirect("MandjeLeeg.aspx");
            }
           
        }

        protected void gvWinkelmand_SelectedIndexChanged(object sender, EventArgs e)
        {       
            //Het verwijderen van het product uit het winkelmandje.
            _cont.DeleteFromWinkelmand(Convert.ToInt32(gvWinkelmand.SelectedRow.Cells[2].Text), Convert.ToInt32(Session["KlantID"]));

            //Het updaten van de voorraad.
            _cont.UpdateVoorraadPlus(Convert.ToInt32(gvWinkelmand.SelectedRow.Cells[2].Text), Convert.ToInt32(gvWinkelmand.SelectedRow.Cells[4].Text), _cont.LoadVoorraad());

            //Het winkelmandje opnieuw controleren.
            if (_cont.CheckWinkelmand() == true)
            {
                gvWinkelmand.DataSource = _cont.LoadFromProductenInWinkelmand(Convert.ToInt32(Session["KlantID"]));
                gvWinkelmand.DataBind();

                lblExclBTW.Text = "€ " + Convert.ToString(_cont.BerekenTotalen().TotaalExclBTW);
                lblBTW.Text = "€ " + Convert.ToString(_cont.BerekenTotalen().BTW);
                lblInclBTW.Text = "€ " + Convert.ToString(_cont.BerekenTotalen().TotaalInclBTW);
            }
            else
            {
                //Het sluiten van de betreffende webpagina en "MandjeLeeg.aspx" openen.
                Response.Redirect("MandjeLeeg.aspx");
            }
        }

        protected void btnCatalogus_Click(object sender, EventArgs e)
        {
            //Het sluiten van de betreffende webpagina en "Default.aspx" openen.
            Response.Redirect("Default.aspx");
        }

        protected void btnBestellen_Click(object sender, EventArgs e)
        {
            //Het aanmaken van een bestelling.
            _cont.UploadOrder(DateTime.Now, Convert.ToInt32(Session["KlantID"]));

            //Het toevoegen van de gegevens van de bestelling per product en het leegmaken van het winkelmandje.
            for (int i = 0; i < gvWinkelmand.Rows.Count; i++)
            {
                _cont.UploadOrderlijn(_cont.LoadOrderID(DateTime.Now), Convert.ToInt32(gvWinkelmand.Rows[i].Cells[2].Text), Convert.ToInt32(gvWinkelmand.Rows[i].Cells[4].Text), _cont.LoadPrijs(Convert.ToInt32(gvWinkelmand.Rows[i].Cells[2].Text)));
                _cont.DeleteFromWinkelmand(Convert.ToInt32(gvWinkelmand.Rows[i].Cells[2].Text), Convert.ToInt32(Session["KlantID"]));
            }

            //De bestellingsnummer en het totaal beide in een Sessie steken.
            Session["OrderID"] = _cont.LoadOrderID(DateTime.Now);
            Session["Totaal"] = lblInclBTW.Text;

           //Het aanmaken en het versturen van de bevestiginsmail naar de betreffende klant.
            MailMessage _MailMessage = new MailMessage();
            _MailMessage.From = new MailAddress("brentnooyensja@gmail.com");
            _MailMessage.To.Add(_cont.LoadMail(Convert.ToInt32(Context.User.Identity.Name)));
            _MailMessage.Subject = "Bevestiging online bestelling Sneakersonline";
            AlternateView imgView = AlternateView.CreateAlternateViewFromString("Uw bestelling met ordernummer " + _cont.LoadOrderID(DateTime.Now) + " werd door ons goed ontvangen. " +
                "<br/>" + "Na betaling van " + Session["Totaal"] + " op rekeningnummer BE35 3631 7768 4337 zullen wij overgaan tot de verzending van de sneaker(s)." +
              "<br/>" + "Gelieve het ordernummer als betalingsreferentie mee te geven. " +
              "<br/>" + "Bedankt voor uw vertrouwen! " + "<br/><img src=cid:imgpath height=250 width=250>", null, "text/html");
            LinkedResource lr = new LinkedResource("C:/FinalVersionSneakers/dzazazazdzda/WebshopSneakersgip/Files/banner.jpg");
            lr.ContentId = "imgpath";
            imgView.LinkedResources.Add(lr);
            _MailMessage.AlternateViews.Add(imgView);
            _MailMessage.Body = lr.ContentId;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("brentnooyensja@gmail.com","olifanten123");
            smtp.Send(_MailMessage);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Email succesvol verstuurd !');", true);

            //Het sluiten van de betreffende webpagina en "Bestelbevestiging.aspx" openen.
            Response.Redirect("Bestelbevestiging.aspx");
        }
    }
}
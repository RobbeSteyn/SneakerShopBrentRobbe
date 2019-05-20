using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopSneakersgip.Business;

namespace WebshopSneakersgip
{
    public partial class Toevoegen : System.Web.UI.Page
    {
        Controller _cont = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Het ophalen van de Productgegevens uit de Sessie en de labels en ImageURL vullen.
            lblProductID.Text = Session["ProductID"].ToString();
            lblNaam.Text = Session["Naam"].ToString();
            lblVerkoopprijs.Text = Session["Verkoopprijs"].ToString();
            lblVoorraad.Text = Session["Voorraad"].ToString();
            imgProduct.ImageUrl = @"~/Files/" + _cont.LoadFoto(Convert.ToInt32(Session["ProductID"]));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Het controleren van het winkelmandje.
            if (_cont.CheckInWinkelmand(Convert.ToInt32(Session["ProductID"])) == true)
            {
                //De geschikte labels zichtbaar of onzichtbaar zetten.
                lblText.Visible = true; txtAantal.Visible = true; btnOk.Visible = true;
                lblFouttext.Visible = false; btnCatalogus.Visible = false;
                
                //Het updaten van de voorraad.
                _cont.UpdateVoorraadMin(Convert.ToInt32(Session["ProductID"]), Convert.ToInt32(txtAantal.Text), Convert.ToInt32(Session["Voorraad"]));

                _cont.UploadToWinkelmand(Convert.ToInt32(Session["KlantID"]), Convert.ToInt32(Session["ProductID"]), Convert.ToInt32(txtAantal.Text));

                //Het sluiten van de betreffende webpagina en "Winkelmandje.aspx" openen.
                Response.Redirect("Winkelmandje.aspx");
            }
            else
            {
                //De geschikte labels zichtbaar of onzichtbaar zetten.
                lblText.Visible = false; txtAantal.Visible = false; btnOk.Visible = false;
                lblFouttext.Visible = true; btnCatalogus.Visible = true;
            }
           
        }

        protected void btnCatalogus_Click(object sender, EventArgs e)
        {
            //Het sluiten van de betreffende webpagina en "Default.aspx" openen.
            Response.Redirect("Default.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace WebshopSneakersgip
{
    public partial class Bestelbevestiging : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //De tekstvakken vullen met de juiste gegevens.
            lblOrderID.Text = Session["OrderID"].ToString();
            lblTotaal.Text = Session["Totaal"].ToString();


        }

        protected void btnCatalogus_Click(object sender, EventArgs e)
        {
            //Het sluiten van de betreffende webpagina en "Default.aspx" openen.
            Response.Redirect("Default.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebshopSneakersgip.Business;

namespace WebshopSneakersgip
{
    public partial class Login : System.Web.UI.Page
    {
        Controller _cont = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAanmelden_Click(object sender, EventArgs e)
        {
            //Het controleren van de login gegevens.
            if (_cont.controleerAanmeldgegevens(txtGebnaam.Text, txtWachtwoord.Text))
            {
                int klantid = _cont.haalKlantNrOp(txtGebnaam.Text);
                Session["KlantID"] = klantid;
                FormsAuthentication.RedirectFromLoginPage(klantid.ToString(), false);
            }
            else
            {
                lblFout.Text = "Geen geldige aanmeldgegevens!";
            }
        }
    }
}
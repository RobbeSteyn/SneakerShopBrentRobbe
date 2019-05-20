using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebshopSneakersgip
{
    public partial class MandjeLeeg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            //Het sluiten van de betreffende webpagina en "Default.aspx" openen.
            Response.Redirect("Default.aspx");
        }
    }
}
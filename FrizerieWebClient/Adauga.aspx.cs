using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrizerieWebClient
{
    public partial class Adauga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtData.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
        }
        protected void btnSalveaza_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNume.Text))
            {
                lblMsg.Text = "Te rugăm să introduci numele!";
                return; 
            }

            if (string.IsNullOrEmpty(txtData.Text))
            {
                lblMsg.Text = "Te rugăm să selectezi o dată!";
                return; 
            }

            FrizerieRef.ProgramariServiceSoapClient proxy = new FrizerieRef.ProgramariServiceSoapClient();

            string rezultat = proxy.AdaugaInDB(txtNume.Text, DateTime.Parse(txtData.Text), ddlTip.SelectedValue);
            lblMsg.Text = rezultat;
        }


    }
}
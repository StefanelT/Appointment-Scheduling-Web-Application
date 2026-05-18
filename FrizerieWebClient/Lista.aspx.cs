using FrizerieWebClient.FrizerieRef;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrizerieWebClient
{
    public partial class Lista : System.Web.UI.Page
    {
        ProgramariServiceSoapClient proxy = new ProgramariServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IncarcaDate();
             
            }
            txtEditData.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void IncarcaDate()
        {
            try
            {
                gvProgramari.DataSource = proxy.GetToateProgramarile();
                gvProgramari.DataBind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Eroare la încărcare: " + ex.Message;
            }
        }

        protected void gvProgramari_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditeazaProgramare")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvProgramari.Rows[rowIndex];
                hfEditId.Value = gvProgramari.DataKeys[rowIndex].Value.ToString();
                txtEditNume.Text = row.Cells[0].Text;
                DateTime data = DateTime.Parse(row.Cells[1].Text);
                txtEditData.Text = data.ToString("yyyy-MM-dd");
                ddlEditTip.SelectedValue = row.Cells[2].Text;
                lblModalMsg.Text = "";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            }


            if (e.CommandName == "StergeProgramare")
            {
                    int idDeSters = Convert.ToInt32(e.CommandArgument);
                    string mesaj = proxy.StergeProgramare(idDeSters);

                    lblStatus.Text = mesaj;
                    lblStatus.ForeColor = System.Drawing.Color.Green;

                    IncarcaDate();
                
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
                int id = int.Parse(hfEditId.Value);
                DateTime data = DateTime.Parse(txtEditData.Text);

                FrizerieRef.ProgramariServiceSoapClient proxy = new FrizerieRef.ProgramariServiceSoapClient();
                string rezultat = proxy.ModificaProgramare(id, txtEditNume.Text, data, ddlEditTip.SelectedValue);
                if (rezultat.StartsWith("Eroare:"))
                {
                    lblModalMsg.Text = rezultat.Replace("Eroare:", "");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
                else
                {
                    
                    lblStatus.Text = rezultat;
                    lblStatus.ForeColor = System.Drawing.Color.Green;

                    IncarcaDate(); 
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
                }

         }
    }
}
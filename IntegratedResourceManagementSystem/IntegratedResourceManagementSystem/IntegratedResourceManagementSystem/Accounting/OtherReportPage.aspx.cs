using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;

namespace IntegratedResourceManagementSystem.Accounting
{
    public partial class OtherReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rblist1.SelectedIndex = 0;

                LoadBrand();
            }
        }

        protected void LoadBrand()
        {

            BrandManager BM = new BrandManager();

            try
            {
                cboBrand.DataSource = BM.Brands();
                cboBrand.DataTextField = "BrandDescription";
                cboBrand.DataValueField = "BrandDescription";
                cboBrand.DataBind();

                cboBrand.Items.Insert(0, new ListItem("- ALL -", "0"));
                cboBrand.SelectedIndex = 0;
            }
            catch
            {
                throw;
            }
        }
        protected void CheckValues()
        {



            if (YearMenu.GetValue == "")
            {
                ValMsg.Visible = true;
                ValMsg.SetValue("REQUIRED TO SELECT YEAR");
            }
            else
            {

                ValMsg.Visible = false;

                DateTime Years = Convert.ToDateTime(YearMenu.GetValue);
                string Brands = cboBrand.SelectedValue;
                string CategoryValue = CategoryMenu.GetValue;

                string CategoryDesc = string.Empty;
                if (CategoryValue == "ALL")
                {
                    CategoryDesc = "TOPS / BOTTOMS";
                }
                else if (CategoryValue == "T")
                {
                    CategoryDesc = "TOPS";
                }
                else if (CategoryValue == "B")
                {
                    CategoryDesc = "BOTTOMS";
                }
                else if (CategoryValue == "D")
                {
                    CategoryDesc = "DAMAGED";
                }
                else if (CategoryValue == "A")
                {
                    CategoryDesc = "ACCESSORIES";
                }


                Session["Years"] = Years;
                Session["Brand"] = Brands;
                Session["Category"] = CategoryDesc;
                Session["CategoryValue"] = CategoryValue;
                string url = "../Reports/ReportForms/PhysicalInventory.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));

            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                CheckValues();
            }
            catch
            {
                throw;
            }
        }
    }
}
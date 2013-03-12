using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IRMS.BusinessLogic.Manager;

namespace IntegratedResourceManagementSystem.Reports.ReportForms
{
    public partial class PhysicalInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            InitializeReport();
        }

        private void InitializeReport()
        {
            try
            {
                DateTime Years = Convert.ToDateTime(Session["Years"]);
                string Brands = Convert.ToString(Session["Brand"]);
                string Category  = Convert.ToString(Session["Category"]);
                string CategoryValue = Convert.ToString(Session["CategoryValue"]);


                if (Brands == "0")
                {
                    lblBrand.Text = "ALL";
                }
                else
                {
                    lblBrand.Text = Brands;
                }

               
                lblCategory.Text = Category;
                lblYear.Text = "YEAR OF " + Years.Year.ToString() + "";

                PhysicalInventoryManager PIM = new PhysicalInventoryManager();

                if (Brands == "0")
                {
                    GridView1.DataSource = PIM.LoadReportPhysicalInventory(Years.Year,CategoryValue);
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = PIM.LoadReportPhysicalInventoryPerBrand(Years.Year, Brands, CategoryValue);
                    GridView1.DataBind();
                }


                double TotolSrpQty = 0;
                double TotolSrpAmount = 0;

                double TotolMrdQty = 0;
                double TotolMrdAmount = 0;

                double GrandTotolQty = 0;
                double GrandTotolAmount = 0;


                if (GridView1.Rows.Count != 0)
                {

                    foreach (GridViewRow item in GridView1.Rows)
                    {


                        TotolSrpQty += Convert.ToDouble(item.Cells[1].Text);
                        TotolSrpAmount += Convert.ToDouble(item.Cells[3].Text);

                        TotolMrdQty += Convert.ToDouble(item.Cells[4].Text);
                        TotolMrdAmount += Convert.ToDouble(item.Cells[6].Text);

                        GrandTotolQty += Convert.ToDouble(item.Cells[7].Text);
                        GrandTotolAmount += Convert.ToDouble(item.Cells[8].Text);
                    }



                    GridView1.FooterRow.Cells[1].Text = TotolSrpQty.ToString("###,###,###,##0");
                    GridView1.FooterRow.Cells[3].Text = TotolSrpAmount.ToString("###,###,##0.00");

                    GridView1.FooterRow.Cells[4].Text = TotolMrdQty.ToString("###,###,##0");
                    GridView1.FooterRow.Cells[6].Text = TotolMrdAmount.ToString("###,###,##0.00");

                    GridView1.FooterRow.Cells[7].Text = GrandTotolQty.ToString("###,###,##0");
                    GridView1.FooterRow.Cells[8].Text = GrandTotolAmount.ToString("###,###,##0.00");
                }
            }
            catch
            {
                throw;
            }

        }

         
    }
}
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using Telerik.Web.UI;

namespace JAFrontendWeb.controls
{
    public partial class ViewApplicant : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                BindData(1);
        }

        //Set the Pager Row here.
        protected void gvViewApplicant_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                SetPagerButtonStates(gvViewApplicant, e.Row, this.Page, "ddlPageSelector");
            }
        }

        //Get the Index no. from Page DropdownList and Bind the current page.
        protected void ddlPageSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvViewApplicant.PageIndex = ((DropDownList)sender).SelectedIndex;
            BindData(gvViewApplicant.PageIndex);
        }

        //GridView Page Index Changing and Bind the current Page index

        protected void gvViewApplicant_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvViewApplicant.PageIndex = e.NewPageIndex;
            BindData(e.NewPageIndex);
        }

        private void BindData(int pageIndex)
        {
            var list = GetListApplicantData(pageIndex);
            panelNoApplicant.Visible = !(list.Count() > 0);

            gvViewApplicant.DataSource = list;
            gvViewApplicant.DataBind();
        }

        public void SetPagerButtonStates(GridView gridView, GridViewRow gvPagerRow, Page page, string DDlPager)
        {
            // to Get No of pages and Page Navigation
            int pageIndex = gridView.PageIndex;
            int pageCount = gridView.PageCount;
            ImageButton btnFirst = (ImageButton)gvPagerRow.FindControl("ImgeBtnFirst");
            ImageButton btnPrevious = (ImageButton)gvPagerRow.FindControl("ImgbtnPrevious");
            ImageButton btnNext = (ImageButton)gvPagerRow.FindControl("ImgbtnNext");
            ImageButton btnLast = (ImageButton)gvPagerRow.FindControl("ImgbtnLast");
            btnFirst.Enabled = btnPrevious.Enabled = (pageIndex != 0);
            btnNext.Enabled = btnLast.Enabled = (pageIndex < (pageCount - 1));
            DropDownList ddlPageSelector = (DropDownList)gvPagerRow.FindControl(DDlPager);
            ddlPageSelector.Items.Clear();
            for (int i = 1; i <= gridView.PageCount; i++)
            {
                ddlPageSelector.Items.Add(i.ToString());
            }
            ddlPageSelector.SelectedIndex = pageIndex;
            string strPgeIndx = Convert.ToString(gridView.PageIndex + 1) + " of "
                                + gridView.PageCount.ToString();

            Label lblpageindx = (Label)gvPagerRow.FindControl("lblpageindx");
            lblpageindx.Text += strPgeIndx;
        }

        private List<com.jabackendservice.ApplicantDto> GetListApplicantData(int pageIndex)
        {
            com.jabackendservice.JAService jaService = new com.jabackendservice.JAService();
            var r = jaService.RetrieveAllApplicants();
            return r == null? new List <com.jabackendservice.ApplicantDto>() : r.ToList();
        }
    }
}
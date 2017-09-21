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
using JAFrontendWeb.controls;

namespace JAFrontendWeb
{
    public partial class Index : BasePage
    {
        #region Constants
        private const string SCRIPT_INVOKE_MODAL = "javascript:InvokeModalDialogShow('{0}'); return false";
        #endregion

        #region Variable
        //BookSellerWebService bookSellerWebService;
        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            //userNav.CustomerID = ebizCart.CustomerID = CustomerID;
            //ebizCart.Visible = IsAuthenticated;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //bookSellerWebService = new BookSellerWebService();
            
            //Book[] col = bookSellerWebService.GetAllBooks();
        }

        protected void rptDisplay_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    Book book = e.Item.DataItem as Book;

            //    Label lbl;
            //    LinkButton linkBtn;
            //    PlaceHolder ph;
            //    Button btn;
            //    HtmlGenericControl div;

            //    linkBtn = e.Item.FindControl("linkBookTitle") as LinkButton;
            //    linkBtn.Text = book.Title;
            //    linkBtn.OnClientClick = String.Format(SCRIPT_INVOKE_MODAL, book.BookID);

            //    lbl = e.Item.FindControl("lblISBN") as Label;
            //    lbl.Text = book.BookISBN;

            //    lbl = e.Item.FindControl("lblDescription") as Label;
            //    string bookDesc = (book.Description.Length > 180) ?
            //                        book.Description.Replace(book.Description.Substring(180, book.Description.Length - 180), " ...")
            //                        : book.Description;

            //    lbl.Text = bookDesc;

            //    lbl = e.Item.FindControl("lblPubYear") as Label;
            //    lbl.Text = book.PublicationYear.ToString();

            //    lbl = e.Item.FindControl("lblPrice") as Label;
            //    lbl.Text = book.SellingPrice.ToString();

            //    lbl = e.Item.FindControl("lblQuantity") as Label;
            //    lbl.Text = book.InventoryQuantity.ToString();
            //    lbl.ID = "lblQuantityBookID" + book.BookID.ToString();

            //    ph = e.Item.FindControl("phDiscountedPrice") as PlaceHolder;
            //    ph.Visible = (book.Discount > 0);
            //    if (ph.Visible)
            //    {
            //        lbl = e.Item.FindControl("lblDiscountedPrice") as Label;
            //        lbl.Text = book.DiscountedPrice.ToString();
            //    }

            //    ph = e.Item.FindControl("phBuyNow") as PlaceHolder;
            //    ph.Visible = IsAuthenticated && (book.InventoryQuantity > 0);
            //    if (ph.Visible)
            //    {
            //        btn = e.Item.FindControl("btnBuyNow") as Button;
            //        btn.OnClientClick = String.Format("javascript:AddItem(this,{0});return false;", book.BookID);

            //        div = e.Item.FindControl("divBuyNowButton") as HtmlGenericControl;
            //        div.ID = "divBuyNowButton" + book.BookID.ToString();
            //    }
            //}
        }

        //private void SetFilterView(string filterText, Book[] bookCol)
        //{
        //    lblFilterView.Text = filterText;
        //    rptDisplay.DataSource = bookCol;
        //    rptDisplay.DataBind();
        //}
    }
}

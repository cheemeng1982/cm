<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="JAFrontendWeb.Index" MasterPageFile="~/MasterPages/Base.Master" %>
<%@ MasterType VirtualPath="~/MasterPages/Base.Master" %>
<%@ Register Namespace="Telerik.Web.UI" TagPrefix="telerik" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="NAV" TagName="UserNavigation" Src="controls/UserNavigation.ascx" %>


<asp:Content ContentPlaceHolderID="cphLeftContainer" ID="contentLeft" runat="server">
    <div class="infoBox">
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="cphMiddleContainer" ID="contentMain" runat="server">
    <asp:ScriptManagerProxy ID="serviceScriptManagerProxy" runat="server">
        <Services>
        </Services>
    </asp:ScriptManagerProxy>
    <telerik:RadWindowManager ID="windowManager" runat="server" EnableEmbeddedSkins="true" Skin="Gray"
        VisibleStatusbar="false" VisibleTitlebar="false" ReloadOnShow="false" Modal="true">
        <Windows>
            <telerik:RadWindow ID="dialogBookDetailPreview" runat="server" ReloadOnShow="false" VisibleOnPageLoad="false" 
                VisibleStatusbar="false" VisibleTitlebar="true" Behavior="Close,Move" Modal="true"></telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    
    <asp:UpdatePanel ID="updatePanelBookDisplay" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div class="filterHeader">
                <h3>
                    <asp:Label ID="lblFilterView" runat="server"></asp:Label>
                </h3>
            </div>
            <asp:Repeater ID="rptDisplay" runat="server" OnItemDataBound="rptDisplay_OnItemDataBound">
                <ItemTemplate>
                    <div class="rptBookDisplay">
                        <table cellpadding=0 cellspacing=0 border=0>
                            <tr>
                                <td>
                                    Title :
                                </td>
                                <td>
                                    <asp:LinkButton ID="linkBookTitle" runat="server"></asp:LinkButton>
                                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    ISBN :
                                </td>
                                <td>
                                    <asp:Label ID="lblISBN" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Description :
                                </td>
                                <td>
                                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    Publication Year :
                                </td>
                                <td>
                                    <asp:Label ID="lblPubYear" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Price :
                                </td>
                                <td>
                                    <asp:Label ID="lblPrice" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <asp:PlaceHolder ID="phDiscountedPrice" runat="server" Visible="false">
                                <tr>
                                    <td>
                                        Discounted Price :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDiscountedPrice" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </asp:PlaceHolder>
                            <tr>
                                <td>
                                    Quantity Available :
                                </td>
                                <td>
                                    <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <asp:PlaceHolder ID="phBuyNow" runat="server" Visible="false">
                                <tr>
                                    <td colspan="2">
                                        <div ID="divBuyNowButton" runat="server" class="btnBuyNow">
                                            <asp:Button ID="btnBuyNow" runat="server" CssClass="buttonOrange" Text="Buy Now"/>
                                        </div>
                                    </td>
                                </tr>
                            </asp:PlaceHolder>
                        </table>
                        <span class="clear"></span>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>

<asp:HiddenField ID="hdTogglePanel" runat="server" />

<script src="../Stylesheets/page_Index.js" type="text/javascript">
</script>
<script language="javascript" type="text/javascript">
function InvokeModalDialogShow(bookID)
{
    var oManager = GetRadWindowManager();
    var oWindow = oManager.GetWindowByName('dialogBookDetailPreview');
    if (oWindow)
    {
        oWindow.SetUrl('../Books/ViewBookDetails.aspx?BookID=' + bookID);
        oWindow.SetSize(600,400);
        oWindow.Show();
    }
}

function AddItem(obj,bookID)
{
    if(cart != null)
    {
        AddBookToCart(obj,bookID);
    }
}

var hdTogglePanel = document.getElementById('<%= hdTogglePanel.ClientID %>');
Sys.Application.add_load(function(){
    
    if(hdTogglePanel.value == '' || hdTogglePanel.value == null)
    {
        hdTogglePanel.value = '1,1,1,1'; //initial value
    }
    else
    {
        var arr = hdTogglePanel.value.split(',');
        if(arr.length > 3)
            setInitToggleStatePostback(arr);
    }
});
</script>
</asp:Content>

<asp:Content ContentPlaceHolderID="cphRightContainer" ID="contentRight" runat="server">
    <NAV:UserNavigation ID="userNav" runat="server"></NAV:UserNavigation>
</asp:Content>

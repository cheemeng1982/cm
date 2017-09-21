<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ViewApplicant.aspx.cs" Inherits="JAFrontendWeb.Account.ViewApplicant" MasterPageFile="~/MasterPages/Secondary.Master" %>
<%@ MasterType VirtualPath="~/MasterPages/Secondary.Master" %>
<%@ Register Namespace="Telerik.Web.UI" TagPrefix="telerik" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="Control" TagName="ViewApplicant" Src="../controls/ViewApplicant.ascx" %>
<%@ Register TagPrefix="NAV" TagName="UserNavigation" Src="../controls/UserNavigation.ascx" %>

<asp:Content ContentPlaceHolderID="cphMiddleContainer" ID="contentMain" runat="server">
    <div class="accountCreationOuterWrapper">
        <Control:ViewApplicant ID="viewApplicant" runat="server"></Control:ViewApplicant>
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="cphRightContainer" ID="contentRight" runat="server">
    <NAV:UserNavigation ID="userNav" runat="server"></NAV:UserNavigation>
</asp:Content>

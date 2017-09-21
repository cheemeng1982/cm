<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplicantCreation.aspx.cs" Inherits="JAFrontendWeb.Account.ApplicantCreation" MasterPageFile="~/MasterPages/Secondary.Master"  %>
<%@ MasterType VirtualPath="~/MasterPages/Secondary.Master" %>
<%@ Register Namespace="Telerik.Web.UI" TagPrefix="telerik" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="APPLICANT" TagName="ApplicantCreate" Src="../controls/ApplicantCreate.ascx" %>
<%@ Register TagPrefix="NAV" TagName="UserNavigation" Src="../controls/UserNavigation.ascx" %>

<asp:Content ContentPlaceHolderID="cphMiddleContainer" ID="contentMain" runat="server">
    <div class="accountCreationOuterWrapper">
        <div>
            <h2>
                <img src="../../images/file.gif" /><span class="accountHeader">Applicant Data</span>
            </h2>
        </div>
        <asp:Label ID="lblNotice" runat="server" CssClass="errorNotice"></asp:Label>
        <APPLICANT:ApplicantCreate ID="applicantCreation" runat="server" OnSubmitApplicantCreate="OnApplicant_Create"></APPLICANT:ApplicantCreate>
    </div>
</asp:Content>

<asp:Content ContentPlaceHolderID="cphRightContainer" ID="contentRight" runat="server">
    <NAV:UserNavigation ID="userNav" runat="server"></NAV:UserNavigation>
    <br />
    <div class="userLogo"></div>
</asp:Content>

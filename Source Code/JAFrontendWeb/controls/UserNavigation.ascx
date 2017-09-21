<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserNavigation.ascx.cs" Inherits="JAFrontendWeb.controls.UserNavigation" %>
<%@ Register Namespace="Telerik.Web.UI" TagPrefix="telerik" Assembly="Telerik.Web.UI" %>

<div>
    <telerik:RadCalendar ID="calendar" runat="server" EnableMultiSelect="false" Skin="Inox">
        <specialdays> 
            <telerik:radcalendarday repeatable="Today" date=""> 
                <ItemStyle CssClass="radCalToday_Inox"> </ItemStyle> 
            </telerik:radcalendarday> 
        </specialdays>
    </telerik:RadCalendar>
    
    <div class="UserNavigation">
        <div class="title">
            Navigation
        </div>
        <asp:PlaceHolder ID="phAnonymouse" runat="server" >
            <asp:LinkButton ID="linkCreateApplicant" runat="server" Text="<div>Create Applicant</div>" CommandArgument="applicantCreation" OnCommand="Edit" CausesValidation="false"></asp:LinkButton>
            <asp:LinkButton ID="linkViewApplicant" runat="server" Text="<div>View Applicant Data</div>" CommandArgument="viewApplicant" OnCommand="Edit"  CausesValidation="false"></asp:LinkButton>
            <asp:LinkButton ID="linkHome" runat="server" Text="<div>Home</div>" CommandArgument="backHome" OnClick="linkHome_Click"  CausesValidation="false"></asp:LinkButton>
        </asp:PlaceHolder>
    </div>
</div>

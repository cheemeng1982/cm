<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewApplicant.ascx.cs" Inherits="JAFrontendWeb.controls.ViewApplicant" %>
<%@ Register Namespace="Telerik.Web.UI" TagPrefix="telerik" Assembly="Telerik.Web.UI" %>

<div>
    <h2>
        <img src="../../images/visit.gif" /><span class="accountHeader">Applicant Data</span>
    </h2>
</div>
<div>
    <asp:Panel ID="panelNoApplicant" runat="server" Visible="false">
        No applicant record.
    </asp:Panel>

    <div>
        <asp:GridView ID="gvViewApplicant" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gvViewApplicant_PageIndexChanging" Width="100%" AllowPaging="True" PageSize="10" OnRowCreated="gvViewApplicant_RowCreated">

            <HeaderStyle HorizontalAlign="Center" BackColor="#2D96CE" ForeColor="White" />
            <AlternatingRowStyle BackColor="#D4EFFD" />

            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblApplicantId" runat="Server" Text='<%# Eval("ApplicantId") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="Server" Text='<%# Eval("FirstName") + " " + Eval("LastName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label ID="lblCorrespondenceAddress" runat="Server" Text='<%# Eval("CorrespondenceAddress") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Company Name">
                    <ItemTemplate>
                        <asp:Label ID="lblCompanyName" runat="Server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>

                  <asp:TemplateField HeaderText="Phone">
                    <ItemTemplate>
                        <asp:Label ID="lblPhone" runat="Server" Text='<%# Eval("Phone") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>

                  <asp:TemplateField HeaderText="E-mail">
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="Server" Text='<%# Eval("Email") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>

                  <asp:TemplateField HeaderText="Job Title">
                    <ItemTemplate>
                        <asp:Label ID="lblJobTitle" runat="Server" Text='<%# Eval("JobTitle") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>

                  <asp:TemplateField HeaderText="Job Spec.">
                    <ItemTemplate>
                        <asp:Label ID="lblJobSpecification" runat="Server" Text='<%# Eval("JobSpecification") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>

                  <asp:TemplateField HeaderText="Location">
                    <ItemTemplate>
                        <asp:Label ID="lblLocation" runat="Server" Text='<%# Eval("LocationName") + " - " + Eval("SubLocationName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>

                  <asp:TemplateField HeaderText="Industry">
                    <ItemTemplate>
                        <asp:Label ID="lblIndustry" runat="Server" Text='<%# Eval("IndustryName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                      </asp:TemplateField>

                       <asp:TemplateField HeaderText="Salary">
                    <ItemTemplate>
                        <asp:Label ID="lblSalaryRange" runat="Server" Text='<%# Eval("SalaryRange") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>
            </Columns>

            <PagerStyle Height="8px" HorizontalAlign="Center" />
            <PagerTemplate>
                <table style="width: 100%;" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="right" style="width: 60%;">
                            <table>
                                <tr>
                                    <td style="padding-top:3px">
                                        <asp:ImageButton ToolTip="First Page" CommandName="Page" CommandArgument="First" runat="server" ID="ImgeBtnFirst" ImageUrl="../Images/First.jpg" />
                                    </td>

                                    <td>
                                        <asp:ImageButton ToolTip="Previous Page" CommandName="Page" CommandArgument="Prev" runat="server" ID="ImgbtnPrevious" ImageUrl="../Images/Previous.jpg" />
                                    </td>
                                    <td >
                                        <asp:DropDownList ToolTip="Goto Page" ID="ddlPageSelector" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSelector_SelectedIndexChanged" CssClass="combo_common_nowidth">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="padding-top:3px">
                                        <asp:ImageButton ToolTip="Next Page" CommandName="Page" CommandArgument="Next" runat="server" ID="ImgbtnNext" ImageUrl="../Images/Next.jpg" />
                                    </td>
                                    <td style="padding-top:3px">
                                        <asp:ImageButton ToolTip="Last Page" CommandName="Page" CommandArgument="Last" runat="server" ID="ImgbtnLast" ImageUrl="../Images/Last.jpg" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 40%" align="right">
                            <asp:Label ID="lblpageindx" CssClass="labelBold" Text="Page : " runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </PagerTemplate>
        </asp:GridView>
        <span class="clear"></span>
    </div>

</div>


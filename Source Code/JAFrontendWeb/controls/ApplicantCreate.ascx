<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ApplicantCreate.ascx.cs" Inherits="JAFrontendWeb.controls.ApplicantCreate" %>
<%@ Register Namespace="Telerik.Web.UI" TagPrefix="telerik" Assembly="Telerik.Web.UI" %>

<asp:ValidationSummary ID="validationSummary" runat="server" CssClass="validationSummary"></asp:ValidationSummary>
<div class="container">
    <div class="containerHead">
        <div class="containerHeadInner">&nbsp;</div>
    </div>
    <div class="containerBody">
        <table cellpadding="5" border="0" cellspacing="0">
            <tr>
                <td>First Name<span class="isRequired"> *</span>
                </td>
                <td>
                    <asp:TextBox ID="txtboxFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="vldFirstName" ControlToValidate="txtboxFirstName" Text="<span class='errorNotice'>!</span>" ErrorMessage="First name cannot be empty." Display="Dynamic" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Last Name
                </td>
                <td>
                    <asp:TextBox ID="txtboxLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Company Name<span class="isRequired"> *</span>
                </td>
                <td>
                    <asp:TextBox ID="txtboxCompanyName" runat="server" TextMode="MultiLine" Rows="3" Width="300"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="vdCompanyName" ControlToValidate="txtboxCompanyName" Text="<span class='errorNotice'>!</span>" ErrorMessage="Company name cannot be empty." Display="Dynamic" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Phone<span class="isRequired"> *</span>
                </td>
                <td>
                    <asp:TextBox ID="txtboxPhone" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="vldPhone" ControlToValidate="txtboxPhone" Text="<span class='errorNotice'>!</span>" ErrorMessage="Phone number cannot be empty." Display="Dynamic" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Email<span class="isRequired"> *</span>
                </td>
                <td>
                    <asp:TextBox ID="txtboxEmail" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="vldEmailRegularExp" runat="server" ControlToValidate="txtboxEmail" ErrorMessage="Email invalid format" Text="<span class='errorNotice'>!</span>" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="vldEmailRequired" ControlToValidate="txtboxEmail" Text="<span class='errorNotice'>!</span>" ErrorMessage="Email cannot be empty." Display="Dynamic" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Correspondence Address<span class="isRequired"> *</span>
                </td>
                <td>
                    <asp:TextBox ID="txtboxAddress" runat="server" TextMode="MultiLine" Rows="3" Width="300"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="vldAddress" ControlToValidate="txtboxAddress" Text="<span class='errorNotice'>!</span>" ErrorMessage="Address cannot be empty." Display="Dynamic" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Job Title<span class="isRequired"> *</span>
                </td>
                <td>
                    <asp:TextBox ID="txtboxJobTitle" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="vldJobTitle" ControlToValidate="txtboxJobTitle" Text="<span class='errorNotice'>!</span>" ErrorMessage="Job title cannot be empty." Display="Dynamic" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Job Specification<span class="isRequired"> *</span>
                </td>
                <td>
                    <asp:TextBox ID="txtboxJobSpecification" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="vldJobSpecification" ControlToValidate="txtboxJobSpecification" Text="<span class='errorNotice'>!</span>" ErrorMessage="Job specification cannot be empty." Display="Dynamic" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Location
                </td>
                <td>
                    <asp:DropDownList ID="listLocation" runat="server" EnableViewState="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Industry
                </td>
                <td>
                    <asp:DropDownList ID="listIndustry" runat="server" EnableViewState="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Salary Range
                </td>
                <td>
                    <asp:DropDownList ID="listSalaryRange" runat="server" EnableViewState="true">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <span class="clear"></span>
        <!--Captcha-->
        <div style="padding:10px 0px 10px 2px">
            <table>
                <tr>
                    <td>
                        <b>Captcha Verification</b><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="txtCaptcha"
                            style="background-image: url('../images/bgCaptcha.JPG'); text-align: center; border: none; font-weight: bold; font-family: Modern" />
                        <input type="button" id="btnrefresh" value="Refresh" onclick="DrawCaptcha();" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="txtInput" />
                    </td>
                </tr>
               <%-- <tr>
                    <td>
                        <input id="Button1" type="button" value="Check" onclick="alert(ValidCaptcha());" />
                    </td>
                </tr>--%>
            </table>
        </div>
    </div>
</div>
<div class="buttonContainer">
    <div>
        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClientClick="javascript:ResetAll();return false;" Class="buttonOrange"  />
    </div>
    <div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Class="buttonOrange" OnClientClick="return ValidCaptcha();"  />
    </div>
</div>
<span class="clear"></span>

<script language="javascript" type="text/javascript">
    function ResetAll() {
        var node_list = document.getElementsByTagName('input');

        for (var i = 0; i < node_list.length; i++) {
            var node = node_list[i];

            if (node.getAttribute('type') == 'text') {
                node.value = '';
            }
        }

        //Dropdown list
        document.getElementById('<%= listIndustry.ClientID %>').options.selectedIndex = 0;
        document.getElementById('<%= listSalaryRange.ClientID %>').options.selectedIndex = 1;

        //Address
        var addressTextArea = $get('<%= txtboxAddress.ClientID %>');
        if (addressTextArea)
            addressTextArea.value = '';

        //Captcha
        $('#txtInput').val = '';
        DrawCaptcha();

        return false;
    }
</script>

  <script type="text/javascript">
      //Created / Generates the captcha function    
      //Reference: https://www.codeproject.com/Articles/42842/Implementation-of-Captcha-in-Javascript

      function DrawCaptcha()
      {
          var a = Math.ceil(Math.random() * 10) + '';
          var b = Math.ceil(Math.random() * 10) + '';
          var c = Math.ceil(Math.random() * 10) + '';
          var d = Math.ceil(Math.random() * 10) + '';
          var e = Math.ceil(Math.random() * 10) + '';
          var f = Math.ceil(Math.random() * 10) + '';
          var g = Math.ceil(Math.random() * 10) + '';
          var code = a + ' ' + b + ' ' + ' ' + c + ' ' + d + ' ' + e + ' ' + f + ' ' + g;
          document.getElementById("txtCaptcha").value = code;
          $('#txtInput').val = '';
      }

      // Validate the Entered input aganist the generated security code function   
      function ValidCaptcha()
      {
          var str1 = removeSpaces(document.getElementById('txtCaptcha').value);
          var str2 = removeSpaces(document.getElementById('txtInput').value);
          if (str1 == str2) {
              return true;
          }
          alert('Invalid captcha input.');
          return false;

      }

      // Remove the spaces from the entered and generated code
      function removeSpaces(string)
      {
          return string.split(' ').join('');
      }

      DrawCaptcha();
      

    </script>




<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowCommonMaster.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 146px;
        }
        .style4
        {
            width: 171px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <br />
    <br />
    <table class="style2">
        <tr>
            <td class="style3">
                User Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            </td>
            <td class="style4">
        <asp:TextBox ID="txtUserId" runat="server" 
            ontextchanged="txtUserId_TextChanged"></asp:TextBox>
            </td>
            <td>
        <asp:RequiredFieldValidator ID="rfvUserId" runat="server" 
        ControlToValidate="txtUserId">User Id is mandatory</asp:RequiredFieldValidator>
                <br />
    <asp:RegularExpressionValidator ID="revUserIdLength" runat="server" 
    ControlToValidate="txtUserId" 
    ErrorMessage="UserId should contain exactly 5 characters" 
    ValidationExpression="\w{5}"></asp:RegularExpressionValidator>

            </td>
        </tr>
        <tr>
            <td class="style3">
                Password&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;</td>
            <td class="style4">
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
        ErrorMessage="Password is mandatory" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                <br />
    <asp:RegularExpressionValidator ID="revPassword" runat="server" 
        ControlToValidate="txtPassword" 
        ErrorMessage="Password must contain atleast 6 characters with one alphabet and one digit" 
        ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,50})$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style4">
<asp:Label ID="lblStatus" runat="server" Text="Label" ForeColor="#FF3300"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style4">
        <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click1" 
            Text="Login" CausesValidation="True" 
        SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" 
            Text="Reset" CausesValidation="False" 
        SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin" />
            </td>
            <td>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkNewUser" runat="server" 
        onclick="lnkBtnNewUser_Click" CausesValidation="False" 
        CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
        
        SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin">New User?</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkForgotPassword" runat="server" 
            onclick="lnkBtnForgotPassword_Click" CausesValidation="False" 
        CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
        
        SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin">Forgot Password?</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />


<br />
        &nbsp;&nbsp;&nbsp;&nbsp;

        <br />
<br />
        &nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />

<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<p>
    &nbsp;</p>
<p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</p>
<p>
&nbsp;&nbsp;
</p>
<p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<p>
</p>
<p>
    <br />
</p>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowCommonMaster.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 163px;
        }
        .style4
        {
            width: 163px;
            height: 21px;
        }
        .style5
        {
            height: 21px;
        }
        .style6
        {
            height: 21px;
            width: 180px;
        }
        .style7
        {
            width: 180px;
        }
        .style8
        {
            height: 56px;
        }
        .style10
        {
            height: 56px;
        }
        .style11
        {
            height: 21px;
            width: 76px;
        }
        .style12
        {
            width: 76px;
        }
        .style13
        {
            height: 56px;
            width: 76px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p>
    </p>
    <p>
        <asp:Label ID="lblPasswordLine" runat="server" Text="Your password is " 
            Visible="False"></asp:Label>
        <asp:Label ID="lblPassword" runat="server" Text="Label" Visible="False" 
            Font-Bold="True" ForeColor="#003399"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnLogin" runat="server" onclick="lbtnLogin_Click" 
            Visible="False">Click here to Login</asp:LinkButton>
    </p>
    <p>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table class="style2">
            <tr>
                <td class="style4">
                    <asp:Label ID="lblUserId" runat="server" Text="Enter your User Id "></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtUserId" runat="server" Width="151px"></asp:TextBox>
                </td>
                <td class="style11">
                    <asp:Button ID="btnNext" runat="server" onclick="btnNext_Click" Text="Next" 
                        Width="64px" />
                </td>
                <td class="style5">
                    <asp:RequiredFieldValidator ID="rfvUserId" runat="server" 
                        ControlToValidate="txtUserId" ErrorMessage="User Id Mandatory"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="lblQuestion" runat="server" Text="Security question" 
                        Visible="False"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="lblQuesText" runat="server" Text="What is your pets name?" 
                        Visible="False"></asp:Label>
                </td>
                <td class="style12">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblAnswer" runat="server" Text=" Security answer" 
                        Visible="False"></asp:Label>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtAnswer" runat="server" Visible="False" Width="150px"></asp:TextBox>
                </td>
                <td class="style12">
                    &nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvAnswer" runat="server" 
                        ControlToValidate="txtAnswer" ErrorMessage="Enter Answer" Visible="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style8" colspan="2">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnRecoverPassword" runat="server" 
                        onclick="btnRecoverPassword_Click" Text="Recover Password" Visible="False" />
&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="False" 
                        onclick="btnCancel_Click" CausesValidation="False" />
                </td>
                <td class="style13">
                </td>
                <td class="style10">
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style12">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
&nbsp;&nbsp;&nbsp;
    </p>
    <p align="center">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnGotoLogin" runat="server" CausesValidation="False" 
            onclick="lbtnGotoLogin_Click">Back to LoginPage</asp:LinkButton>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>


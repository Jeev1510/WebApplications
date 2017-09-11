<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master" AutoEventWireup="true" CodeFile="SPLaunchModifyActivateDeavctivaetPostPaid.aspx.cs" Inherits="Launch_Modify_Activate_DeactivatePostPaidPlans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style5
        {
        }
        .style7
        {
            width: 245px;
        }
        .style8
        {
            width: 245px;
            height: 24px;
        }
        .style9
        {
            height: 24px;
        }
        .style10
        {
            width: 244px;
        }
        .style11
        {
        }
        .style12
        {
            width: 243px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p align="center">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblErrorMsg" runat="server" ForeColor="#FF3300" Text="ErrorLabel" 
            Visible="False"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnLaunch" runat="server" onclick="lbtnLaunch_Click" 
            CausesValidation="False">Launch</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnModify" runat="server" CausesValidation="False" 
            onclick="lbtnModify_Click">Modify</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnActivate" runat="server" CausesValidation="False" 
            onclick="lbtnActivate_Click">Activate</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnDeactivate" runat="server" CausesValidation="False" 
            onclick="lbtnDeactivate_Click">Deactivate</asp:LinkButton>
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
    </p>
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblStatePlan" runat="server" Text="Label"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlStatePlans" runat="server" 
            Height="23px" style="margin-left: 0px" Width="151px" 
            onselectedindexchanged="ddlStatePlans_SelectedIndexChanged" 
            AppendDataBoundItems="True">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvState" runat="server" 
            ControlToValidate="ddlStatePlans" ErrorMessage="Select State" 
            InitialValue="--Select--"></asp:RequiredFieldValidator>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="False" BorderStyle="Solid">
        <br />
        <table class="style2" border="1">
            <tr>
                <td class="style8">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblPlanName" runat="server" 
                Text="Plan Name"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="txtPlanName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPlanName" runat="server" 
                        ControlToValidate="txtPlanName" ErrorMessage="PlanName Mandatory"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSecurityAmt" runat="server" 
                Text="Security Amount"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSecurityAmt" runat="server" 
                style="margin-left: 0px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSecurityAmount" runat="server" 
                        ControlToValidate="txtSecurityAmt" ErrorMessage="Security Amount Mandatory"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvSecurityAmount" runat="server" 
                        ControlToValidate="txtSecurityAmt" 
                        ErrorMessage="Invalid Entry.Enter Only Integers" 
                        onservervalidate="cvSecurityAmount_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblProcessingFee" runat="server" 
                Text="Processing Fee"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProcessingFee" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvProcessingFee" runat="server" 
                        ControlToValidate="txtProcessingFee" ErrorMessage="Processing Fee Mandatory"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvProcessingFee" runat="server" 
                        ControlToValidate="txtProcessingFee" 
                        ErrorMessage="Invalid Entry.Enter Only Integers" 
                        onservervalidate="cvProcessingFee_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblServiceTax" runat="server" 
                Text="Service Tax"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtServiceTax" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvServiceTax" runat="server" 
                        ControlToValidate="txtServiceTax" ErrorMessage="Service Tax Mandatory"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvServiceTax" runat="server" 
                        ControlToValidate="txtServiceTax" 
                        ErrorMessage="Invalid Entry.Enter Only Integers" 
                        onservervalidate="cvServiceTax_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblCallrate" runat="server" 
                Text="Call Rate"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCallRate" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCallRate" runat="server" 
                        ControlToValidate="txtCallRate" ErrorMessage="Call Rate Mandatory"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSmsrate" runat="server" 
                Text="Sms Rate"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSmsRate" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSmsRate" runat="server" 
                        ControlToValidate="txtSmsRate" ErrorMessage="Sms Rate Mandatory"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style5" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="style5" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnLaunchModify" runat="server" 
                onclick="btnLaunchModify_Click" Text="Button" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" 
                Text="Cancel" onclick="btnCancel_Click" CausesValidation="False" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <p>
    </p>
    <asp:Panel ID="Panel3" runat="server" Visible="False">
        <table class="style2">
            <tr>
                <td class="style10">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblActivateDeactivate" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlActivateDeactivate" runat="server" 
                        AppendDataBoundItems="True" AutoPostBack="True" 
                        onselectedindexchanged="ddlActivateDeactivate_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <p>
    </p>
    <asp:Panel ID="Panel4" runat="server" Visible="False" BorderStyle="Solid">
        &nbsp;<table class="style2">
            <tr>
                <td class="style12">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblPlanName0" runat="server" Text="Plan Name"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPlanName2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSecurityAmt0" runat="server" Text="Security Amount"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSecurityAmt2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblProcessingFee0" runat="server" Text="Processing Fee"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblProcessingFee2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblServiceTax0" runat="server" Text="Service Tax"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblServiceTax2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblCallrate0" runat="server" Text="Call Rate"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCallRate2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSmsrate0" runat="server" Text="Sms Rate"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSmsRate2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnActivateDactivate" runat="server" 
                        onclick="btnActivateDactivate_Click" Text="Button" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <p>
    </p>
    <p align="center">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblSuccess" runat="server" Font-Size="Large" ForeColor="#33CC33" 
            Text="Label"></asp:Label>
    </p>
    <p>
    </p>
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
</asp:Content>


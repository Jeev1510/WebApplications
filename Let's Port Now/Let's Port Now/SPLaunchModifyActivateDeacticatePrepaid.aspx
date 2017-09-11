<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master" AutoEventWireup="true" CodeFile="SPLaunchModifyActivateDeacticatePrepaid.aspx.cs" Inherits="SPLaunchModifyActivateDeactivatePrepaid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
    {
        width: 100%;
            height: 59px;
        }
    .style3
    {
        width: 151px;
    }
    .style4
    {
        width: 151px;
        height: 21px;
    }
    .style5
    {
        height: 21px;
    }
    .style6
    {
        width: 174px;
    }
    .style7
    {
        width: 174px;
        height: 21px;
    }
        .style8
        {
            width: 151px;
            height: 24px;
        }
        .style9
        {
            width: 174px;
            height: 24px;
        }
        .style10
        {
            height: 24px;
        }
        .style17
        {
            width: 265px;
        }
        .style18
        {
            width: 202px;
        }
        .style19
        {
            width: 100%;
        }
        .style20
        {
            width: 154px;
        }
        .style21
        {
            width: 169px;
        }
        .style23
        {
        }
        .style24
        {
    }
        .style25
        {
            width: 267px;
        }
    .style26
    {
        width: 186px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p>
    <br />
    <asp:LinkButton ID="lbLaunch" runat="server" onclick="lbLaunch_Click" 
            CausesValidation="False">Launch</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="lbModify" runat="server" onclick="lbModify_Click" 
            CausesValidation="False">Modify</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton 
            ID="lbtnActivate" runat="server" 
            onclick="lbtnActivate_Click1" CausesValidation="False">Activate</asp:LinkButton>
        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="lbtnDeactivate" runat="server" onclick="lbtnDeactivate_Click" 
            CausesValidation="False">Deactivate</asp:LinkButton>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<asp:Panel ID="Panel1" runat="server" Height="105px" Visible="False" 
    BorderStyle="Solid">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <table class="style2" border="1">
        <tr>
            <td class="style17">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label 
                    ID="lblStatePlan" runat="server" 
                    Text="State"></asp:Label>
            </td>
            <td class="style18">
                <asp:DropDownList ID="ddlStatePlans" runat="server" 
                    onselectedindexchanged="ddlStatePlans_SelectedIndexChanged1" 
                    AppendDataBoundItems="True">
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style18">
                <asp:RequiredFieldValidator ID="rfvState" runat="server" 
                    ControlToValidate="ddlStatePlans" ErrorMessage="Select one value" 
                    InitialValue="--Select--"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style17">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td class="style18">
                &nbsp;</td>
            <td class="style18">
            </td>
            <td>
                &nbsp;&nbsp;</td>
        </tr>
    </table>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
</asp:Panel>
<p>
</p>
<p>
</p>
<asp:Panel ID="Panel2" runat="server" Height="293px" Visible="False" 
    BorderStyle="Solid">
    <br />
    <br />
    <table class="style2">
        <tr>
            <td class="style8">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblPlanName" runat="server" Text="Plan Name"></asp:Label>
            </td>
            <td class="style9">
                <asp:TextBox ID="txtPlanName" runat="server"></asp:TextBox>
            </td>
            <td class="style10">
                <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                    ControlToValidate="txtPlanName" ErrorMessage="Plan name is mandatory"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblPtype" runat="server" 
                    Text="Plan Type"></asp:Label>
            </td>
            <td class="style7">
                <asp:RadioButtonList ID="rblType" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True" 
                    onselectedindexchanged="rblType_SelectedIndexChanged">
                    <asp:ListItem>TopUp</asp:ListItem>
                    <asp:ListItem>Validity</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="style5">
                <asp:RequiredFieldValidator ID="rfvType" runat="server" 
                    ControlToValidate="rblType" ErrorMessage="Plan Type is mandatory"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblDur" runat="server" Text="Duration"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtDuration" runat="server" Enabled="False">0</asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDuration" 
                    ErrorMessage="Duration is mandatory" ID="rfvDuration"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RangeValidator 
                    ID="rvDuration" runat="server" ControlToValidate="txtDuration" 
                    ErrorMessage="should be between 0 and 365" MaximumValue="365" MinimumValue="0" 
                    Type="Integer"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblPfee" runat="server" 
                    Text="Processing Fee"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtProcessingFee" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvFee" runat="server" 
                    ControlToValidate="txtProcessingFee" 
                    ErrorMessage="Process fee is mandatory"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CompareValidator ID="cvFee" runat="server" ControlToValidate="txtProcessingFee" 
                    ErrorMessage="greater than 0" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                &nbsp;&nbsp;&nbsp;
                <asp:RegularExpressionValidator ID="revFee" runat="server" 
                    ControlToValidate="txtProcessingFee" ErrorMessage="ONLY DECIMAL VALUES ALLOW" 
                    ValidationExpression="\d+[.]\d+"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblStax" runat="server" 
                    Text="Service Tax"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtServiceTax" runat="server" 
                    ></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtServiceTax" ErrorMessage="Service Tax is mandatory"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;&nbsp;
                <asp:CompareValidator ID="cvTax" runat="server" ControlToValidate="txtServiceTax" 
                    ErrorMessage="greater than 0" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                &nbsp;&nbsp;
                <asp:RegularExpressionValidator ID="revTax" runat="server" 
                    ControlToValidate="txtServiceTax" ErrorMessage="ONLY DECIMAL VALUES ALLOW" 
                    ValidationExpression="\d+[.]\d+"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblCall" runat="server" 
                    Text="Call Rate"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtCallRate" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvCall" runat="server" 
                    ControlToValidate="txtCallRate" ErrorMessage="Call rate is mandatory"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblSms" runat="server" Text="Sms Rate"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtSmsRate" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvSms" runat="server" 
                    ControlToValidate="txtSmsRate" ErrorMessage="sms rate is mandatory"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnLaunchModify" runat="server" 
                    Text="Launch" onclick="btnLaunch_Click" />
            </td>
            <td class="style6">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                    onclick="btnCancel_Click" CausesValidation="False" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Panel>
<p>
</p>
    <p>
</p>
    <asp:Panel ID="Panel3" runat="server" Height="146px" Visible="False" 
    BorderStyle="Solid">
        <br />
        <table class="style19">
            <tr>
                <td class="style20">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblActivateDeactivate" runat="server" 
                        Text="Inactive Plans"></asp:Label>
                </td>
                <td class="style21">
                    <asp:DropDownList ID="ddlActivateDeactivate" runat="server" AppendDataBoundItems="True" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlActivateDeactivate_SelectedIndexChanged">
                        <asp:ListItem>--Select--</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style25">
                    &nbsp;</td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvInactiveplans" runat="server" 
                        ControlToValidate="ddlActivateDeactivate" ErrorMessage="Select one value" 
                        InitialValue="--Select--"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style20">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td class="style21">
                    &nbsp;</td>
                <td class="style25">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
    </asp:Panel>
<p>
</p>
<p>
</p>
    <asp:Panel ID="Panel4" runat="server" Visible="False" BorderStyle="Solid">
        <br />
        <table class="style19">
            <tr>
                <td class="style24" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="style26">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblPtypee" runat="server" Text="Plan Type"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPlanType" runat="server" Text="type"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style26">
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblDura" runat="server" Text="Duration"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDuration" runat="server" Text="DuartionValue"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style26">
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblProcess" runat="server" 
                        Text="Processing Fee"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblProcessingFee" runat="server" Text="Fee"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style26">
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblService" runat="server" 
                        Text="Service Tax"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTax" runat="server" Text="Tax"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style26">
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblCallR" runat="server" 
                        Text="Call Rate"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCRate" runat="server" Text="CRate"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style26">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSmsR" runat="server" 
                        Text="Sms Rate"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSRate" runat="server" Text="SRate"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style26">
                    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblS" runat="server" Text="State"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblStat" runat="server" Text="state"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style23" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button 
                        ID="btnActivateDactivate" runat="server" 
                        Text="Activate" onclick="btnActivateDeactivate_Click" />
                </td>
            </tr>
            <tr>
                <td class="style23" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>
<p>
</p>
<p>
    <asp:Label ID="lblStatus" runat="server" Text="Label" Visible="False"></asp:Label>
</p>
</asp:Content>


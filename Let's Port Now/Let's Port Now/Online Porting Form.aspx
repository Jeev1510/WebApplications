<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master" AutoEventWireup="true" CodeFile="Online Porting Form.aspx.cs" Inherits="Online_Portinf_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style2
    {
        width: 100%;
        height: 150px;
    }
    .style3
    {
        width: 199px;
    }
    .style4
    {
        width: 197px;
    }
    .style5
    {
        width: 197px;
        height: 24px;
    }
    .style6
    {
        height: 24px;
    }
    .style7
    {
        width: 197px;
        height: 72px;
    }
    .style8
    {
        height: 72px;
    }
    #TextArea1
    {
        height: 46px;
        width: 201px;
    }
    .style9
    {
        width: 221px;
    }
    .style10
    {
        height: 24px;
        width: 221px;
    }
    .style11
    {
        height: 72px;
        width: 221px;
    }
    .style12
    {
        width: 231px;
    }
    .style13
    {
        height: 24px;
        width: 231px;
    }
    .style14
    {
        height: 72px;
        width: 231px;
    }
    .style15
    {
        width: 76px;
    }
    .style16
    {
        height: 24px;
        width: 113px;
    }
    .style17
    {
        height: 72px;
        width: 113px;
    }
        .style18
        {
            width: 113px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p>
    <br />
    <table class="style2">
        <tr>
            <td class="style3">
                <asp:Label ID="lblCustId" runat="server" Text="CustomerId"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblCustName" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblName" runat="server" Text="CustomerName"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblAdd1" runat="server" Text="Address Line1"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblAddress1" runat="server" Text="Address1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblAdd2" runat="server" Text="Address Line2"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblAddress2" runat="server" Text="Address2"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblMobileNum" runat="server" Text="Mobile Number"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMobileNumber" runat="server" Text="Number"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblSPName" runat="server" Text="Service Provider"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblServiceProvider" runat="server" Text="provider"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblcPlan" runat="server" Text="Current Plan"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPlan" runat="server" Text="Plan"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="lblStat" runat="server" Text="State"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
            </td>
        </tr>
    </table>
</p>
<p>
</p>
<asp:Panel ID="Panel1" runat="server" Height="237px" BorderStyle="Solid">
    <br />
    <table class="style2">
        <tr>
            <td class="style4">
                <asp:Label ID="Label9" runat="server" Text="New ServiceProvider"></asp:Label>
            </td>
            <td class="style9">
                <asp:DropDownList ID="ddlServiceProvider" runat="server" AutoPostBack="True" 
                    DataSourceID="odsServiceproviderName" DataTextField="ServiceProviderName" 
                    DataValueField="ServiceProviderId" 
                    onselectedindexchanged="ddlServiceProvider_SelectedIndexChanged" 
                    AppendDataBoundItems="True">
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style12">
                <asp:ObjectDataSource ID="odsServiceproviderName" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetServiceProvider" 
                    TypeName="Common">
                </asp:ObjectDataSource>
                &nbsp;</td>
            <td class="style18">
                <asp:RequiredFieldValidator ID="rfvServiceprovider" runat="server" 
                    ControlToValidate="ddlServiceProvider" ErrorMessage="Select One value" 
                    InitialValue="--Select--"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:CompareValidator ID="cvNewServiceProvider" runat="server" ControlToValidate="ddlServiceProvider" 
                    ErrorMessage="Old and New service provider not equal" Operator="NotEqual"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label10" runat="server" Text="Plan Type"></asp:Label>
            </td>
            <td class="style9">
                <asp:RadioButtonList ID="rblPlanType" runat="server" 
                    RepeatDirection="Horizontal" AutoPostBack="True" 
                    onselectedindexchanged="rblPlanType_SelectedIndexChanged">
                    <asp:ListItem>Prepaid</asp:ListItem>
                    <asp:ListItem>Postpaid</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="style12">
                &nbsp;</td>
            <td class="style18">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label11" runat="server" Text="Available Plans"></asp:Label>
            </td>
            <td class="style9">
                <asp:DropDownList ID="ddlAvailablePlans" runat="server" AutoPostBack="True" 
                    AppendDataBoundItems="True" 
                 >
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style12">
                &nbsp;</td>
            <td class="style18">
                <asp:RequiredFieldValidator ID="rfvAvailablePlans" runat="server" 
                    ControlToValidate="ddlAvailablePlans" ErrorMessage="Select one value" 
                    InitialValue="--Select--"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label12" runat="server" Text="Unique Porting Code"></asp:Label>
            </td>
            <td class="style10">
                <asp:Label ID="lblUPC" runat="server" Text="UPC"></asp:Label>
            </td>
            <td class="style13">
                &nbsp;</td>
            <td class="style16">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                <asp:Label ID="Label13" runat="server" Text="Reason"></asp:Label>
            </td>
            <td class="style11">
                <asp:TextBox ID="txtReason" runat="server" Height="50px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="style14">
                &nbsp;</td>
            <td class="style17">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
</asp:Panel>
<p>
</p>
<p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" 
        onclick="btnSubmit_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
        onclick="btnCancel_Click" />
</p>
<p>
</p>
<p>
    <asp:Label ID="lblStatus" runat="server" Text="Label" Visible="False"></asp:Label>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
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


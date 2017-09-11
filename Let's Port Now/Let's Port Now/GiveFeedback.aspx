<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master" AutoEventWireup="true" CodeFile="GiveFeedback.aspx.cs" Inherits="GiveFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 63%;
        }
        .style3
        {
            width: 161px;
        }
        .style4
        {
            width: 98%;
        }
    .style5
    {
        width: 161px;
        height: 28px;
    }
    .style6
    {
        height: 28px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p align="center" 
        style="font-style: italic; font-size: large; font-family: 'Times New Roman', Times, serif; color: #800080">
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        GIVE FEEDBACK</p>
    <p align="center">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblFeedback" runat="server" Text="FeedBack"></asp:Label>
    </p>
    <table align="center" class="style2">
        <tr>
            <td align="center" class="style5">
                Service Provider</td>
            <td align="left" class="style6">
                <asp:DropDownList ID="ddlServicePro" runat="server" AppendDataBoundItems="True" 
                    AutoPostBack="True" DataSourceID="odsServiseProviders" 
                    DataTextField="ServiceProviderName" DataValueField="ServiceProviderId" 
                    onselectedindexchanged="ddlServicePro_SelectedIndexChanged">
                    <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvServiceProvider" runat="server" 
                    ErrorMessage="Service Provider is Mandatory" 
                    ControlToValidate="ddlServicePro" InitialValue="--Select--"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" class="style3">
                Comments</td>
            <td>
                <br />
                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" 
                    CausesValidation="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvComments" runat="server" 
                    ErrorMessage="Comments are Mandatory" ControlToValidate="txtComment"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:ObjectDataSource ID="odsServiseProviders" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetServiceProvider" 
                    TypeName="Common"></asp:ObjectDataSource>
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                    Text="Submit" />
            </td>
        </tr>
    </table>
    <p align="center">
        &nbsp;</p>
    <table align="center" class="style4">
        <tr>
            <td align="center">
                &nbsp;</td>
        </tr>
    </table>
    <p>
    </p>
    <p>
    </p>
</asp:Content>


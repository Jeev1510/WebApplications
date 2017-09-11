<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master" AutoEventWireup="true" CodeFile="CustomerViewPlan.aspx.cs" Theme="LetsPortNowTheme" Inherits="View_Plans_and_Offers_for_Customers_" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style2
    {
        width: 96%;
    }
    .style3
    {
        width: 220px;
    }
    .style4
    {
        width: 250px;
    }
    .style5
    {
        width: 219px;
    }
    .style6
    {
        width: 219px;
        height: 75px;
    }
    .style7
    {
        width: 238px;
        height: 75px;
    }
    .style8
    {
        height: 75px;
    }
    .style9
    {
        width: 100%;
    }
    .style10
    {
        width: 249px;
            height: 35px;
        }
    .style11
    {
        width: 219px;
        height: 24px;
    }
    .style12
    {
        width: 238px;
        height: 24px;
    }
    .style13
    {
        height: 24px;
    }
        .style14
        {
            width: 174px;
        }
        .style15
        {
            height: 75px;
            width: 174px;
        }
        .style16
        {
            height: 24px;
            width: 174px;
        }
        .style17
        {
            width: 145px;
            height: 35px;
        }
        .style18
        {
            width: 220px;
            height: 43px;
        }
        .style19
        {
            width: 249px;
            height: 43px;
        }
        .style20
        {
            width: 145px;
            height: 43px;
        }
        .style21
        {
            height: 43px;
        }
        .style22
        {
            width: 220px;
            height: 35px;
        }
        .style23
        {
            height: 35px;
        }
        .style24
        {
            width: 238px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p>
    <br />
</p>
<asp:Panel ID="Panel1" runat="server" BorderStyle="Solid">
    <table class="style2">
        <tr>
            <td class="style3">
                <asp:Label ID="lblSee" runat="server" Text="What would you like to see?"></asp:Label>
            </td>
            <td class="style4">
                <asp:RadioButtonList ID="rblIst" runat="server" RepeatDirection="Horizontal" 
                    AutoPostBack="True" onselectedindexchanged="rblIst_SelectedIndexChanged">
                    <asp:ListItem>Plans</asp:ListItem>
                    <asp:ListItem>Offers</asp:ListItem>
                </asp:RadioButtonList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvIst" runat="server" 
                    ControlToValidate="rblIst" ErrorMessage="Select One Value"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server" Height="158px" Visible="False" 
        BorderStyle="Solid">
        <table class="style2">
            <tr>
                <td class="style5">
                    <asp:Label ID="lblPlantype" runat="server" Text="Select PlanType"></asp:Label>
                </td>
                <td class="style24">
                    <asp:RadioButtonList ID="rblPlan" runat="server" RepeatDirection="Horizontal" 
                        onselectedindexchanged="rblPlan_SelectedIndexChanged">
                        <asp:ListItem>Prepaid</asp:ListItem>
                        <asp:ListItem>Postpaid</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style14">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="rblPlan" ErrorMessage="Select One Value"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                </td>
                <td class="style7">
                    <asp:DropDownList ID="ddlState" runat="server" AppendDataBoundItems="True" 
                        DataSourceID="odsStates" DataTextField="State" 
                        DataValueField="State" 
                        onselectedindexchanged="ddlState_SelectedIndexChanged">
                        <asp:ListItem>--Select--</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;</td>
                <td class="style15">
                    <asp:RequiredFieldValidator ID="rfvState" runat="server" 
                        ControlToValidate="ddlState" ErrorMessage="Select One Value" 
                        InitialValue="--Select--"></asp:RequiredFieldValidator>
                </td>
                <td class="style8">
                    <asp:ObjectDataSource ID="odsStates" runat="server" 
                        SelectMethod="GetStates" TypeName="Common"></asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="lblServiceProvider" runat="server" Text="Service Provider"></asp:Label>
                </td>
                <td class="style12">
                    <asp:DropDownList ID="ddlService" runat="server" AppendDataBoundItems="True" DataSourceID="odsServiceProvider" 
                        DataTextField="ServiceProviderName" DataValueField="ServiceProviderId" 
                        onselectedindexchanged="ddlService_SelectedIndexChanged">
                        <asp:ListItem>--Select--</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style16">
                    <asp:RequiredFieldValidator ID="rfvService" runat="server" 
                        ControlToValidate="ddlService" ErrorMessage="Select one value" 
                        InitialValue="--Select--"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style13">
                    <asp:ObjectDataSource ID="odsServiceProvider" runat="server" 
                        SelectMethod="GetServiceProvider" TypeName="Common"></asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel3" runat="server" Height="162px" Visible="False" 
        BorderStyle="Solid">
        <table class="style9">
            <tr>
                <td class="style22">
                    <asp:Label ID="Label5" runat="server" Text="State"></asp:Label>
                </td>
                <td class="style10">
                    <asp:DropDownList ID="ddlStat" runat="server" 
                        AppendDataBoundItems="True" DataSourceID="odsStat" 
                        DataTextField="State" DataValueField="State" 
                        onselectedindexchanged="ddlStat_SelectedIndexChanged">
                        <asp:ListItem>--Select--</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style17">
                    <asp:RequiredFieldValidator ID="rfvStat" runat="server" 
                        ControlToValidate="ddlStat" ErrorMessage="Select One Value" 
                        InitialValue="--Select--"></asp:RequiredFieldValidator>
                </td>
                <td class="style23">
                    <asp:ObjectDataSource ID="odsStat" runat="server" 
                        SelectMethod="GetStates" TypeName="Common"></asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td class="style18">
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Service Provider"></asp:Label>
                    <br />
                </td>
                <td class="style19">
                    <asp:DropDownList ID="dddlservicep" runat="server" AppendDataBoundItems="True" DataSourceID="odsSpName" 
                        DataTextField="ServiceProviderName" DataValueField="ServiceProviderId">
                        <asp:ListItem>--Select--</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style20">
                    <asp:RequiredFieldValidator ID="rfvServicepro" runat="server" 
                        ControlToValidate="dddlservicep" ErrorMessage="Select One Value" 
                        InitialValue="--Select--"></asp:RequiredFieldValidator>
                </td>
                <td class="style21">
                    <asp:ObjectDataSource ID="odsSpName" runat="server" 
                        SelectMethod="GetServiceProvider" TypeName="Common"></asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <br />
    <br />
</asp:Panel>
<p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;<asp:Button ID="btnView" runat="server" Text="View" 
        onclick="btnView_Click" />
</p>
<p>
    &nbsp;</p>
<p>
    <asp:GridView ID="gvPrepaid" runat="server" AutoGenerateColumns="False" 
        EnableModelValidation="True" DataSourceID="odsPrepaidplan" 
        Visible="False" SkinID="skGridView" EmptyDataText="No Records Found">
        <Columns>
            <asp:BoundField AccessibleHeaderText="ServiceProviderName" 
                DataField="ServiceProviderName" HeaderText="ServiceProviderName" />
            <asp:BoundField AccessibleHeaderText="PlanName" DataField="PlanName" 
                HeaderText="PlanName" />
            <asp:BoundField AccessibleHeaderText="PlanType" DataField="PlanType" 
                HeaderText="PlanType" />
            <asp:BoundField AccessibleHeaderText="Duration" DataField="Duration" 
                HeaderText="Duration" />
            <asp:BoundField AccessibleHeaderText="ProcessingFee" DataField="ProcessingFee" 
                HeaderText="ProcessingFee" />
            <asp:BoundField AccessibleHeaderText="ServiceTax" DataField="ServiceTax" 
                HeaderText="ServiceTax" />
            <asp:BoundField AccessibleHeaderText="CallRate" DataField="CallRate" 
                HeaderText="CallRate" />
            <asp:BoundField AccessibleHeaderText="SmsRate" DataField="SmsRate" 
                HeaderText="SmsRate" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsPrepaidplan" runat="server" 
        SelectMethod="GetPrepaidPlanDetails" TypeName="CustomerBL">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlService" Name="ServiceProviderId" 
                PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="ddlState" Name="state" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
&nbsp;</p>
<p>
</p>
<p>
</p>
    <asp:GridView ID="gvPostpaid" runat="server" AutoGenerateColumns="False" 
        EnableModelValidation="True" DataSourceID="odsPostpaidPlan" 
        Visible="False" SkinID="skGridView" EmptyDataText="No Records Found">
        <Columns>
            <asp:BoundField AccessibleHeaderText="ServiceProviderName" 
                DataField="ServiceProviderName" HeaderText="ServiceProviderName" />
            <asp:BoundField AccessibleHeaderText="PlanName" DataField="PlanName" 
                HeaderText="PlanName" />
            <asp:BoundField AccessibleHeaderText="ProcessingFee" DataField="ProcessingFee" 
                HeaderText="ProcessingFee" />
            <asp:BoundField AccessibleHeaderText="ServiceTax" DataField="ServiceTax" 
                HeaderText="ServiceTax" />
            <asp:BoundField AccessibleHeaderText="CallRate" DataField="CallRate" 
                HeaderText="CallRate" />
            <asp:BoundField AccessibleHeaderText="SmsRate" DataField="SmsRate" 
                HeaderText="SmsRate" />
        </Columns>
    </asp:GridView>
<p>
</p>
<p>
    <asp:ObjectDataSource ID="odsPostpaidPlan" runat="server" 
        SelectMethod="GetPostpaidPlanDetails" TypeName="CustomerBL" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlService" Name="ServiceProviderId" 
                PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="ddlState" Name="state" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</p>
<p>
</p>
<p>
    <asp:GridView ID="gvOffers" runat="server" AutoGenerateColumns="False" 
        DataSourceID="odsOffers" EnableModelValidation="True" 
        Visible="False" SkinID="skGridView" EmptyDataText="No Records Found">
        <Columns>
            <asp:BoundField AccessibleHeaderText="OfferName" DataField="OfferName" 
                HeaderText="OfferName" />
            <asp:BoundField AccessibleHeaderText="ServiceProviderName" 
                DataField="ServiceProviderName" HeaderText="ServiceProviderName" />
            <asp:BoundField AccessibleHeaderText="State" DataField="State" 
                HeaderText="State" />
            <asp:BoundField AccessibleHeaderText="Amount" DataField="Amount" 
                HeaderText="Amount" />
            <asp:BoundField AccessibleHeaderText="Duration" DataField="Duration" 
                HeaderText="Duration" />
            <asp:BoundField AccessibleHeaderText="Description" DataField="Description" 
                HeaderText="Description" />
        </Columns>
    </asp:GridView>
</p>
<p>
    <asp:ObjectDataSource ID="odsOffers" runat="server" 
        SelectMethod="GetOfferDetails" TypeName="CustomerBL" 
        OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlStat" Name="State" 
                PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="dddlservicep" Name="ServiceProviderId" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
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
</asp:Content>


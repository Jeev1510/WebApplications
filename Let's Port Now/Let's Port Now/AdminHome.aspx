<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="AdminHome" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Total number of Customers registered till today&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblNoOfCustomers" runat="server" Text="Label"></asp:Label>
</p>
<p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Total number of Service Providers registered till today&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblNoOfServiceProviders" runat="server" Text="Label"></asp:Label>
</p>
<p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Total number of Porting Requests raised so far&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblNoOfRequestsRaised" runat="server" Text="Label"></asp:Label>
</p>
<p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    Total number of Porting Requests served so far&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblNoOfRequestsServed" runat="server" Text="Label"></asp:Label>
</p>
<p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Number of pending Service Providers&#39; approval&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="lnkNoOfPendingApprovals" runat="server" 
        onclick="lnkBtnNoOfPendingApprovals_Click">LinkButton</asp:LinkButton>
</p>
    <p>
        &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    <asp:GridView runat="server" Caption="Pending Payments :" 
        DataSourceID="odsPendingPaymentsGV" EnableModelValidation="True" 
        EmptyDataText="No Data Available" Height="142px" 
        Width="723px" AutoGenerateColumns="False" 
        SkinID="skGridView" 
        
        CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
        ID="gvPendingDetails">
        <Columns>
            <asp:BoundField DataField="PortingId" HeaderText="Porting Id " />
            <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
            <asp:BoundField DataField="ServiceProviderName" HeaderText="Donor" />
            <asp:BoundField DataField="ServiceProviderName" HeaderText="Recipient" />
            <asp:BoundField DataField="PortStatus" HeaderText="Port Status" />
        </Columns>
    </asp:GridView>
    &nbsp;</p>
<p>
    <asp:ObjectDataSource ID="odsPendingPaymentsGV" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="PopulatingPendingPaymentsGridviewBL" TypeName="AdminBL">
    </asp:ObjectDataSource>
</p>
<p>
</p>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master" AutoEventWireup="true" Theme="LetsPortNowTheme" CodeFile="ViewFeedback.aspx.cs" Inherits="ViewFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p>
        <br />
    </p>
    <asp:GridView ID="gvFeedback" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" EnableModelValidation="True" 
        onpageindexchanging="Paging_event" onsorting="sorting_event" 
        SkinID="skGridView" Height="16px" 
    onselectedindexchanged="grvFeedback_SelectedIndexChanged" Width="384px">
        <Columns>
            <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" 
                SortExpression="CustomerName" />
            <asp:BoundField DataField="Comments" HeaderText="Feedback Comments" />
            <asp:BoundField DataField="FeedbackDate" DataFormatString="{0:dd-MMM-yyyy}" 
                HeaderText="Given On" SortExpression="FeedbackDate" />
        </Columns>
    </asp:GridView>
    <p>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>


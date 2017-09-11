<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master" AutoEventWireup="true" CodeFile="ApproveServiceProvider.aspx.cs" Inherits="ApproveServiceProvider_Admin_" Theme="LetsPortNowTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p>
        <br />
        Service Provider&#39;s approvals pending for you are:</p>
    <p>
    </p>
        <asp:GridView ID="gvServiceProvider" runat="server" 
        AutoGenerateColumns="False" EnableModelValidation="True" 
         
        onrowcommand="gvServiceProvider_RowCommand" 
        EmptyDataText="No Records Found" SkinID="skGridView" 
        >
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ServiceProviderName" 
                    HeaderText="ServiceProviderName" />
                <asp:BoundField DataField="ContactNumber" HeaderText="ContactNumber" />
                <asp:BoundField DataField="LicenseNumber" HeaderText="License Number" />
                <asp:BoundField DataField="RegDate" HeaderText="Registration Date" 
                    DataFormatString="{0:dd-MMM-yyyy}" />
                <asp:ButtonField ButtonType="Button" Text="Verify" CommandName="gv_btnVerify" />
            </Columns>
        </asp:GridView>
    <p>
        <asp:ObjectDataSource ID="odsServiceProvider" runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetServiceProviderToApprove" TypeName="AdminBL">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsServiceProvider2" runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetServiceProviderToApprove" TypeName="AdminBL">
        </asp:ObjectDataSource>
    </p>
    <p>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
    <p>
    </p>
    <p>
        &nbsp;&nbsp;
        <asp:Button ID="btnApprove" runat="server" Text="Approve" 
            CausesValidation="False" onclick="btnApprove_Click" />
        &nbsp;
        <asp:Button ID="btnReject" runat="server" Text="Reject" 
            CausesValidation="False" onclick="btnReject_Click" />
    </p>
    <p>
    </p>
    <p>
        &nbsp;</p>
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


<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master" AutoEventWireup="true" Theme="LetsPortNowTheme" CodeFile="CustomerHome.aspx.cs" Inherits="CustomerHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
        }
        .style7
        {
            height: 28px;
        }
        .style8
        {
            width: 198px;
            height: 28px;
        }
        .style9
        {
            width: 198px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p>
        &nbsp;</p>
    <p>
&nbsp;
        <asp:ScriptManager ID="scmUpdate" runat="server">
        </asp:ScriptManager>
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkUpdate" runat="server" 
            onclick="lnkUpdate_Click">Update My Profile</asp:LinkButton>
    </p>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <asp:UpdatePanel ID="upPanel" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlUpdate" runat="server">
                <table class="style2">
                    <tr>
                        <td class="style8">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Name&nbsp;&nbsp;&nbsp;
                        </td>
                        <td class="style7">
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                                ControlToValidate="txtName" ErrorMessage="Name is Mandatory"></asp:RequiredFieldValidator>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style9">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Address Line 1</td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtAddressLine1" runat="server" TextMode="MultiLine"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="rfvAddressLine1" runat="server" 
                                ControlToValidate="txtAddressLine1" ErrorMessage="AddressLine1 is Mandatory"></asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style9">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Address Line 2</td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtAddressLine2" runat="server" TextMode="MultiLine"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="rfvAddressLine2" runat="server" 
                                ControlToValidate="txtAddressLine2" ErrorMessage="AddressLine2 is Mandatory"></asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style8">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Zip Code</td>
                        <td class="style7">
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" 
                                ControlToValidate="txtZipCode" ErrorMessage="ZipCode is Mandatory"></asp:RequiredFieldValidator>
                            &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RegularExpressionValidator ID="revZipCode" runat="server" 
                                ControlToValidate="txtZipCode" 
                                ErrorMessage="ZipCode should contain only 6 digits" 
                                ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style3" colspan="2">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnUpdate" 
                                runat="server" onclick="btnUpdate_Click1" Text="Update" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" 
                                onclick="btnCancel_Click1" Text="Cancel" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                            <asp:Label ID="lblStatus" runat="server" Text="Label"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
    </p>
    <p>
        Your Current Service Provider is:&nbsp;&nbsp; 
        <asp:Label ID="lblCurrentService" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        Your Current plan is:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCurrentPlan" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:LinkButton ID="lnkWanttoPort" runat="server" onclick="lnkWanttoPort_Click">Want to Port?</asp:LinkButton>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
        Last porting done by you:   </p>
        <asp:GridView ID="gvLastPorting" runat="server" AutoGenerateColumns="False" 
            EnableModelValidation="True" DataSourceID="odsLastPorting" 
        DataKeyNames="PortingId" EmptyDataText="No Records Found" 
        SkinID="skGridView">
            <Columns>
                <asp:BoundField DataField="PortingId" HeaderText="Porting Id" />
                <asp:BoundField DataField="DonorServiceProvider" 
                    HeaderText="Donor Service Provider" />
                <asp:BoundField DataField="RecipientServiceProvider" 
                    HeaderText="Recipient Service Provider" />
                <asp:BoundField DataField="ApplicationDate" DataFormatString="{0:dd-MMM-yyyy}" 
                    HeaderText="Application Date" />
                <asp:BoundField DataField="ActivationDate" DataFormatString="{0:dd-MMM-yyyy}" 
                    HeaderText="Activation Date" />
            </Columns>
        </asp:GridView>
    <p>
    </p>
    <p>
        <asp:ObjectDataSource ID="odsLastPorting" runat="server" 
            OldValuesParameterFormatString="original_{0}" 
            SelectMethod="GetLastPortingDetails" TypeName="CustomerBL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="C0001" Name="CustomerId" 
                    SessionField="CustomerId" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <p>
        &nbsp;</p>
    <p>
        You have following pending payments:</p>
    <p>
        <asp:GridView ID="gvPending" runat="server" AutoGenerateColumns="False" 
            EnableModelValidation="True" DataKeyNames="PortingId" 
            DataSourceID="odsPendingPayments" EmptyDataText="No Records Found" 
            onrowcommand="grvPending_RowCommand" 
            onselectedindexchanged="grvPending_SelectedIndexChanged" 
            SkinID="skGridView">
            <Columns>
                <asp:BoundField DataField="PortingId" HeaderText="Porting Id" />
                <asp:BoundField DataField="UniquePortingCode" HeaderText="UPC" />
                <asp:BoundField DataField="DonorServiceProvider" 
                    HeaderText="Donor Service Provider" />
                <asp:BoundField DataField="RecipientServiceProvider" 
                    HeaderText="Recipient Service Provider" />
                <asp:BoundField DataField="ApplicationDate" DataFormatString="{0:dd-MMM-yyyy}" 
                    HeaderText="Application Date" />
                <asp:BoundField DataField="PlanName" HeaderText="Plan Name" />
                <asp:ButtonField CommandName="gv_MakePayment" HeaderText="Make Payment" 
                    Text="Make Payment" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
    </p>
    <p>
        <asp:ObjectDataSource ID="odsPendingPayments" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="PendingPayments" 
            TypeName="CustomerBL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="C0001" Name="customerId" 
                    SessionField="CustomerId" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>


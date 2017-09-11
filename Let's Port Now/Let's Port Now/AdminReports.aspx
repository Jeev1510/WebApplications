<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master" AutoEventWireup="true" CodeFile="AdminReports.aspx.cs" Inherits="ReportsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style23
    {
        width: 100%;
    }
    .style24
    {
        width: 232px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p>
        <asp:ScriptManager ID="scriptAdminReports" runat="server">
        </asp:ScriptManager>
        <br />
    </p>
    <asp:UpdatePanel ID="upnlAdminReports" runat="server">
        <ContentTemplate>
            <table class="style23">
                <tr>
                    <td class="style24">
                        From date</td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server" Height="22px" ReadOnly="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" 
                            ControlToValidate="txtFromDate" ErrorMessage="From Date is Mandatory"></asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnFromDate0" runat="server" CausesValidation="False" 
                            onclick="btnFromDate_Click" Text="&gt;&gt;" />
                    </td>
                    <td>
                        <asp:Calendar ID="CalFrom" runat="server" 
                            onselectionchanged="CalFrom_SelectionChanged"></asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td class="style24">
                        To date&nbsp;&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtToDate" runat="server" ReadOnly="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvToDate" runat="server" 
                            ControlToValidate="txtToDate" ErrorMessage="To Date is Mandatory"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnToDate0" runat="server" CausesValidation="False" 
                            onclick="btnToDate_Click" Text="&gt;&gt;" />
                    </td>
                    <td>
                        <asp:Calendar ID="CalTo" runat="server" 
                            onselectionchanged="CalTo_SelectionChanged"></asp:Calendar>
                        <asp:CustomValidator ID="cusVToDate0" runat="server" 
                            ControlToValidate="txtToDate" 
                            ErrorMessage="To Date should be greater than or equal to From Date " 
                            onservervalidate="cusVToDate_ServerValidate"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style24">
                        Filter By</td>
                    <td>
                        <asp:RadioButtonList ID="rblFilter" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="rblFilter_SelectedIndexChanged" Width="264px">
                            <asp:ListItem>Service Provider</asp:ListItem>
                            <asp:ListItem>Port Status</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvFilter" runat="server" 
                            ControlToValidate="rblFilter" ErrorMessage="Choose any one option"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style24">
                        <asp:Label ID="lblServiceProvider" runat="server" Text="Service Provider"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlServiceProvider" runat="server" 
                            AppendDataBoundItems="True" DataSourceID="odsServiceProvider" 
                            DataTextField="ServiceProviderName" DataValueField="ServiceProviderId" 
                            Height="19px" Width="105px" 
                            
                            style="margin-left: 10px">
                            <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<asp:RequiredFieldValidator ID="rfvServiceProvider" runat="server" 
                            ControlToValidate="ddlServiceProvider" 
                            ErrorMessage="Select atleast one option" InitialValue="--Select--"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:ObjectDataSource ID="odsServiceProvider" runat="server" 
                            OldValuesParameterFormatString="original_{0}" 
                            SelectMethod="GetServiceProviderById" TypeName="AdminBL">
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="style24">
                        <asp:Label ID="lblPortStatus" runat="server" Text="Port Status"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPortStatus" runat="server" Height="19px" 
                            style="margin-left: 3px" Width="116px" 
                            >
                            <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                            <asp:ListItem Value="S">Submitted</asp:ListItem>
                            <asp:ListItem Value="C">Cancelled by Customer</asp:ListItem>
                            <asp:ListItem Value="N">Rejected by Donor</asp:ListItem>
                            <asp:ListItem Value="F">Approved by Donor</asp:ListItem>
                            <asp:ListItem Value="R">Rejected by Recipient</asp:ListItem>
                            <asp:ListItem Value="A">Approved by Recipient</asp:ListItem>
                            <asp:ListItem Value="P">Payment done by Customer</asp:ListItem>
                            <asp:ListItem Value="X">Payment done by Recipient</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvPortStatus" runat="server" 
                            ControlToValidate="ddlPortStatus" ErrorMessage="Select atleast one option" 
                            InitialValue="--Select--"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style24">
                        &nbsp;</td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnGenerate" runat="server" onclick="btnGenerate_Click" 
                            Text="Generate" />
                        <br />
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="PortingId" EmptyDataText="No Records Found" 
                            EnableModelValidation="True" SkinID="skGridView" Visible="False">
                            <Columns>
                                <asp:BoundField DataField="PortingId" HeaderText="Porting Id" />
                                <asp:BoundField DataField="UniquePortingCode" 
                                    HeaderText="Unique Porting Code" />
                                <asp:BoundField DataField="Donor" HeaderText="Donor" />
                                <asp:BoundField DataField="Recipient" HeaderText="Recipient" />
                                <asp:BoundField DataField="ApplicationDate" DataFormatString="{0:dd-MMM-yyyy}" 
                                    HeaderText="Application Date" />
                                <asp:BoundField DataField="ActivationDate" DataFormatString="{0:dd-MMM-yyyy}" 
                                    HeaderText="Activation Date" />
                                <asp:BoundField DataField="PortStatus" HeaderText="Port Status" />
                            </Columns>
                            <EmptyDataRowStyle ForeColor="#6600CC" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="style24">
                        <asp:ObjectDataSource ID="odsServiceProviderGV" runat="server" 
                            OldValuesParameterFormatString="original_{0}" 
                            SelectMethod="GetServiceProviderDetails" TypeName="AdminBL">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtFromDate" Name="FromDate" 
                                    PropertyName="Text" Type="DateTime" />
                                <asp:ControlParameter ControlID="txtToDate" Name="ToDate" PropertyName="Text" 
                                    Type="DateTime" />
                                <asp:ControlParameter ControlID="ddlServiceProvider" Name="ServiceProviderId" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        <asp:ObjectDataSource ID="odsPortStatusGV" runat="server" 
                            OldValuesParameterFormatString="original_{0}" 
                            SelectMethod="GetPortStatusDetails" TypeName="AdminBL">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="txtFromDate" Name="fromDate" 
                                    PropertyName="Text" Type="DateTime" />
                                <asp:ControlParameter ControlID="txtToDate" Name="toDate" PropertyName="Text" 
                                    Type="DateTime" />
                                <asp:ControlParameter ControlID="ddlPortStatus" Name="portStatus" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
</asp:UpdatePanel>
    
        </asp:Content>


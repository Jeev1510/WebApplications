<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master" AutoEventWireup="true" CodeFile="PortingRequests.aspx.cs" Inherits="PortingRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 548px;
        }
        .style4
        {
            width: 564px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table align="center" class="style1">
                <tr>
                    <td class="style3">
                        <asp:GridView ID="gvDonorGridView" runat="server" AutoGenerateColumns="False" 
                            DataKeyNames="PortingId" DataSourceID="odsDonorGV" EnableModelValidation="True" 
                            onselectedindexchanged="gvDonorGridView_SelectedIndexChanged" 
                            
                            SkinID="skGridView" 
                            Caption="Request pending for Approval as Donor Service Provider:" Height="116px" 
                            Width="402px" 
                            CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
                            EmptyDataText="No Data Available">
                            <Columns>
                                <asp:BoundField DataField="PortingId" HeaderText="Request Number" />
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                                <asp:BoundField DataField="Reason" HeaderText="Reason" />
                                <asp:CommandField ButtonType="Button" SelectText="Show Details" 
                                    ShowSelectButton="True" />
                            </Columns>
                            <EmptyDataRowStyle ForeColor="#FF3300" />
                        </asp:GridView>
                        <asp:ObjectDataSource ID="odsDonorGV" runat="server" 
                            OldValuesParameterFormatString="original_{0}" 
                            SelectMethod="DonorServiceProviderGridViewBL" TypeName="ServiceProviderBL">
                        </asp:ObjectDataSource>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </td>
                    <td class="style4">
                        <asp:GridView ID="gvRecipientGridView" runat="server" 
                            AutoGenerateColumns="False" DataKeyNames="PortingId" 
                            DataSourceID="odsRecipientGV" EnableModelValidation="True" 
                            onselectedindexchanged="gvRecipientGridView_SelectedIndexChanged" 
                            
                            SkinID="skGridView" 
                            Caption="Request pending for approval as Recipient Service Provider:" Height="189px" 
                            Width="415px" 
                            CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
                            EmptyDataText="No Data Available">
                            <Columns>
                                <asp:BoundField DataField="PortingId" HeaderText="Request Number" />
                                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                                <asp:BoundField DataField="Reason" HeaderText="Reason" />
                                <asp:BoundField DataField="PlanName" HeaderText="Plan Name" />
                                <asp:CommandField ButtonType="Button" SelectText="Show Details" 
                                    ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="odsRecipientGV" runat="server" 
                            OldValuesParameterFormatString="original_{0}" 
                            SelectMethod="RecipientServiceProviderGridViewBL" 
                            TypeName="ServiceProviderBL">
                        </asp:ObjectDataSource>
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <asp:Panel ID="pnlPanel1" runat="server" BorderColor="Black" 
                            BorderStyle="Solid" BorderWidth="1px" Visible="False" 
                            CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
                            SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin">
                            <br />
                            <asp:DetailsView ID="dvDonorDetailsView" runat="server" 
                                AutoGenerateRows="False" DataKeyNames="PortingId" DataSourceID="odsDonorPanel" 
                                EnableModelValidation="True" Height="50px" Width="276px" 
                                CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
                                SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin">
                                <Fields>
                                    <asp:BoundField DataField="PortingId" HeaderText="Request Number" />
                                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                                    <asp:BoundField DataField="Reason" HeaderText="Reason" />
                                    <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" />
                                    <asp:BoundField DataField="UniquePortingCode" HeaderText="UPC" />
                                    <asp:BoundField DataField="PlanName" HeaderText="Plan Name" />
                                    <asp:BoundField DataField="MobileNumber" HeaderText="Mobile" />
                                </Fields>
                            </asp:DetailsView>
                            <asp:ObjectDataSource ID="odsDonorPanel" runat="server" 
                                OldValuesParameterFormatString="original_{0}" 
                                SelectMethod="DonorServiceProviderDetailsViewBL" 
                                TypeName="ServiceProviderBL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="gvDonorGridView" 
                                        DefaultValue="P0001" Name="portingId" 
                                        PropertyName="SelectedValue" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtDonorCommentText" runat="server" TextMode="MultiLine" 
                                CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
                                
                                SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin" 
                                ontextchanged="txtDonorCommentText_TextChanged"></asp:TextBox>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="rfvCommentsDonor" runat="server" 
                                ControlToValidate="txtDonorCommentText" ErrorMessage="Comments are Mandatory"></asp:RequiredFieldValidator>
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnApproveDonor" runat="server" onclick="btnAcceptDonor_Click" 
                                Text="Approve" 
                                CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
                                
                                SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin" 
                                CausesValidation="False" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRejectDonor" runat="server" onclick="btnRejectDonor_Click" 
                                Text="Reject" 
                                CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
                                SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin" />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblDonor" runat="server" Text="Label" Visible="False" 
                                CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
                                SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin"></asp:Label>
                            <br />
                            <br />
                        </asp:Panel>
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
                    </td>
                    <td class="style4">
                        <asp:Panel ID="pnlPanel2" runat="server" BorderColor="Black" 
                            BorderStyle="Solid" BorderWidth="1px" Visible="False" 
                            CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
                            SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin">
                            <br />
&nbsp;<asp:DetailsView ID="dvRecipientDetailsView" runat="server" AutoGenerateRows="False" 
                                DataKeyNames="PortingId" DataSourceID="odsRecipientPanel" 
                                EnableModelValidation="True" Height="50px" Width="277px" 
                                CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
                                SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin">
                                <Fields>
                                    <asp:BoundField DataField="PortingId" HeaderText="Request Number" />
                                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                                    <asp:BoundField DataField="Reason" HeaderText="Reason" />
                                    <asp:BoundField DataField="ApplicationDate" HeaderText="Application Date" />
                                    <asp:BoundField DataField="UniquePortingcode" HeaderText="UPC" />
                                    <asp:BoundField DataField="PlanName" HeaderText="Plan Name" />
                                    <asp:BoundField DataField="MobileNumber" HeaderText="Mobile" />
                                    <asp:BoundField DataField="AddressLine1" HeaderText="Address Line1" />
                                    <asp:BoundField DataField="AddressLine2" HeaderText="Address Line2" />
                                    <asp:BoundField DataField="State" HeaderText="State" />
                                    <asp:BoundField DataField="ZipCode" HeaderText="Zip" ReadOnly="True" />
                                </Fields>
                            </asp:DetailsView>
                            <asp:ObjectDataSource ID="odsRecipientPanel" runat="server" 
                                OldValuesParameterFormatString="original_{0}" 
                                SelectMethod="RecipientServiceProviderDetailsViewBL" 
                                TypeName="ServiceProviderBL">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="gvRecipientGridView" 
                                        DefaultValue="P0001" Name="portingId" 
                                        PropertyName="SelectedValue" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtRecipientCommentText" runat="server" TextMode="MultiLine" 
                                CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
                                
                                SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin" 
                                ontextchanged="txtRecipientCommandText_TextChanged"></asp:TextBox>
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="rfvCommentsRecipient" runat="server" 
                                ErrorMessage="Comments are mandatory" 
                                ControlToValidate="txtRecipientCommentText"></asp:RequiredFieldValidator>
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnApproveRecipient" runat="server" Text="Approve" 
                                onclick="btnAcceptRecipient_Click1" 
                                CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
                                
                                SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin" 
                                CausesValidation="False" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnRejectRecipient" runat="server" Text="Reject" onclick="btnRejectRecipient_Click1" 
                                CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
                                
                                SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:Label 
                                ID="lblRecipient" runat="server" Text="Label" Visible="False" 
                                CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
                                SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin"></asp:Label>
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnMakePayment" runat="server" Text="Make Payment" 
                                onclick="btnMakePayment_Click1" 
                                CssClass="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowStyleSheet.css" 
                                SkinID="http://localhost:57098/Let's Port Now/App_Themes/LetsPortNowTheme/LetsPortNowSkin.skin" />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
        <br />
    </p>
</asp:Content>


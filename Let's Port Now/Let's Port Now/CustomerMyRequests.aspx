<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master"  AutoEventWireup="true" CodeFile="CustomerMyRequests.aspx.cs" Inherits="MyRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 82%;
        }
        .style2
        {
            height: 21px;
        }
        .style4
        {
            height: 21px;
            width: 172px;
        }
        .style6
        {
            width: 172px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p>
        <br />
    </p>
        <asp:ScriptManager ID="smPorting" runat="server">
        </asp:ScriptManager>
    <p>
        <asp:Label ID="lblApplyRet" runat="server" Visible="False"></asp:Label>
    </p>
    <p>
        <asp:LinkButton ID="lbtnApply" runat="server" onclick="lbtnApply_Click" 
            Visible="False">Apply for porting</asp:LinkButton>
    </p>
    <p>
        &nbsp;</p>
    <p>
       <asp:LinkButton ID="lbtnUPC" runat="server" onclick="lbtnUPC_Click">Click here to generate UPC</asp:LinkButton>
    </p>
    <p>
    </p>
    <p>
        Your Previous porting requests are:</p>
    <p>
    </p>
        <asp:GridView ID="gvPorting" runat="server" AutoGenerateColumns="False" 
        DataSourceID="odsPorting" EnableModelValidation="True" 
            onrowcommand="GridView1_RowCommand" SkinID="skGridView" 
        DataKeyNames="PortingId" EmptyDataText="No Records Found" 
        onselectedindexchanged="gvPorting_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="PortingId">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" 
                            Commandname="<%# Bind('PortingId') %>" Text="<%# Bind('PortingId') %>"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DonorServiceProvider" 
                    HeaderText="Donor Service Provider" />
                <asp:BoundField DataField="RecipientServiceProvider" 
                    HeaderText="Recipient Service Provider" />
                <asp:BoundField DataField="PortStatus" HeaderText="Status" />
            </Columns>
        </asp:GridView>
    <p>
    </p>
    <p>
        <asp:ObjectDataSource ID="odsPorting" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetPortingDetails" 
            TypeName="CustomerBL">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="C0004" Name="CustomerId" 
                    SessionField="CustomerId" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <p>
    </p>
    <asp:UpdatePanel ID="upPorting" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlPorting" runat="server" Visible="False" Width="629px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblRet" runat="server" Text="Label" Visible="False"></asp:Label>
                &nbsp;<table class="style1">
                    <tr>
                        <td align="right" class="style6">
                            Porting ID</td>
                        <td align="left">
                            <asp:Label ID="lblPortingId" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style4">
                            Comments</td>
                        <td align="left" class="style2">
                            <asp:TextBox ID="txtComments" runat="server" style="margin-left: 4px" 
                                TextMode="MultiLine" Width="308px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style6">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:Button ID="btnMakePayment" runat="server" Text="Make Payment" 
                                CausesValidation="False" onclick="btnMakePayment_Click" Visible="False" />
                        </td>
                        <td align="left">
                            &nbsp;&nbsp;
                           <asp:Button ID="btnCancel" runat="server" Text="Cancel Request" 
                                CausesValidation="False" onclick="btnCancel_Click" Visible="False" />
                            &nbsp;<asp:Button ID="btnClose" runat="server" Text="Close" 
                                CausesValidation="False" onclick="btnClose_Click" Visible="False" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
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


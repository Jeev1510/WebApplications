<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master" Theme="LetsPortNowTheme" AutoEventWireup="true" CodeFile="SPViewPlansAndOffers.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 751px;
            height: 42px;
        }
        .style4
        {
            width: 257px;
        }
        .style6
        {
            width: 259px;
        }
        .style7
        {
            width: 385px;
        }
        .style9
        {
            width: 301px;
        }
        .style10
        {
            width: 294px;
        }
        .style14
        {
            width: 204px;
        }
        .style17
        {
            width: 437px;
        }
        .style18
        {
            width: 353px;
        }
        .style19
        {
            width: 351px;
        }
        .style20
        {
            width: 1214px;
        }
        .style21
        {
            width: 216px;
        }
        .style26
        {
            width: 253px;
        }
        .style27
        {
            width: 472px;
        }
        .style28
        {
            width: 295px;
        }
        .style29
        {
            width: 361px;
        }
        .style31
        {
            width: 358px;
        }
        .style32
        {
            width: 520px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
            <p>
    </p>
            <asp:Panel ID="Panel1" runat="server">
                <table class="style1">
                    <tr>
                        <td align="left" class="style20" valign="middle">
                            What would you like to 
                            See?&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                        <td class="style21" align="left">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButtonList ID="rblLikeToSee" runat="server" AutoPostBack="True" 
                                Height="46px" RepeatDirection="Horizontal" Width="405px">
                                <asp:ListItem>Plans</asp:ListItem>
                                <asp:ListItem>Offers</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvLiketoSee" runat="server" 
                                ControlToValidate="rblLikeToSee" ErrorMessage="Select Valid Option"></asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
    </asp:Panel>
            <p>
    </p>
    <p>
    </p>
    <asp:Panel ID="PlanPanel" runat="server" Height="308px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table class="style1">
                    <tr>
                        <td class="style17" align="left">
                            Select Plan Type&nbsp; 
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                        <td class="style4" align="left">
                            <asp:RadioButtonList ID="rblPlantype" runat="server" 
                        CellSpacing="10" Height="43px" RepeatDirection="Horizontal" Width="439px">
                                <asp:ListItem>Prepaid</asp:ListItem>
                                <asp:ListItem>Postpaid</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvPlantype" runat="server" ControlToValidate="rblPlantype" 
                        ErrorMessage="Select Valid Option"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table class="style1">
                    <tr>
                        <td align="left" class="style31">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Sort By&nbsp;:</td>
                        <td align="left" class="style6">
                            <asp:RadioButtonList ID="rblSort" runat="server" CellSpacing="15" 
                                RepeatDirection="Horizontal" Width="439px" Height="43px">
                                <asp:ListItem>Processing Fee</asp:ListItem>
                                <asp:ListItem>No Of Customers</asp:ListItem>
                                <asp:ListItem>None</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td align="center">
                            <asp:RequiredFieldValidator ID="rfvSortPlans" runat="server" 
                                ControlToValidate="rblSort" ErrorMessage="Select Valid Option"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <br />
                <table class="style1">
                    <tr>
                        <td align="left" class="style19">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Filter 
                            By:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                        <td align="left" class="style9">
                            &nbsp;&nbsp;&nbsp;
                            <asp:RadioButtonList ID="rblFilter" runat="server" AutoPostBack="True" 
                                CellSpacing="15" onselectedindexchanged="rblFilter_SelectedIndexChanged" 
                                RepeatDirection="Horizontal" Height="43px" Width="439px">
                                <asp:ListItem>State</asp:ListItem>
                                <asp:ListItem>Status</asp:ListItem>
                                <asp:ListItem>None</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td align="center">
                            <asp:RequiredFieldValidator ID="rfvFilterbyplanpanel" runat="server" 
                                ControlToValidate="rblFilter" ErrorMessage="Select Valid Option"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <table class="style1">
                    <tr>
                        <td align="left" class="style32">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblStatePlans" runat="server" Text="State"></asp:Label>
                            &nbsp;</td>
                        <td align="left" class="style27">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlStates" runat="server" AppendDataBoundItems="True" 
                                DataSourceID="odsStates" DataTextField="State" DataValueField="State" 
                                Visible="False" Width="110px">
                                <asp:ListItem>--Select--</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </td>
                        <td align="center" class="style26">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="rfvStatePlans" runat="server" 
                                ControlToValidate="ddlStates" ErrorMessage="Select Valid Option" 
                                InitialValue="--Select--"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:ObjectDataSource ID="odsStates" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetStates" 
                                TypeName="Common"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style32">
                            <asp:Label ID="lblStatusPlans" runat="server" Text="Status"></asp:Label>
                        </td>
                        <td align="left" class="style27">
                            <br />
                            <asp:DropDownList ID="ddlStatus" runat="server" AppendDataBoundItems="True" 
                                Visible="False" Width="107px">
                                <asp:ListItem>--Select--</asp:ListItem>
                                <asp:ListItem Value="A">Active</asp:ListItem>
                                <asp:ListItem Value="I">InActive</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </td>
                        <td align="center" class="style26">
                            <asp:RequiredFieldValidator ID="rfvStatusPlans" runat="server" 
                                ControlToValidate="ddlStatus" ErrorMessage="Select Valid Option" 
                                InitialValue="--Select--"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
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
        <br />
        <br />
    </asp:Panel>
    <p>
        &nbsp;&nbsp;&nbsp;</p>
    <p>
    </p>
    <asp:Panel ID="OffersPanel" runat="server" Height="158px">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <table class="style1">
                    <tr>
                        <td align="left" class="style18">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Filter 
                            By:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                        <td align="left" class="style10">
                            <asp:RadioButtonList ID="rblFilterOffers" runat="server" AutoPostBack="True" 
                                CellSpacing="10" onselectedindexchanged="rblFilterOffers_SelectedIndexChanged" 
                                RepeatDirection="Horizontal" Width="439px">
                                <asp:ListItem>State</asp:ListItem>
                                <asp:ListItem>Status</asp:ListItem>
                                <asp:ListItem>None</asp:ListItem>
                            </asp:RadioButtonList>
                            &nbsp;
                        </td>
                        <td align="center">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="rfvFilterOffers" runat="server" 
                                ControlToValidate="rblFilterOffers" ErrorMessage="Select Valid Option"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <table class="style1">
                    <tr>
                        <td align="left" class="style7">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblStateOffers" runat="server" Text="State" Visible="False"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td align="left" class="style14">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlStatesOffers" runat="server" 
                                AppendDataBoundItems="True" DataSourceID="odsStateOffers" DataTextField="State" 
                                DataValueField="State" Visible="False" Height="16px" Width="109px">
                                <asp:ListItem>--Select--</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </td>
                        <td class="style28">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ObjectDataSource ID="odsStateOffers" runat="server" 
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetStates" 
                                TypeName="Common"></asp:ObjectDataSource>
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="rfvStatesOffers" runat="server" 
                                ControlToValidate="ddlStatesOffers" ErrorMessage="Select Valid Option"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="style7">
                            <asp:Label ID="lblStatusOffers" runat="server" Text="Status" Visible="False"></asp:Label>
                        </td>
                        <td align="left" class="style14">
                            <br />
                            &nbsp;
                            <asp:DropDownList ID="ddlStatusOffers" runat="server" Visible="False" 
                                Width="123px">
                                <asp:ListItem>--Select--</asp:ListItem>
                                <asp:ListItem Value="A">Active</asp:ListItem>
                                <asp:ListItem Value="I">InActive</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="center" class="style28">
                            <asp:RequiredFieldValidator ID="rvfStatusOffers" runat="server" 
                                ControlToValidate="ddlStatusOffers" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <br />
        <br />
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <asp:Panel ID="Panel2" runat="server" Width="897px">
        <table class="style1">
            <tr>
                <td align="right" class="style29">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:GridView ID="grdviewData" runat="server" EmptyDataText="No Record Found" 
                        SkinID="skGridView">
                    </asp:GridView>
                    <br />
                </td>
            </tr>
            <tr>
                <td align="left" class="style29">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnViewRecords" runat="server" onclick="btnViewRecords_Click" 
                        Text="View" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>


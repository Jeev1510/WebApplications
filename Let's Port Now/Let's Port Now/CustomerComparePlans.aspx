<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master" AutoEventWireup="true" CodeFile="CustomerComparePlans.aspx.cs" Inherits="ComparePlans" Theme="LetsPortNowTheme"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 377px;
        }
        .style3
        {
        }
        .style6
        {
        }
        .style8
        {
        }
        .style9
        {
            height: 28px;
        }
    .style12
    {
        width: 275px;
        height: 21px;
    }
    .style13
    {
        height: 21px;
    }
        .style16
        {
            width: 275px;
        }
    .style18
    {
        text-align: right;
        width: 275px;
    }
        .style20
        {
            text-align: center;
            height: 25px;
        }
        .style21
        {
            text-align: left;
            height: 25px;
        }
        .style22
        {
            width: 353px;
            height: 33px;
        }
        .style27
        {
            width: 167px;
        }
    .style29
    {
        width: 382px;
    }
    .style31
    {
        text-align: center;
        width: 382px;
    }
    .style32
    {
        text-align: right;
        width: 382px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                                    <asp:Panel ID="pnlPlanType" runat="server" Visible="False">
                                        <table class="style1">
                                            <tr>
                                                <td class="style12">
                                                    <asp:Label ID="lblErrorMessage" runat="server" Text="ErrorMessage" 
                                                        Visible="False"></asp:Label>
                                                </td>
                                                <td class="style13">
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td class="style18">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style20">
                                                    <asp:Label ID="lblPlanType" runat="server" 
                                                        Text="Which plans would you like to compare?" Width="300px"></asp:Label>
                                                </td>
                                                <td class="style21">
                                                    <asp:RadioButtonList ID="rblPlanType" runat="server" AutoPostBack="True" 
                                                        onselectedindexchanged="rblPlanType_SelectedIndexChanged" 
                                                        RepeatDirection="Horizontal">
                                                        <asp:ListItem>Prepaid</asp:ListItem>
                                                        <asp:ListItem>Postpaid</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style16">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="style3" colspan="2">
                                                    <asp:Panel ID="pnlChkServiceProviders" runat="server" Visible="False" 
                                                        Width="967px">
                                                        <table class="style1">
                                                            <tr>
                                                                <td class="center">
                                                                    &nbsp;&nbsp;&nbsp;
                                                                    <asp:Label ID="lblSelectServiceProviders" runat="server" 
                                                                        Text="Select any two service providers" Width="300px"></asp:Label>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                    &nbsp;&nbsp;
                                                                </td>
                                                                <td class="left">
                                                                    <asp:CheckBoxList ID="chkListServiceProviders" runat="server" 
                                                                        DataSourceID="ObjectDataSource1" DataTextField="ServiceProviderName" 
                                                                        DataValueField="ServiceProviderId">
                                                                    </asp:CheckBoxList>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <br />
                                                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                                                        OldValuesParameterFormatString="original_{0}" 
                                                                        SelectMethod="GetServiceProviderList" TypeName="CustomerBL">
                                                                        <SelectParameters>
                                                                            <asp:ControlParameter ControlID="rblPlanType" DefaultValue="" Name="planType" 
                                                                                PropertyName="SelectedValue" Type="String" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" class="style9" colspan="2">
                                                                    <asp:Button ID="btnNext" runat="server" onclick="btnNext_Click" Text="Next" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" class="style9" colspan="2">
                                                                    <asp:Label ID="lblInvalidSelects" runat="server" Text="lblInvalidSelect" 
                                                                        Visible="False"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style6" colspan="2">
                                                                    &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                        <asp:Panel ID="pnlPlans" runat="server" GroupingText="Plans" Visible="False" 
                                                            Width="940px">
                                                            <table class="style22">
                                                                <tr>
                                                                    <td align="center" class="style32">
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Label ID="lblPlan1" runat="server" Text="Plan1"></asp:Label>
                                                                        &nbsp;&nbsp;&nbsp;
                                                                        <asp:DropDownList ID="ddlPlan1" runat="server" AppendDataBoundItems="True" 
                                                                            onselectedindexchanged="ddlPlan1_SelectedIndexChanged" 
                                                                            ToolTip="Select a plan to compare">
                                                                        </asp:DropDownList>
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <br />
                                                                    </td>
                                                                    <td class="center" valign="middle">
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Label ID="lblPlan2" runat="server" Text="Plan2"></asp:Label>
                                                                        &nbsp;&nbsp;&nbsp;
                                                                        <asp:DropDownList ID="ddlPlan2" runat="server" AppendDataBoundItems="True" 
                                                                            ToolTip="Select a plan to compare to">
                                                                        </asp:DropDownList>
                                                                        <br />
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" class="style31">
                                                                        <asp:RequiredFieldValidator ID="rfvddlPlan1" runat="server" 
                                                                            ControlToValidate="ddlPlan1" ErrorMessage="Select Plan1 to compare" 
                                                                            InitialValue="--Select--"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td class="center">
                                                                        <asp:RequiredFieldValidator ID="rfvddlPlan2" runat="server" 
                                                                            ControlToValidate="ddlPlan2" ErrorMessage="Select Plan 2 to compare" 
                                                                            InitialValue="--Select--"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="clear" colspan="2">
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:Button ID="btnCompare" runat="server" onclick="btnCompare_Click" 
                                                                            style="height: 26px" Text="Compare" 
                                                                            ToolTip="Click here to compare the two plans" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style8" colspan="2">
                                                                        <asp:GridView ID="gvComparePlans" runat="server" 
                                                                            DataSourceID="ObjectDataSource4" EmptyDataText="No Data Found" 
                                                                            EnableModelValidation="True" SkinID="skGridView" 
                                                                            Visible="False">
                                                                        </asp:GridView>
                                                                        <br />
                                                                        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" 
                                                                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetComparisonGrid" 
                                                                            TypeName="CustomerBL">
                                                                            <SelectParameters>
                                                                                <asp:ControlParameter ControlID="rblPlanType" Name="planType" 
                                                                                    PropertyName="SelectedValue" Type="String" />
                                                                                <asp:ControlParameter ControlID="ddlPlan1" Name="planId1" 
                                                                                    PropertyName="SelectedValue" Type="String" />
                                                                                <asp:ControlParameter ControlID="ddlPlan2" Name="planId2" 
                                                                                    PropertyName="SelectedValue" Type="String" />
                                                                            </SelectParameters>
                                                                        </asp:ObjectDataSource>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style29">
                                                                        &nbsp;</td>
                                                                    <td class="style27">
                                                                        &nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="updatePnl" runat="server">
                    <ContentTemplate>
                        <table class="style1">
                            <tr>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td title="abc">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>


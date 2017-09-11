<%@ Page Title="" Language="C#" Theme="LetsPortNowTheme" MasterPageFile="~/LetsPortNowMaster.master" AutoEventWireup="true" CodeFile="SPReports.aspx.cs" Inherits="Reports_for_Service_Providers_" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 236%;
        }
        .style3
        {
            width: 384px;
        }
        .style5
        {
            width: 154px;
        }
        .style7
        {
            width: 190px;
        }
        .style10
        {
            width: 229px;
        }
        .style11
        {
            width: 34px;
        }
        .style13
        {
            width: 361%;
        }
        .style15
        {
            width: 380px;
        }
        .style16
        {
            width: 232px;
        }
        .style17
        {
            width: 2317px;
        }
        .style18
        {
            width: 539px;
        }
        .style19
        {
            width: 100%;
        }
        .style20
        {
            width: 1033px;
        }
        .style21
        {
            width: 379px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p align="center">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblerrorMsg" runat="server" ForeColor="#FF3300" Text="ErrorLabel" 
            Visible="False"></asp:Label>
    </p>
    <p>
        Your Top Five Plans<asp:GridView ID="GridView1" runat="server" 
            DataSourceID="ObjectDataSource1" EnableModelValidation="True" 
            SkinID="skGridView" EmptyDataText="No Records Found">
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetTopFivePlans" 
            TypeName="ServiceProviderBL">
            <SelectParameters>
                <asp:SessionParameter Name="spID" SessionField="ServiceProviderId" 
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        &nbsp;
    </p>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <table class="style2">
                <tr>
                    <td class="style3" valign="top" bgcolor="White">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" 
                            Text="Which report you would like to see?        "></asp:Label>
                    </td>
                    <td bgcolor="White">
                        <asp:RadioButtonList ID="rblDonorRecipient" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                            RepeatDirection="Horizontal">
                            <asp:ListItem>As a Donor</asp:ListItem>
                            <asp:ListItem>As a Recipient</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="rfvRadiobuttonList" runat="server" 
                            ControlToValidate="rblDonorRecipient" ErrorMessage="Select Atleast One Option"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
<br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table class="style2">
                        <tr>
                            <td class="style21" valign="top" bgcolor="White">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; From date</td>
                            <td class="style10" valign="top" bgcolor="White">
                                <asp:TextBox ID="txtFromDate" runat="server" ReadOnly="True" Width="166px"></asp:TextBox>
                                <asp:Button ID="btnFromdate0" runat="server" CausesValidation="False" 
                                    onclick="btnFromdate_Click" Text="&gt;&gt;" Width="30px" />
                                <br />
                                <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" 
                                    ControlToValidate="txtFromDate" ErrorMessage="Enter From Date"></asp:RequiredFieldValidator>
                            </td>
                            <td bgcolor="White" class="style20">
                                <asp:Calendar ID="calFromDate" runat="server" 
                                    onselectionchanged="calFromDate_SelectionChanged" Visible="False" 
                                    Width="68px" Height="140px">
                                </asp:Calendar>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table class="style13">
                                <tr>
                                    <td class="style15" valign="top" bgcolor="White">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; To date</td>
                                    <td class="style16" valign="top" bgcolor="White">
                                        &nbsp;<asp:TextBox ID="txtToDate" runat="server" ReadOnly="True" 
                                            style="margin-left: 0px" Width="166px"></asp:TextBox>
                                        <asp:Button ID="btnTodate" runat="server" CausesValidation="False" 
                                            onclick="btnTodate_Click" Text="&gt;&gt;" Width="29px" />
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfvTodate" runat="server" 
                                            ControlToValidate="txtToDate" ErrorMessage="Enter To Date"></asp:RequiredFieldValidator>
                                        &nbsp;<asp:CustomValidator ID="CustomValidator1" runat="server" 
                                            ControlToValidate="txtToDate" 
                                            ErrorMessage="To-Date must be greater than From-Date" 
                                            onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
                                        <br />
                                    </td>
                                    <td class="style17" bgcolor="White">
                                        <asp:Calendar ID="calTodate" runat="server" 
                                            onselectionchanged="calTodate_SelectionChanged" Visible="False" 
                                            Height="139px" Width="70px">
                                        </asp:Calendar>
                                    </td>
                                    <td class="style18">
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblPortStatus" runat="server" Text="Port Status" Visible="False"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlpStatus" runat="server" Height="23px" 
                                onselectedindexchanged="ddlpStatus_SelectedIndexChanged" Visible="False" 
                                Width="195px">
                                <asp:ListItem>--Select--</asp:ListItem>
                                <asp:ListItem Value="F">Forwarded</asp:ListItem>
                                <asp:ListItem Value="R">Rejected</asp:ListItem>
                                <asp:ListItem Value="A">Approved</asp:ListItem>
                                <asp:ListItem Value="P">Payment done by Customer</asp:ListItem>
                                <asp:ListItem Value="X">Successful</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvStatus" runat="server" 
                                ControlToValidate="ddlpStatus" ErrorMessage="Select Status" 
                                InitialValue="--Select--" Visible="False"></asp:RequiredFieldValidator>
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnGenerate" runat="server" onclick="btnGenerate_Click" 
                        Text="Generate" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <table class="style19">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="center">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:GridView ID="dgvGenerated" runat="server" EmptyDataText="No Record Found" 
                            EnableModelValidation="True" SkinID="skGridView">
                        </asp:GridView>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <br />
            <br />

            <br />
            <br />
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <asp:Panel ID="Panel1" runat="server">
        <table class="style2">
            <tr>
                <td class="style5">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style11">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;</p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p>
    </p>
</asp:Content>


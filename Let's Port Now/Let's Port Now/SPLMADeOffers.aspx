<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master" AutoEventWireup="true" CodeFile="SPLMADeOffers.aspx.cs" Inherits="LMADOffers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 103%;
            height: 858px;
        margin-top: 53px;
    }
        .style4
        {
            width: 423px;
            height: 447px;
        }
        .style5
        {
            width: 96%;
            height: 350px;
        }
        .style8
        {
            width: 567px;
            height: 447px;
        }
        .style10
        {
            width: 96%;
            height: 410px;
        }
        .style15
    {
        width: 43%;
    }
    .style17
    {
        width: 246px;
    }
    .style18
    {
        width: 278px;
    }
        .style26
        {
            width: 44%;
        }
        .style27
        {
        }
        .style28
        {
            width: 224px;
        }
        .style33
        {
            width: 149px;
            height: 62px;
        }
        .style34
        {
            width: 417px;
            height: 62px;
        }
        .style42
        {
            width: 179px;
            height: 43px;
        }
        .style43
        {
            height: 43px;
            width: 365px;
        }
        .style44
        {
            width: 365px;
        }
        .style45
        {
            width: 179px;
            height: 50px;
        }
        .style46
        {
            width: 365px;
            height: 50px;
        }
        .style47
        {
            width: 179px;
            height: 46px;
        }
        .style48
        {
            width: 365px;
            height: 46px;
        }
    .style49
    {
        height: 118px;
    }
    .style51
    {
        width: 179px;
    }
    .style56
    {
        width: 149px;
    }
    .style57
    {
        width: 149px;
        height: 39px;
    }
    .style58
    {
        width: 417px;
    }
    .style59
    {
        width: 417px;
        height: 39px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <asp:Panel ID="pnlFirst" runat="server" Width="1044px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnLaunch" runat="server" onclick="lbtnLaunch_Click1" 
            CausesValidation="False">Launch</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
        <asp:LinkButton ID="lbtnModify" runat="server" onclick="lbtnModify_Click1" 
            CausesValidation="False">Modify</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:LinkButton ID="lbtnActivate" runat="server" onclick="lbtnActivate_Click1" 
            CausesValidation="False">Activate</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lbtnDeactivate" runat="server" 
            onclick="lbtnDeactivate_Click" CausesValidation="False">Deactivate</asp:LinkButton>
        <br />
    </asp:Panel>
<p>
    <asp:ScriptManager ID="smPanel" runat="server">
    </asp:ScriptManager>
</p>
    <asp:Panel ID="pnlLaunchModify" runat="server" Height="696px">
        <table class="style2" id="tblLaunchMod" frame="border">
            <tr>
                <td class="style4">
                    <asp:UpdatePanel ID="upLaunch" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="pnlLaunch" runat="server" Visible="False" Width="479px" 
                                BorderWidth="1px">
                                <table class="style5">
                                    <tr>
                                        <td align="right" class="style42">
                                            <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                                            &nbsp;
                                        </td>
                                        <td class="style43">
                                            <asp:DropDownList ID="ddlState" runat="server" AppendDataBoundItems="True" 
                                            AutoPostBack="True" DataSourceID="odsState" DataTextField="State" 
                                            DataValueField="State">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvState" runat="server" 
                                                ControlToValidate="ddlState" ErrorMessage="State is mandatory" 
                                                InitialValue="--Select--"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style51">
                                            <asp:Label ID="lblOfferName" runat="server" Text="OfferName"></asp:Label>
                                        </td>
                                        <td class="style44">
                                            <asp:TextBox ID="txtOfferName" runat="server" Width="127px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvOfferName" runat="server" 
                                            ControlToValidate="txtOfferName" ErrorMessage="OfferName is mandatory"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style51">
                                            <asp:Label ID="lblAmount" runat="server" Text="Amount"></asp:Label>
                                        </td>
                                        <td class="style44">
                                            <asp:CompareValidator ID="cvAmount" runat="server" 
                                            ControlToValidate="txtAmount" 
                                            ErrorMessage="Amount should be greater than zero." Operator="GreaterThan" 
                                            Type="Double" ValueToCompare="0.00"></asp:CompareValidator>
                                            <br />
                                            <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvAmount" runat="server" 
                                            ControlToValidate="txtAmount" ErrorMessage="Amount is mandatory"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="revAmount" runat="server" 
                                            ControlToValidate="txtAmount" 
                                            ErrorMessage="Amount should be a decimal(Eg: 50.00)" 
                                            ValidationExpression="^\d+\.\d{2}?$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style51">
                                            <asp:Label ID="lblDuration" runat="server" Text="Duration"></asp:Label>
                                        </td>
                                        <td class="style44">
                                            <asp:TextBox ID="txtDuration" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvDuration" runat="server" 
                                            ControlToValidate="txtDuration" ErrorMessage="Duration is mandatory"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RangeValidator ID="rvDuration" runat="server" 
                                            ControlToValidate="txtDuration" 
                                            ErrorMessage="Duration should be between 30 and 365" MaximumValue="365" 
                                            MinimumValue="30" Type="Integer"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style45">
                                            <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                                        </td>
                                        <td class="style46">
                                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" 
                                            Width="142px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="Description" runat="server" 
                                            ControlToValidate="txtDescription" ErrorMessage="Description is mandatory"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style47" align="right">
                                            <asp:Button 
                                            ID="btnLaunch" runat="server" Height="29px" 
                                            onclick="btnLaunch_Click" Text="Launch" style="margin-top: 2px" Width="88px" />
                                            <br />
                                        </td>
                                        <td class="style48">
                                            
                                            <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                                            Text="Cancel" CausesValidation="False" Height="29px" Width="89px" />
                                            <asp:Label ID="lblReturn" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                            <asp:ObjectDataSource ID="odsState" runat="server" SelectMethod="GetStates" 
                            TypeName="Common" OldValuesParameterFormatString="original_{0}">
                            </asp:ObjectDataSource>
                            
                            
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
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
                <td class="style8">
                    <asp:UpdatePanel ID="upModify" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="pnlModify" runat="server" Visible="False" BorderWidth="1px" 
                                Width="452px">
                                <table class="style10">
                                    <tr>
                                        <td class="style56" align="right">
                                            <asp:Label ID="lblOldOfferName" runat="server" Text="Offer Name"></asp:Label>
                                        </td>
                                        <td class="style58">
                                            <asp:DropDownList ID="ddlOffer" runat="server" AppendDataBoundItems="True" 
                                            AutoPostBack="True" DataSourceID="odsOffer" DataTextField="OfferName" 
                                            DataValueField="OfferId" 
                                            onselectedindexchanged="ddlOffer_SelectedIndexChanged">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvOffer" runat="server" 
                                                ControlToValidate="ddlOffer" ErrorMessage="Offer Name is mandatory" 
                                                InitialValue="--Select--"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style33" align="right">
                                            <asp:Label ID="lblNewOfferName" runat="server" Text="New Offer Name"></asp:Label>
                                        </td>
                                        <td class="style34" align="left">
                                            <asp:TextBox ID="txtModOfferName" runat="server"></asp:TextBox>
                                            &nbsp;<asp:RequiredFieldValidator ID="rfvNewOfferName" runat="server" 
                                            ControlToValidate="txtModOfferName" 
                                            ErrorMessage="New OfferName is mandatory"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style56" align="right">
                                            <asp:Label ID="lblOldAmount" runat="server" Text="Amount"></asp:Label>
                                        </td>
                                        <td class="style58">
                                            <asp:Label ID="lblAmtDis" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style56" align="right">
                                            <asp:Label ID="NewDuration" runat="server" Text="New Amount"></asp:Label>
                                        </td>
                                        <td class="style58">
                                            <asp:CompareValidator ID="cvNewAmount" runat="server" 
                                            ControlToValidate="txtModNewAmt" 
                                            ErrorMessage="New Amount should be greater than zero." Operator="GreaterThan" 
                                            Type="Double" ValueToCompare="0.00"></asp:CompareValidator>
                                            <br />
                                            <asp:TextBox ID="txtModNewAmt" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvNewAmount" runat="server" 
                                            ControlToValidate="txtModNewAmt" ErrorMessage="New Amount is mandatory"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RegularExpressionValidator ID="revNewAmount" runat="server" 
                                            ControlToValidate="txtModNewAmt" 
                                            ErrorMessage="New Amount should be a decimal(Eg: 50.00)" 
                                            ValidationExpression="^\d+\.\d{2}?$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style56" align="right">
                                            <asp:Label ID="lblNewAmount" runat="server" Text="Duration"></asp:Label>
                                        </td>
                                        <td class="style58">
                                            <asp:Label ID="lblDurationDis" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style56" align="right">
                                            <asp:Label ID="lblOldDuration" runat="server" Text="New Duration"></asp:Label>
                                        </td>
                                        <td class="style58">
                                            <asp:TextBox ID="txtModNewDuration" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvNewDuration" runat="server" 
                                            ControlToValidate="txtModNewDuration" 
                                            ErrorMessage="New Duration is mandatory"></asp:RequiredFieldValidator>
                                            <br />
                                            <asp:RangeValidator ID="rvNewDuration" runat="server" 
                                            ControlToValidate="txtModNewDuration" 
                                            ErrorMessage="Duration should be between 30 and 365" MaximumValue="365" 
                                            MinimumValue="30" Type="Integer"></asp:RangeValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style57" align="right">
                                            <asp:Label ID="lblOldDescription" runat="server" Text="Description"></asp:Label>
                                        </td>
                                        <td class="style59">
                                            <asp:Label ID="lblDescriptionDis" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style56" align="right">
                                            <asp:Label ID="NewDescription" runat="server" Text="New Description"></asp:Label>
                                        </td>
                                        <td class="style58">
                                            <asp:TextBox ID="txtModNewDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfvNewDescription" runat="server" 
                                            ControlToValidate="txtModNewDescription" 
                                            ErrorMessage="New Description  is mandatory"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style57" align="right">
                                            <asp:Button ID="btnModify" runat="server" onclick="btnModify_Click" 
                                            Text="Modify" />
                                        </td>
                                        <td class="style59" align="left">
                                            <asp:Button ID="btnCancelModify" runat="server" onclick="btnCancelModify_Click" 
                                            Text="Cancel" CausesValidation="False" />
                                            <asp:Label ID="lblRetMod" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                            <asp:ObjectDataSource ID="odsOffer" runat="server" SelectMethod="GetOffers" 
                            TypeName="Common" OldValuesParameterFormatString="original_{0}">
                            </asp:ObjectDataSource>
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
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style49" colspan="2">
                </td>
            </tr>
        </table>
   </asp:Panel>
 
<asp:UpdatePanel ID="up3" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnl3" runat="server" Visible="False">
            <asp:ObjectDataSource ID="odsActDeact" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetOffersByStatus" 
                TypeName="ServiceProviderBL">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="A" Name="Status" SessionField="Status" 
                        Type="Char" />
                </SelectParameters>
            </asp:ObjectDataSource>
            &nbsp;&nbsp;&nbsp;
            <table align="center" class="style15" border="1">
                <tr>
                    <td class="style18" align="right">
                        <asp:Label ID="lblActDeact" runat="server" Text="lblActDeact"></asp:Label>
                        &nbsp;</td>
                    <td class="style17" align="left">
                        &nbsp;
                        <asp:DropDownList ID="ddlActDeact" runat="server" 
                            onselectedindexchanged="ddlActDeact_SelectedIndexChanged" 
                            AppendDataBoundItems="True" AutoPostBack="True" Width="132px">
                            <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblRetActDeact" runat="server" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="rfvOfferActDeact" runat="server" 
                ControlToValidate="ddlActDeact" ErrorMessage="Offer Name is mandatory" 
                InitialValue="--Select--"></asp:RequiredFieldValidator>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<p>
    &nbsp;<asp:UpdatePanel ID="up4" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnl4" runat="server" Height="109px" Visible="False">
            <table align="center" class="style26" border="1">
                <tr>
                    <td align="center" class="style28">
                        Amount</td>
                    <td>
                        <asp:Label ID="lblAmtActDeact" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="style28">
                        Duration</td>
                    <td>
                        <asp:Label ID="lblDurActDeact" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="style28">
                        Description</td>
                    <td>
                        <asp:Label ID="lblDesActDeact" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="style27" colspan="2">
                        <asp:Button ID="btnActDeact" runat="server" onclick="btnActDeact_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
        </asp:Panel>
<br />
    </ContentTemplate>
</asp:UpdatePanel> 
</p>
</asp:Content>


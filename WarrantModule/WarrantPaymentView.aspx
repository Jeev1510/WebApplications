<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WarrantPaymentView.aspx.cs" EnableEventValidation="false" MasterPageFile="~/Shared/DetailPage.master"  %>
<asp:Content>
ID="Content1" ContentPlaceHolderID="DetailContentPlaceHolder" runat="server">
</asp:Content>
 <SWC:FormHeader Title="Payment - " Description="" ID="FormHeader1" runat='server'>
 </SWC:FormHeader>
<%-- <cc:CslaDataSource ID="WarantEventDS" runat="server" TypeAssemblyName="BTIABLL"
        TypeName="BTIABLL.ApplicationEvent" OnSelectObject="WarantEventDS_SelectObject" OnUpdateObject="WarantEventDS_UpdateObject">
 </cc:CslaDataSource>--%>
<asp:Content ID="WarrantPaymentContent" runat="server" ContentPlaceHolderID="DetailContentPlaceHolder">
    <table border="0" cellpadding="2" cellspacing="2" style="width: 100%; height: 100%">
        <tr>
            <td style="width: 1096px">
                <div style="text-align: left">
                    <table>
                        <tr>
                            <td style="width: 184px; height: 24px; text-align: right">
                            </td>
                            <td style="width: 184px; text-align: right; height: 24px;">
                                <asp:Label ID="PaymentTypeLabel" runat="server" Text="Payment Type"></asp:Label></td>
                            <td style="width: 337px; height: 24px;">
                                <asp:DropDownList ID="PaymentTypeDropdown" runat="server" Width="234px">
                                    <asp:ListItem>--Please Select--</asp:ListItem>
                                    <asp:ListItem>Cheque</asp:ListItem>
                                    <asp:ListItem>DirectDebit</asp:ListItem>
                                    <asp:ListItem>Bpay</asp:ListItem>
                                    <asp:ListItem>DirectCredit</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 184px; height: 15px; text-align: right">
                            </td>
                            <td style="width: 184px; height: 15px; text-align: right">
                                <asp:Label ID="ViaTellerPCLabel" runat="server" Text="Via Teller PC"></asp:Label></td>
                            <td style="width: 337px; height: 15px">
                                <asp:CheckBox ID="ViaTellerPCCheckbox" runat="server" /></td>
                        </tr>
                        <tr>
                            <td style="width: 184px; height: 15px; text-align: right">
                            </td>
                            <td style="width: 184px; height: 15px; text-align: right">
                                <asp:Label ID="BSBLabel" runat="server" Text="BSB"></asp:Label></td>
                            <td style="width: 337px; height: 15px">
                                <asp:TextBox ID="BSBTextbox" runat="server" Width="194px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 184px; height: 15px; text-align: right">
                            </td>
                            <td style="width: 184px; height: 15px; text-align: right">
                                <asp:Label ID="AccountNumberLabel" runat="server" Text="Account Number"></asp:Label></td>
                            <td style="width: 337px; height: 15px">
                                <asp:TextBox ID="AccountNumberTextbox" runat="server" Width="198px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 184px; height: 15px; text-align: right">
                            </td>
                            <td style="width: 184px; height: 15px; text-align: right">
                                <asp:Label ID="AccountNameLabel" runat="server" Text="Account Name"></asp:Label></td>
                            <td style="width: 337px; height: 15px">
                                <asp:TextBox ID="AccountNameTextbox" runat="server" Width="324px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 184px; height: 15px; text-align: right">
                            </td>
                            <td style="width: 184px; height: 15px; text-align: right">
                                <asp:Label ID="ChequeNumberLabel" runat="server" Text="Cheque Number"></asp:Label></td>
                            <td style="width: 337px; height: 15px">
                                <asp:TextBox ID="ChequeNumberTextbox" runat="server" Width="197px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 184px; height: 15px; text-align: right">
                            </td>
                            <td style="width: 184px; height: 15px; text-align: right">
                                <asp:Label ID="TotalDepositAmountLabel" runat="server" Text="Total Deposit Amount"></asp:Label></td>
                            <td style="width: 337px; height: 15px">
                                <asp:TextBox ID="DepositAmountTextbox" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 184px; height: 9px; text-align: right">
                            </td>
                            <td style="width: 184px; height: 9px; text-align: right;">
                                <asp:Label ID="PaymentDateLabel" runat="server" Text="Payment Date"></asp:Label></td>
                            <td style="width: 337px; height: 9px">
                                <SWC:DateControl ID="PaymentDate" runat="server" Width="199px"></SWC:DateControl></td>
                        </tr>
                        <tr>
                            <td style="width: 184px; text-align: right">
                            </td>
                            <td style="width: 184px; text-align: right;">
                                <asp:Label ID="ExpectedClearedFundDate" runat="server" Text="Expected Cleared Fund Date"></asp:Label></td>
                            <td style="width: 337px; text-align: left;">
                                <SWC:DateControl ID="ClearedFundDate" runat="server"></SWC:DateControl></td>
                        </tr>
                        <tr>
                            <td style="width: 184px; text-align: right">
                            </td>
                            <td style="width: 184px; text-align: right;">
                                <asp:Label ID="StatusLabel" runat="server" Text="Status"></asp:Label></td>
                            <td style="width: 337px"><asp:DropDownList ID="StatusDropdown" runat="server" Width="234px">
                                <asp:ListItem>VALID</asp:ListItem>
                                <asp:ListItem>CANCELLED</asp:ListItem>
                            </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 184px; height: 15px; text-align: right">
                            </td>
                            <td style="width: 184px; height: 15px; text-align: right;">
                                <asp:Label ID="PaymentReferenceLabel" runat="server" Text="Payment Reference"></asp:Label></td>
                            <td style="width: 337px; height: 15px">
                                <asp:TextBox ID="PaymentRefTextbox" runat="server" Width="203px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 184px; height: 15px; text-align: right">
                            </td>
                            <td style="width: 184px; height: 15px; text-align: right">
                            </td>
                            <td style="width: 337px; height: 15px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 184px; height: 15px; text-align: right">
                            </td>
                            <td style="width: 184px; height: 15px; text-align: right">
                <asp:Button ID="SaveButton" runat="server" Text="Save" /></td>
                            <td style="width: 337px; height: 15px">
                <asp:Button ID="CancelButton" runat="server" Text="Cancel" /></td>
                        </tr>
                    </table>
                </div>
            
            
            </td>
            
            
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 1096px; height: 14px">
                </td>
            <td style="height: 14px">
            </td>
        </tr>
    </table>
</asp:Content>


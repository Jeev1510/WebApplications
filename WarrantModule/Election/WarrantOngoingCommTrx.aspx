<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WarrantOngoingCommTrx.aspx.cs"
    MasterPageFile="~/Shared/Default.master" Inherits="WebApplication.ApplicationModule.WarrantModule.Election.WarrantOngoingCommTrx" %>

<%@ MasterType VirtualPath="~/Shared/Default.master" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="DefaultContent">

<script language="javascript" type="text/javascript">

var _ExecuteButton = '<%=WarrantCommButton.UniqueID%>';
var _GenerateCommButton = '<%=WarrantGenerateCommBtn.UniqueID%>';
var _ReportButton = '<%=ReportButton.UniqueID%>';
var _hdnCommissionStartDate = '<%=hdnCommissionStartDate.UniqueID %>';
var _hdnCommissionEndDate = '<%=hdnCommissionEndDate.UniqueID %>'; 
var _MonthStartDate = '<%=MonthStartDate.UniqueID %>';
var _MonthEndDate = '<%=MonthEndDate.UniqueID %>';
var _hdnRetvalue = '<%=hdnReturnValue.UniqueID %>';

function confApprove()
{
    var CommStartDateId = document.getElementById(_hdnCommissionStartDate);
    var CommEndDateId = document.getElementById(_hdnCommissionEndDate);
    var MonthSDateId = document.getElementById(_MonthStartDate);
    var MonthEDateId = document.getElementById(_MonthEndDate);
    var executebutton = document.getElementById(_ExecuteButton);
    Returnvalue = document.getElementById(_hdnRetvalue)
    Returnvalue.value = 'true';
    disableWindow();
    if(CommStartDateId.value != MonthSDateId.value || CommEndDateId.value != MonthEDateId.value)
    {
        var resp = window.confirm ('Commission dates are changed.Are you sure want to continue?');
        if (resp == true)
        {
          Returnvalue.value = 'true';
        }
        else
        {
         Returnvalue.value = 'false';
        }
       
    }
    executebutton.click();
}
function generateCommission()
{
//    var generateCommButton = document.getElementById(_GenerateCommButton);
//    var CommStartDateId = document.getElementById(_hdnCommissionStartDate);
//    var CommEndDateId = document.getElementById(_hdnCommissionEndDate);
//    var MonthSDateId = document.getElementById(_MonthStartDate);
//    var MonthEDateId = document.getElementById(_MonthEndDate);
//    Returnvalue = document.getElementById(_hdnRetvalue)
//    Returnvalue.value = 'true';
//    disableWindow();
//    if(CommStartDateId.value != MonthSDateId.value || CommEndDateId.value != MonthEDateId.value)
//    {
//        var resp = window.confirm ('Commission dates are changed.Are you sure want to continue?');
//        if (resp == true)
//        {
//          Returnvalue.value = 'true';
//        }
//        else
//        {
//         Returnvalue.value = 'false';
//        }
//       
//    }
//   generateCommButton.click();

    var generateCommButton = document.getElementById(_GenerateCommButton);
    disableWindow();
    generateCommButton.click();

}

function ExecuteReport()
{
    var ReportButton = document.getElementById(_ReportButton);
    disableWindow();
    ReportButton.click();
   
}

//function ViewReport()
//{
//    window.location.href = 'http://audoza552/ReportserverRAUDIAM01?%2fWIAS+Reports%2fOps_CSApplicationSummary&rs:Command=Render';
//}
    </script>

    <SWC:FormHeader Title="Warrrrant Ongoing-Commission" Description="" ID="CommissionElectionHeader"
        runat='server'>
    </SWC:FormHeader>
    <table style="width: 1000px">
    <tr>
            <td align="left" >
                Commission Start Date
            </td>
            <td align="left">
                <SWC:DateControl ID="MonthStartDate" runat="server"></SWC:DateControl>
            </td>
            <%-- </tr>
        <tr>--%>
            <td align="center" style="width: 169px">
                Commission End Date
            </td>
            <td align="left" style="width: 104px">
                <SWC:DateControl ID="MonthEndDate" runat="server"></SWC:DateControl>
            </td>
        </tr>
        <tr>
            <td style="width: 198px">
                <asp:Panel ID="PnlIncluExclusive" runat="server" BorderStyle="Groove" Width="100px">
                    <asp:RadioButtonList ID="CommissionRadioButtonList" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="All" Selected="True">All Commissions</asp:ListItem>
                        <asp:ListItem Value="Not Calculated">Commission Not Calculated</asp:ListItem>
                    </asp:RadioButtonList>
                </asp:Panel>
            </td>
            <td style="width: 83px">
                <button type="button" onclick="confApprove();">
                    View Commission</button></td>
            <td style="width: 150px" align="center">
                <asp:Label ID="Label2" runat="server" Text="No of Records" Width="85px"></asp:Label>
                <asp:Label ID="DisplayNumberLabel" runat="server" Font-Bold="True" Text="0"></asp:Label>
            </td>
             <td style="width: 150px" align="center">
                <asp:Label ID="lblNew" runat="server" Text=" Newly Created" Width="85px"></asp:Label>
                <asp:Label ID="lblNewlyCreated" runat="server" Font-Bold="True" Text="0"></asp:Label>
            </td>
             <td style="width: 165px" align="center">
                <asp:Label ID="lblAlready" runat="server" Text=" Already Created" Width="150px"></asp:Label>
                <asp:Label ID="lblAlreadyCreated" runat="server" Font-Bold="True" Text="0"></asp:Label>
            </td>
             </tr>
       </table>
    <table>
        <tr>
            <td>
                <div style="table-layout: fixed; height: 400px">
                    <SWC:SuperGridview ID="WarrantCommSuperGridView" runat="server" AllowHandleClick="True"
                        DeleteButtonText="Delete Item(s)" EmptyDataText="No data in this list" NewButtonText="New Text"
                        ShowEmptyTable="True" Visible="true" AutoGenerateColumns="False" ForeColor="Transparent"
                        BackColor="White" Width="1000px">
                        <Columns>
                            <asp:BoundField DataField="portf_num" HeaderText="Portf Num">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Application_Num" HeaderText="Application Num">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="appl_received_date" HeaderText="Appl Received Date" DataFormatString="{0:dd/MM/yyyy}"
                                HtmlEncode="False">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="inv_type" HeaderText="Inv Type">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="inv_sub_type" HeaderText="Inv Sub Type">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <%--<asp:BoundField DataField="wiasName" HeaderText="Wias Name">
                                <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CSName" HeaderText="ComputerShare Name">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="acc_num" HeaderText="Acc Num">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <%-- <asp:BoundField DataField="PrimaryMktQty" HeaderText="Primary Mkt Qty">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SecondaryMktQty" HeaderText="Secondary Mkt Qty">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"></itemstyle>
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="fpa_member_code" HeaderText="Fpa Member Code">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Fpa_Co_Num" HeaderText="Fpa Co Num">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <%-- <asp:BoundField DataField="share_regis_name" HeaderText="Share Regis Name">
                                <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>--%>
                            <%-- <asp:BoundField DataField="issuer" HeaderText="issuer">
                                <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="hin_srn" HeaderText="HinSrn">
                                <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="strike_pla" HeaderText="Strike Pla">
                                <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Comm_Rate" HeaderText="Comm Rate">
                                <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Gst" HeaderText="Gst">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Contrib_Amt" HeaderText="Contrib Amt">
                                <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Comm_Qty" HeaderText="Comm Qty">
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Amt" HeaderText="Amt">
                                <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            
                          <asp:BoundField DataField="Portfolio_Value" HeaderText="Portfolio Value">
                                <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                             <asp:BoundField DataField="CommissionCreation" HeaderText="Commission Creation">
                                <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            <%-- <asp:BoundField DataField="CalculatedAmt" HeaderText="Calculated Amt">
                                <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>
                            
                               <asp:BoundField DataField="DifferenceInAmt" HeaderText="Difference In Amt">
                                <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left" />
                            </asp:BoundField>--%>
                        </Columns>
                    </SWC:SuperGridview>
                </div>
            </td>
            <td style="width: 152px; height: 4px">
            </td>
        </tr>
    </table>
    <table style="width: 90%">
        <tr>
            <td style="width: 90%; height: 18px; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="height: 18px; text-align: center; width: 335px;" colspan="2" rowspan="">
                <button type="button " onclick="generateCommission();">
                    Generate Commission</button></td>
            <td>
                <button type="button " onclick="ExecuteReport();">
                    View Report</button>
            </td>
        </tr>
        <tr>
            <td style="width: 90%; height: 18px; text-align: center">
                <asp:Button ID="WarrantCommButton" runat="server" Text="View Commission" OnClick="WarrantCommButton_Click"
                    Style="display: none" />
                <asp:Button ID="WarrantGenerateCommBtn" runat="server" Text="Generate Commission"
                    OnClick="WarrantGenerateCommBtn_Click" Style="display: none" />
                <asp:Button ID="ReportButton" runat="server" Text="View Report" OnClick="ReportButton_Click"
                    Style="display: none" /></td>
        </tr>
    </table>
    <asp:HiddenField ID="ExceptionDetails" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdnCommissionStartDate" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hdnCommissionEndDate" runat="server"></asp:HiddenField>
     <asp:HiddenField ID="hdnReturnValue" runat="server"></asp:HiddenField>
</asp:Content>

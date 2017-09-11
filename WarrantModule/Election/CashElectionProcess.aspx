<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" Inherits="WebApplication.WarrantModule.CashElectionProcess"
    Title="Warrant Reset - None" MasterPageFile="~/Shared/Default.master" Codebehind="CashElectionProcess.aspx.cs" %>

<%@ MasterType VirtualPath="~/Shared/Default.master" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="DefaultContent">

<script language="javascript" type="text/javascript">
var _hdnfldControl = '<%=HiddenField2.UniqueID %>';
var _ExecuteButton = '<%=CashExecutionNoneButton.UniqueID%>';
var _dealexecuteButton = '<%=DealExecutionNoneButton.UniqueID%>';
var _printtoexcelButton = '<%=ReportButton.UniqueID%>';

function confApprove()
{
    var resp = window.confirm ('This "Execute" option should be only on completion of entering all the Reset Elections. Please ensure that both Rollover prices (for same series)  and Warrant prices (for deferred codes) are correct before continuing. This option has no "Undo" feature and therefore please reconfirm before continuing.');
    var hdnfld = document.getElementById(_hdnfldControl);
    var executebutton = document.getElementById(_ExecuteButton);
    if (hdnfld != undefined  )
        {
            hdnfld.value = resp;
            if (resp == true)
            {
                disableWindow();
                executebutton.click();
            }
        }
}
function confApproveDeal()
{
    var dealbutton = document.getElementById(_dealexecuteButton);
    dealbutton.click();
}

function doPrint()
{
    var printtoexcelbutton = document.getElementById(_printtoexcelButton);
    printtoexcelbutton.click();
}
</script>

<SWC:FormHeader Title="Cash Election - " Description="" ID="CashElectionHeader" runat='server'>

 </SWC:FormHeader>
        <table>
            <tr>
                <td style="width: 107px; height: 15px">
                </td>
                <td style="width: 155px; height: 15px">
                </td>
                <td style="width: 139px; height: 15px">
                </td>
                <td style="width: 101px; height: 15px">
                </td>
                <td style="width: 331px; height: 15px">
                    </td>
            </tr>
            <tr>
                <td style="width: 107px; text-align: right">
                </td>
                <td style="width: 155px; text-align: right">
                    <asp:Label id="ResetDateLabel" runat="server" Text="Reset Date" CssClass="flat" ></asp:Label></td>
                <td style="width: 139px">
                    <asp:DropDownList id="ResetDateDropdown" runat="server" CssClass="flat"  OnSelectedIndexChanged="ResetDateDropdown_SelectedIndexChanged" AutoPostBack="true" onchange="disableWindow();" Width="141px">
                    </asp:DropDownList></td>
                <td style="width: 101px">
                </td>
                <td style="width: 331px">
                </td>
            </tr>
            <tr>
                <td style="width: 107px; text-align: right">
                </td>
                <td style="width: 155px; text-align: right">
                    <asp:Label ID="Label4" runat="server" Text="Position Date"></asp:Label></td>
                <td style="width: 139px">
                    <asp:DropDownList id="PositionDateDropdown" runat="server" CssClass="flat"  OnSelectedIndexChanged="ResetDateDropdown_SelectedIndexChanged" AutoPostBack="true" onchange="disableWindow();" Width="144px">
                </asp:DropDownList></td>
                <td style="width: 101px">
                </td>
                <td style="width: 331px">
                </td>
            </tr>
            <tr>
                <td style="width: 107px; text-align: right">
                </td>
                <td style="width: 155px; text-align: right">
                    <asp:Label id="Label1" runat="server" Text="View Event Records By" CssClass="flat" ></asp:Label></td>
                <td style="width: 139px">
                    <asp:RadioButtonList  id="OptionRadioButtonList" runat="server" onclick="disableWindow();" AutoPostBack="true" CssClass="flat"  RepeatLayout="Flow" OnSelectedIndexChanged="OptionRadioButtonList_SelectedIndexChanged"
                        Width="182px" RepeatDirection="Horizontal" BorderStyle="Groove"  >
                        <asp:ListItem>Summary</asp:ListItem>
                        <asp:ListItem>Detail</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td style="width: 101px">
                </td>
                <td style="width: 331px">
                </td>
            </tr>
            <tr>
                <td style="width: 107px; height: 15px; text-align: right">
                </td>
                <td style="width: 155px; height: 15px; text-align: right">
                    <asp:Label ID="Label3" runat="server" Text="Election" CssClass="flat" ></asp:Label></td>
                <td style="width: 139px; height: 15px">
                    <asp:RadioButtonList ID="ProcessRadioButtonList" runat="server" CssClass="flat" onclick="disableWindow();"  AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="ProcessRadioButtonList_SelectedIndexChanged"
                        Width="184px" BorderStyle="Groove">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem Value="NoneOnly">Do Nothing(None)</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td style="width: 101px; height: 15px">
                    <button style="DISPLAY: none" onclick="confApproveDeal()" type="button ">
                                        Create Deal</button></td>
                <td style="width: 331px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 107px; height: 20px; text-align: right">
                </td>
                <td style="width: 155px; text-align: right; height: 20px;">
                    <asp:Label id="EventDateLabel" runat="server" Text="Event Date" CssClass="flat" ></asp:Label></td>
                <td style="width: 139px; height: 20px;">
                    <SWC:DateControl ID="EventDate" runat="server" ReadOnly="True" CssClass="flat" ></SWC:DateControl></td>
                <td style="width: 101px; height: 18px">
                    </td>
                <td style="width: 331px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 107px; height: 4px; text-align: right">
                    </td>
                <td style="width: 155px; height: 4px; text-align: left">
                </td>
                <td style="width: 139px; height: 4px; text-align: right">
                    &nbsp;</td>
                <td style="width: 101px; height: 4px; text-align: right;">
                </td>
                <td style="width: 42%; height: 4px; text-align: right;">
                    <asp:Label ID="Label2" runat="server" Text="No of Records" Width="85px"></asp:Label>
                <asp:Label ID="DisplayNumberLaabel" runat="server" Font-Bold="True" Text="0"></asp:Label></td>
            </tr>
        </table>
         <table style="width: 100%">
        <tr>
              <td>
              <div style="table-layout: fixed; height:400px">
               <SWC:SuperGridview ID="CashElectionSuperGridView" runat="server" AllowHandleClick="True" DeleteButtonText="Delete Item(s)"
                    EmptyDataText="No data in this list" ShowEmptyTable="True"  AutoGenerateColumns="False" ForeColor="Transparent" BackColor="White" Width="1000px">
                    <Columns>
                        <asp:BoundField DataField="InternalExternal"  HeaderText="Int./Ext.">
                            <headerstyle width="175px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Acc_Num" HeaderText="Acc Num">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="Total_Qty" HeaderText="Total Qty">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="ElectedQty" HeaderText="Elected Qty" >
                                        <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                        <itemstyle horizontalalign="Left"></itemstyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="AvailQty" HeaderText="Avail Qty" >
                            <headerstyle width="125px" horizontalalign="Left"/>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                          <asp:BoundField DataField="CompletedQty" HeaderText="Completed Qty">
                                        <headerstyle width="125px" horizontalalign="Center"/>
                        <itemstyle horizontalalign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="CashQty" HeaderText="Cash Qty">
                                        <headerstyle width="125px" horizontalalign="Center"/>
                        <itemstyle horizontalalign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField 
                                DataField="RolledQtyElected" HeaderText="Rolled Qty Elected">
                                 <headerstyle width="125px" horizontalalign="Left"/>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                         <asp:BoundField 
                                DataField="RolledQtyNone" HeaderText="Rolled Qty None" >
                                 <headerstyle width="125px" horizontalalign="Left"/>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                         <asp:BoundField 
                            DataField="Rollover_Price" HeaderText="Rollover Price">
                             <headerstyle width="125px" horizontalalign="Left"/>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                         <asp:BoundField 
                            DataField="Sharehld_Appl_Warrant_Price" HeaderText="Sharehld Appl Warrant Price" >
                             <headerstyle width="100px" horizontalalign="Left"/>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                            DataField="RollOverQtyNone_Extra" HeaderText="RollOver Qty None Extra" >
                             <headerstyle width="125px" horizontalalign="Left"/>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                            DataField="Residual_Amt" HeaderText="Residual Amt" >
                             <headerstyle width="125px" horizontalalign="Left"/>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                            DataField="New_Qty" HeaderText="New Qty" >
                             <headerstyle width="125px" horizontalalign="Left"/>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        
                    </Columns>
                </SWC:SuperGridview>
                <SWC:SuperGridview ID="CashElectionDetailSuperGridView" runat="server" AllowHandleClick="True" DeleteButtonText="Delete Item(s)"
                    EmptyDataText="No data in this list"   NewButtonText="New Text" ShowEmptyTable="True"  Visible="false" AutoGenerateColumns="False" ForeColor="Transparent" BackColor="White" width="1000px">
                    <Columns>
                        <asp:BoundField DataField="InternalExternal"  HeaderText="Int./Ext.">
                            <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Portf_Num" HeaderText="Portf Num">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="Application_Num" HeaderText="Application Num">
                            <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="Appl_Received_Date" HeaderText="Appl Received Date" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="Acc_Num" HeaderText="Acc Num">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="Total_Qty" HeaderText="Total Qty">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="ElectedQty" HeaderText="Elected Qty">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                  <itemstyle horizontalalign="Left"></itemstyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="AvailQty" HeaderText="Avail Qty">
                                   <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="CompletedQty" HeaderText="Completed Qty">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="CashQty" HeaderText="Cash Qty">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="RolledQtyElected" HeaderText="Rolled Qty Elected">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                         <asp:BoundField DataField="RolledQtyNone" HeaderText="Rolled Qty None">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="RolloverAmount" HeaderText="Rollover Amount">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="RollOverQtyNone" HeaderText="RollOver Qty None">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="CashSurplus" HeaderText="Cash Surplus">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="CompletionPayment" HeaderText="Completion Payment">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="CashDeficit" HeaderText="Cash Deficit" >
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                            <asp:BoundField DataField="Position_date"  HeaderText="Position date" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Inv_Type" HeaderText="Inv Type" >
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Rollover_Price" HeaderText="Rollover Price" >
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                                DataField="Sharehld_Appl_Warrant_Price" HeaderText="Sharehld Appl Warrant Price" >
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                                DataField="RollOverQtyNone_Extra" HeaderText="RollOver Qty None Extra" >
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                                DataField="Residual_Amt" HeaderText="Residual Amt" >
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                                DataField="Sharehld_Appl_Cap_Component1" HeaderText="Sharehld Appl Cap Component1">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                                DataField="Prepaid_Interest1" HeaderText="Prepaid Interest" >
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                                DataField="Sharehld_Appl_Putcost" HeaderText="Sharehld Appl Putcost" >
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                                DataField="New_Qty" HeaderText="New Qty"  >
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                    </Columns>
                   </SWC:SuperGridview>
               </div>
            </td>
                    <td style="width: 152px; height: 4px">
                    </td>

        </tr>
    </table>
    <table style="width: 75%">
        <tr>
            <td style="width: 75%; height: 18px; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="width: 75%; height: 18px; text-align: center">
                <button onclick="confApprove()" type="button " title="Warrant Reset - None process to be run on or after T + 5 days (T - Reset Date)">
                                        Create Event</button></td>
        </tr>
        <tr>
            <td style="width: 30%; height: 18px; text-align: center">
                    <asp:Button id="CashExecutionNoneButton" runat="server" Text="Execute Cash-None"  OnClick="CashExecutionNoneButton_Click" style="DISPLAY: none"/>
                    <asp:Button id="DealExecutionNoneButton" runat="server" Text="Execute Deal"  OnClick="DealExecutionNoneButton_Click" style="DISPLAY: none"/>
                <asp:Button id="ReportButton" runat="server" Text="Print to EXCEL" OnClick="ReportButton_Click" style="DISPLAY: none" /></td>
        </tr>
    </table>
    <input type="hidden" id="HiddenField1" name="HiddenField1"/>
<asp:HiddenField ID="HiddenField2" runat="server"></asp:HiddenField>
<asp:HiddenField id="ExceptionDetails" runat="server"></asp:HiddenField>
 &nbsp;</asp:Content>




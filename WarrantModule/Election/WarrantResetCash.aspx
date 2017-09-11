<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" Inherits="WebApplication.ApplicationModule.WarrantModule.Election.WarrantResetCash"
    Title="Warrant Reset-Cash" MasterPageFile="~/Shared/Default.master" Codebehind="WarrantResetCash.aspx.cs" %>
<%@ MasterType VirtualPath="~/Shared/Default.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="DefaultContent">

<script language="javascript" type="text/javascript">
var _ExecuteButton = '<%=WarrantResetCashButton.UniqueID%>';
var _Grid = '<%=CashElectionSuperGridView.ClientID%>';
var isOK = "true";
function confApprove()
{
    var executebutton = document.getElementById(_ExecuteButton);
    var gridview = document.getElementById(_Grid);
    if (gridview.rows.length != 0)
    {
        for(i=1; i< gridview.rows.length; i++)
        {
            var cashprice = gridview.rows[i].cells[0].innerText;
            var cellone =gridview.rows[i].style;
            if (cashprice.length == 1)
            {
                isOK = "false";
                cellone.backgroundColor ="#FFCC80";
            }
        }   
        if (isOK == "true")
        {
            disableWindow();
            executebutton.click();
        }
        else
        {
         alert('Please update the price for the highlighted warrant(s) and then click "Apply Pricing" button');
        }
    }
}

function doPrint()
{
    //var printtoexcelbutton = document.getElementById(_printtoexcelButton);
    //printtoexcelbutton.click();
}
</script>

<SWC:FormHeader Title="Cash Election - " Description="" ID="CashElectionHeader" runat='server'>

 </SWC:FormHeader>
        <table>
            <tr>
                <td style="width: 107px; height: 15px">
                </td>
                <td style="width: 107px; height: 15px" >
                </td>
                <td style="width: 155px; height: 15px">
                </td>
                <td style="width: 152px; height: 15px">
                </td>
                <td style="width: 152px; height: 15px">
                </td>
                <td style="width: 152px; height: 15px">
                    </td>
            </tr>
            <tr>
                <td style="width: 107px; text-align: right">
                </td>
                <td style="width: 107px; text-align: right">
                </td>
                <td style="width: 155px; text-align: right">
                    <asp:Label id="ResetDateLabel" runat="server" Text="Reset Date"></asp:Label></td>
                <td style="width: 152px">
                    <asp:DropDownList id="ResetDateDropdown" runat="server"  OnSelectedIndexChanged="ResetDateDropdown_SelectedIndexChanged" AutoPostBack="true" onchange="disableWindow();" Width="96px">
                    </asp:DropDownList></td>
                <td style="width: 152px">
                </td>
                <td style="width: 152px">
                </td>
            </tr>
            <tr>
                <td style="width: 107px; height: 18px; text-align: right">
                </td>
                <td style="width: 107px; height: 18px; text-align: right">
                </td>
                <td style="width: 155px; text-align: right; height: 18px;">
                    <asp:Label id="EventDateLabel" runat="server" Text="Event Date"></asp:Label></td>
                <td style="width: 152px; height: 18px;">
                    <SWC:DateControl ID="EventDate" runat="server" ReadOnly="True" ></SWC:DateControl></td>
                <td style="width: 152px; height: 18px">
                    </td>
                <td style="width: 152px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 107px; height: 5px; text-align: left">
                </td>
                <td style="width: 107px; height: 5px; text-align: left">
                </td>
                <td style="width: 155px; height: 5px; text-align: left">
                </td>
                <td style="width: 152px; height: 5px">
                </td>
                <td style="width: 152px; height: 5px; text-align: right">
                </td>
            </tr>
            <tr>
                <td style="width: 107px; height: 4px; text-align: right">
                </td>
                <td style="width: 107px; height: 4px; text-align: right">
                    </td>
                <td style="width: 155px; height: 4px; text-align: left">
                </td>
                <td style="width: 152px; height: 4px; text-align: right">
                    &nbsp;</td>
                <td style="width: 152px; height: 4px; text-align: right;">
                </td>
                <td style="width: 40%; height: 4px; text-align: right;">
                    <asp:Label ID="Label2" runat="server" Text="No of Records" Width="85px"></asp:Label>
                <asp:Label ID="DisplayNumberLaabel" runat="server" Font-Bold="True" Text="0"></asp:Label></td>
            </tr>
        </table>
        <table style="width: 100%" >
        <tr>
            <td >
                <div style="table-layout: fixed; height:400px"> 
                <SWC:SuperGridview ID="CashElectionSuperGridView"  runat="server" AllowHandleClick="True" DeleteButtonText="Delete Item(s)"
                    EmptyDataText="No data in this list" ShowEmptyTable="True"  AutoGenerateColumns="False" ForeColor="Transparent" BackColor="White"   >
                    <Columns>
                        <asp:BoundField 
                            DataField="Cash_Price" HeaderText="Cash Price" >
                             <headerstyle Width="120px" horizontalalign="Left"/>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                            DataField="Unit_qty" HeaderText="Unit Qty">
                             <headerstyle Width="125px" horizontalalign="Left"/>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Portf_Num" HeaderText="Portf Num">
                            <headerstyle Width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="Application_Num" HeaderText="Application Num">
                            <headerstyle Width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="Appl_Received_Date"  HeaderText="Appl Received Date" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" >
                             <headerstyle Width="150px" horizontalalign="Left"></headerstyle>
                        <itemstyle horizontalalign="Left"></itemstyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Event_Date" HeaderText="Event Date" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False">
                            <headerstyle Width="125px" horizontalalign="Left"/>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                          <asp:BoundField DataField="Event_Num" HeaderText="Event Num">
                                        <headerstyle  Width="125px" horizontalalign="Left" />
                        <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Acc_Num" HeaderText="Acc Num">
                              <headerstyle horizontalalign="Left"/>
                        <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                                DataField="Event_Type" HeaderText="Event Type">
                                 <headerstyle Width="125px" horizontalalign="Left"/>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                         <asp:BoundField 
                                DataField="Rollover_Type" HeaderText="Rollover Type" >
                                 <headerstyle Width="125px" horizontalalign="Left"/>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                         
                         <asp:BoundField 
                            DataField="Status" HeaderText="Status" >
                             <headerstyle horizontalalign="Left"/>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                            DataField="Entered_By_User_Id" HeaderText="Entered By UserId" >
                             <headerstyle Width="150px" horizontalalign="Left"/>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                            DataField="Entered_Datetime" HeaderText="Entered Datetime" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" >
                             <headerstyle horizontalalign="Left"/>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                            DataField="Reset_Date" HeaderText="Reset Date" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" >
                             <headerstyle horizontalalign="Left"/>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField 
                            DataField="Effective_Date" HeaderText="Effective Date" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False">
                             <headerstyle horizontalalign="Left"/>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        
                    </Columns>
                </SWC:SuperGridview>
                </div>
                <asp:Button id="ReportButton" runat="server" Text="Print to EXCEL"  style="DISPLAY: none" />
                    <asp:Button id="WarrantResetCashButton" runat="server" Text="Execute Cash-None" OnClick="WarrantResetCashButton_Click"   style="DISPLAY: none"/></td>
        </tr>
        <tr>
            <td style="width: 910px; height: 16px; text-align: right">
                &nbsp;
                </td>
        </tr>
             <tr>
                 <td style="width: 910px; height: 17px; text-align: right">
                     &nbsp;</td>
             </tr>
    </table>
    <table style="width: 85%">
        <tr>
            <td style="width: 85%; height: 22px; text-align: center">
                <button onclick="confApprove()" type="button ">
                                        Apply Pricing</button></td>
        </tr>
    </table>
    <input type="hidden" id="HiddenField1" name="HiddenField1"/>
<asp:HiddenField ID="HiddenField2" runat="server"></asp:HiddenField>
<asp:HiddenField id="ExceptionDetails" runat="server"></asp:HiddenField>
<asp:Literal id="ShowScript" runat="server"></asp:Literal> <asp:Literal id="OnCompleteScriptLiteral" runat="server"></asp:Literal> 
<iframe id="ifrmMsg" style="DISPLAY:none; LEFT:33%; WIDTH:200px; POSITION:absolute; TOP:34%; HEIGHT:50px"
        src="/wsframe/_common/message.aspx?msg=Please wait while processing..." frameBorder="1" scrolling="no">
</iframe>  
 &nbsp;</asp:Content>

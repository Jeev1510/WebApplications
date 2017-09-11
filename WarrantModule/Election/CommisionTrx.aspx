<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/Default.master" CodeBehind="CommisionTrx.aspx.cs" Inherits="WebApplication.ApplicationModule.WarrantModule.Election.CommisionTrx" %>

<%@ MasterType VirtualPath="~/Shared/Default.master" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="DefaultContent">

<script language="javascript" type="text/javascript">
var _ExecuteButton = '<%=WarrantCommButton.UniqueID%>';
function confApprove()
{
    var executebutton = document.getElementById(_ExecuteButton);
    disableWindow();
    executebutton.click();
}
</script>

<SWC:FormHeader Title="Warrrrant Reset-Commission" Description="" ID="CashElectionHeader" runat='server'>

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
                    <asp:Label id="ResetDateLabel" runat="server" Text="Reset Date"></asp:Label></td>
                <td style="width: 139px">
                    <asp:DropDownList id="ResetDateDropdown" runat="server" OnSelectedIndexChanged="ResetDateDropdown_SelectedIndexChanged" AutoPostBack="true" onchange="disableWindow();" Width="141px">
                    </asp:DropDownList></td>
                <td style="width: 101px">
                </td>
                <td style="width: 331px">
                </td>
            </tr>
             <tr>
                <td style="width: 107px; height: 18px; text-align: right">
                </td>
                <td style="width: 155px; text-align: right; height: 18px;">
                    <asp:Label id="EventDateLabel" runat="server" Text="Comm. Transaction Date"></asp:Label></td>
                <td style="width: 139px; height: 18px;">
                    <SWC:DateControl ID="EventDate" runat="server" ReadOnly="True" ></SWC:DateControl></td>
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
                <asp:Label ID="DisplayNumberLabel" runat="server" Font-Bold="True" Text="0"></asp:Label></td>
            </tr>
        </table>
         <table style="width: 100%">
        <tr>
              <td>
              <div style="table-layout: fixed; height:400px">
               <SWC:SuperGridview ID="WarrantCommSuperGridView" runat="server" AllowHandleClick="True" DeleteButtonText="Delete Item(s)"
                    EmptyDataText="No data in this list"   NewButtonText="New Text" ShowEmptyTable="True"  Visible="true" AutoGenerateColumns="False" ForeColor="Transparent" BackColor="White" Width="1000px" >
                    <Columns>
                        <asp:BoundField DataField="Portf_Num" HeaderText="Portf Num">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="trx_date" HeaderText="Trx Date" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="Comm_Trx_Type" HeaderText="Comm Trx Type">
                            <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="Amt" HeaderText="Amt" >
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="Orig_Trx_Num" HeaderText="Orig Trx Num">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="Planner_Code" HeaderText="Planner Code">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="Contrib_Amt" HeaderText="Contrib Amt">
                                <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                  <itemstyle horizontalalign="Left"></itemstyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Comm_Rate" HeaderText="Comm Rate">
                                   <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Application_Num" HeaderText="Application Num">
                            <headerstyle width="150px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Appl_Received_Date" HeaderText="Appl Received Date" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Gst" HeaderText=Gst>
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                         <asp:BoundField DataField="Inv_Type" HeaderText="Inv Type">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Inv_Sub_Type" HeaderText="Inv Sub Type">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Inv_Acc_Num" HeaderText="Inv Acc Num">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Fpa_Co_Num" HeaderText="Fpa Co Num">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                                <itemstyle horizontalalign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Commentary" HeaderText="Commentary">
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
    <table style="width: 90%">
        <tr>
            <td style="width: 90%; height: 18px; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="width: 90%; height: 18px; text-align: center">
                <button type="button " onclick="confApprove();" title="Warrant Reset - Generation process to be run on or after T + 5 days (T - Reset Date)">
                                        Generate Commission</button></td>
        </tr>
        <tr>
            <td style="width: 90%; height: 18px; text-align: center">
                    <asp:Button id="WarrantCommButton" runat="server" Text="Generate Commission" OnClick="WarrantCommButton_Click"  style="DISPLAY: none"/>
                <asp:Button id="ReportButton" runat="server" Text="Print to EXCEL" style="DISPLAY: none" /></td>
        </tr>
    </table>
    <asp:HiddenField id="ExceptionDetails" runat="server"></asp:HiddenField>
 &nbsp;</asp:Content>





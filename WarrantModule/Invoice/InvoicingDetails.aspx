<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="InvoicingDetails.aspx.cs" MasterPageFile="~/Shared/Default.master" Inherits="WebApplication.ApplicationModule.WarrantModule.Invoice.InvoicingDetails" %>

<%@ MasterType VirtualPath="~/Shared/Default.master" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="DefaultContent">

<script language="javascript" type="text/javascript">
    function canSave()
    {
        var _invoiceDate = '<%=InvoiceDate.ClientID%>';
        var invoice = $get(_invoiceDate).value;
            
        
        if(invoice == '')
        {
        alert("please enter Invoice Date");
        return false;
        }
        var answer = confirm("Before continuing this option please complete creating\n \n a) UPFRONT Commissions including RESET commission (if applicable) \n b) ONGOING/TRAILER Commission for PEL & Warrant products");
        return answer;
    }  

     
  
      function showReport()
      {
        
              window.location.href = "http://audoza552/ReportserverRAUDIAM01?%2fWIAS+Reports%2fOps_Commision_Invoice_Report" //&TRX_STARTDATE=" + start + "&TRX_ENDDATE=" + end;
           
      }  
  
    function OnRequestInit(postBackElement)
    {
        ShowWait();
    }  

    function ShowWait()
    {
         document.getElementById("ifrmMsg").style.display="block";  
    }
        
    function HideWait()
    {
        document.getElementById("ifrmMsg").style.display="none";  
    }
    
    function onRequestCompleted(args, postBackElement)
    {
        HideWait(); 

        if (postBackElement.name.indexOf("btnsave") >=0)
        {       
        }
    }
</script>

<SWC:FormHeader Title="Invoice-Planner Commission" Description="" ID="InvoiceComm" runat='server'>
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
                <%--   <tr>
                <td style="width: 107px; height: 18px; text-align: right">
                </td>
                <td style="width: 230px; text-align: right; height: 18px;">
                    <asp:Label id="EventDateLabel" runat="server" Text="Comm. Transaction Start Date"></asp:Label></td>
                <td style="width: 139px; height: 18px;">
                    <SWC:DateControl ID="StartDate" runat="server" ReadOnly="False" ></SWC:DateControl></td>
                <td style="width: 101px; height: 18px">
                    </td>
                <td style="width: 331px; height: 18px">
                </td>
            </tr>
            
                  <tr>
                <td style="width: 107px; height: 18px; text-align: right">
                </td>
                <td style="width: 230px; text-align: right; height: 18px;">
                    <asp:Label id="Label1" runat="server" Text="Comm. Transaction End Date"></asp:Label></td>
                <td style="width: 139px; height: 18px;">
                    <SWC:DateControl ID="EndDate" runat="server" ReadOnly="False" ></SWC:DateControl></td>
                <td style="width: 101px; height: 18px">
                    </td>
                    </tr>--%>
                <tr>
                 <td style="width: 107px; height: 18px; text-align: right">
                </td>
                  <td style="width: 200px; text-align: right; height: 18px;">
                    <asp:Label id="Label2" runat="server" Text="Invoice Date"></asp:Label></td>
                <td style="width: 139px; height: 18px;">
                    <SWC:DateControl ID="InvoiceDate" runat="server" ReadOnly="False" ></SWC:DateControl></td>
                <td style="width: 331px; height: 18px">

                <asp:Button ID="btnShow" CssClass="button" Text="Show Invoice Details" OnClick = "Show_Click"  runat="server" />                
                </td>
               
            </tr>            
            </table>

          <table style="width: 100%">
                   <tr align="right">  <td style="width: 136px" align="right">
                <asp:Label ID="Label3" runat="server" Text="No of Records: " Width="85px"></asp:Label>
                <asp:Label ID="DisplayNumberLabel" runat="server" Font-Bold="True" Text="0"></asp:Label>
            </td></tr>
          </table>
          
         <table style="width: 100%">
          <tr>          
              <td>
              <div style="table-layout: fixed; height: 390px">            
                     <SWC:SuperGridview ID="InvoiceSuperGridView" runat="server" AllowHandleClick="True" 
                    EmptyDataText="No data in this list" AllowSorting="true" NewButtonText="New Text" ShowEmptyTable="True"  Visible="true" AutoGenerateColumns="False" ForeColor="Transparent" BackColor="White" Width="750px"  AllowPaging="true"  PageSize="11"   >
                        <Columns>
                        <asp:BoundField DataField="PORTF_NUM" HeaderText="Portf Num">
                            <itemstyle horizontalalign="Left"  />
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                        </asp:BoundField>
                         <asp:BoundField DataField="APPLICATION_NUM" HeaderText="Application No">
                            <itemstyle horizontalalign="Left"  />
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="TRX_DATE" HeaderText="Transaction Date"  DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False">
                            <itemstyle horizontalalign="Left"  />
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                        </asp:BoundField>
                         <asp:BoundField DataField="COMM_TRX_TYPE" HeaderText="Comm Tran Type">
                            <itemstyle horizontalalign="Left"  />
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="PLANNER_CODE" HeaderText="Planner Code">
                            <itemstyle horizontalalign="Left"  />
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_TYPE" HeaderText="Invoice Type">
                            <itemstyle horizontalalign="Left"  />
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                        </asp:BoundField>                        
                        </Columns>
                        <PagerSettings FirstPageText="First Page"  NextPageText="Next Page" Mode="NextPrevious"  />
                    </SWC:SuperGridview>
              </div>
              </td>

           </tr>
          </table>
              
         <table style="width: 75%">
        <tr>
            <td style="width: 100%; height: 18px">
            </td>
        </tr>
        <tr>        
            <td style="width: 50%; height: 18px">
                     <asp:Button ID="btnsave" CssClass="button" Text="Assign Invoice No" runat="server" OnClientClick="return canSave()" OnClick="btnSave_Click" />                              
            </td>
             <td style="width: 50%; height: 18px">                                   
                <button type="button" class="button" onclick="return showReport();" title="Show Report">View Commission for the period report</button>
             </td>
             </tr>                                     
        </table>       

 <iframe id="ifrmMsg" style="DISPLAY:none; LEFT:39%; WIDTH:200px; POSITION:absolute; TOP:36%; HEIGHT:50px"
			src="/wsframe/_common/message.aspx?msg=Please wait while processing..." frameborder="1" scrolling="no">
		</iframe>
</asp:Content>

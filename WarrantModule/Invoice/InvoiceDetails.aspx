<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" MasterPageFile="~/Shared/Default.master"  CodeBehind="InvoiceDetails.aspx.cs" Inherits="WebApplication.ApplicationModule.WarrantModule.Invoice.InvoiceDetails"  %>
  

<%@ MasterType VirtualPath="~/Shared/Default.master" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="DefaultContent">

<script language="javascript" type="text/javascript">
function canSave()
{
    var _invoiceDate = '<%=InvoiceDate.ClientID%>';
    var invoice = $get(_invoiceDate).value;
 
     checkfields();  

    
    if(invoice == '')
    {
    alert("please enter Invoice Date");
    return false;
    }
    
    
    var answer = confirm("Before continuing this option please complete creating\n \n a) UPFRONT Commissions including RESET commission (if applicable) \n b) ONGOING/TRAILER Commission for PEL & Warrant products");
return answer;
}
    

  
  function checkfields()
  {
    var _startDate = '<%=StartDate.ClientID%>';
    var _endDate = '<%=EndDate.ClientID%>';
    
    
    var start = $get(_startDate).value;    
    var end = $get(_endDate).value;
    
    
    if(start == '' || end == '')
    {
    alert("please fill date columns");
    return false;
    }  
    return true; 
    
    }
  
  
  
  function showReport()
  {
   var proc = checkfields(); 
   
     var _startDate = '<%=StartDate.ClientID%>';
    var _endDate = '<%=EndDate.ClientID%>';
    
    
    var start = $get(_startDate).value;    
    var end = $get(_endDate).value;

    if(proc)
    {
    window.location.href = "http://audoza552/ReportserverRAUDIAM01?%2fWIAS+Reports%2fOps_Commision_Invoice_Report&TRX_STARTDATE=" + start + "&TRX_ENDDATE=" + end;
    }
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
            alert("Invoice Details Saved successfully . Click OK to refresh the screen.");
            
            window.location.href = window.location.href;
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
                   <tr>
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
                    </tr>
                <tr>
                                <td style="width: 107px; height: 18px; text-align: right">
                </td>
                                <td style="width: 200px; text-align: right; height: 18px;">
                    <asp:Label id="Label2" runat="server" Text="Invoice Date"></asp:Label></td>
                <td style="width: 139px; height: 18px;">
                    <SWC:DateControl ID="InvoiceDate" runat="server" ReadOnly="False" ></SWC:DateControl></td>
                <td style="width: 331px; height: 18px">

                <asp:Button ID="btnShow" CssClass="button" Text="Show" OnClientClick ="return checkfields()" OnClick = "Show_Click"  runat="server" />
                
                </td>
               
            </tr>            
            </table>

          
         <table style="width: 100%">
          <tr>
              <td>
              <div style="table-layout: fixed; height:400px">            
                     <SWC:SuperGridview ID="InvoiceSuperGridView" runat="server" AllowHandleClick="True" 
                    EmptyDataText="No data in this list"   NewButtonText="New Text" ShowEmptyTable="True"  Visible="true" AutoGenerateColumns="False" ForeColor="Transparent" BackColor="White" Width="750px" >
                        <Columns>
                        <asp:BoundField DataField="PORTF_NUM" HeaderText="Portf Num">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                         <asp:BoundField DataField="APPLICATION_NUM" HeaderText="Application No">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="TRX_DATE" HeaderText="Transaction Date">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                         <asp:BoundField DataField="COMM_TRX_TYPE" HeaderText="Comm Tran Type">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="PLANNER_CODE" HeaderText="Planner Code">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_TYPE" HeaderText="Invoice Type">
                            <headerstyle width="125px" horizontalalign="Left"></headerstyle>
                            <itemstyle horizontalalign="Left"  />
                        </asp:BoundField>                        
                        </Columns>
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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                   <ContentTemplate>
                     <asp:Button ID="btnsave" CssClass="button" Text="Assign Invoice No" runat="server" OnClientClick="return canSave()" OnClick="btnSave_Click" />                              
                      </ContentTemplate>
                       </asp:UpdatePanel>
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
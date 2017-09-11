<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uscSecondPayment.ascx.cs" Inherits="WebApplication.uscSecondPayment" %>

<cc:CslaDataSource ID="WarantEventDS" runat="server" TypeAssemblyName="BTIABLL"
        TypeName="BTIABLL.ApplicationEvent" OnSelectObject="WarantEventDS_SelectObject" OnUpdateObject="WarantEventDS_UpdateObject">
 </cc:CslaDataSource>
 <script>
 function calculatePrice()
{
 var UnitPrice = document.getElementById('<%=FormView1.FindControl("txtCurrentPrice").ClientID%>').value;
 
 var electedqty  = document.getElementById('<%=FormView1.FindControl("txtElectedQuantity").ClientID%>').value;
 var secondpayment = document.getElementById('<%=FormView1.FindControl("txtSecondpayment").ClientID%>');

secondpayment.value = UnitPrice * electedqty;         // UnitPrice * electedqty;

// if(electedqty.value != "" && UnitPrice.value != "")
// {
// var sc = Number(electedqty.value) * Number(UnitPrice.value);
// secondpayment.value = sc;
// }
 }
 </script>
 
<asp:FormView ID="FormView1" runat="server" DataSourceID="WarantEventDS" DefaultMode="Edit" Width="100%" >
<EditItemTemplate>
    <table width="100%" >
            <tr>
            <td style="width: 221px" align="right">
            Election Date
            </td> 
            <td> 
            <SWC:DateControl ID="txtElectionDate" runat="server" Text = '<%# Bind("EventDate") %>' CssClass="flat" TextBoxWidth=""   
                   ReadOnly="false"  >
            </SWC:DateControl>
            </td>
            </tr>
            <tr>
            <td style="width: 221px" align="right">
           Currrent Price($)
            </td> 
            <td> 
            <asp:TextBox ID="txtCurrentPrice" runat="server" Text='<%# Bind("UnitPrice", "{0:0.00}") %>' ReadOnly="true" CssClass="flat"   ></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 221px" align="right">
           Elected Qty
            </td>
            <td>
            <asp:TextBox ID="txtElectedQuantity" runat="server" Text='<%# Bind("UnitQty", "{0:0}") %>' ReadOnly="false" CssClass="flat" onchange="calculatePrice();" ></asp:TextBox>
            </td>
            </tr>
            <tr>
            <td style="width: 221px" align="right">
           Second Payment($)
            </td> 
            <td> 
            <asp:TextBox ID="txtSecondpayment"  runat="server" ReadOnly="false" Enabled ="false" CssClass="flat"></asp:TextBox>
            </td>
            </tr>
            
            </table>
      
        </EditItemTemplate>
    </asp:FormView>

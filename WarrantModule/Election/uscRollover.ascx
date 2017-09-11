<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uscRollover.ascx.cs" Inherits="WebApplication.ApplicationModule.uscRollover" %>
<script>
function RoundValue(val)
 {
   return Math.round(val * 100) / 100 ;
        
}
function calculateplannerfee()
{
var commper = document.getElementById('ctl00$DetailContentPlaceHolder$ctl00$FormView1$txtcommissionpt');
var strikerate = document.getElementById('ctl00$DetailContentPlaceHolder$ctl00$hdnStrikeRate');
var plannerfeehdn = document.getElementById('ctl00$DetailContentPlaceHolder$ctl00$hdnPlannerFee');
var plannerfee = document.getElementById('ctl00$DetailContentPlaceHolder$ctl00$FormView1$txtPlannerFee');
var finalrolloverprice = document.getElementById('ctl00$DetailContentPlaceHolder$ctl00$FormView1$txtFinalRolloverPrice');
var rolloverprice = document.getElementById('ctl00$DetailContentPlaceHolder$ctl00$FormView1$txtRolloverPrice');
if (Number(commper.value) > 0)
{
    plannerfee.value = RoundValue((Number(strikerate.value) * Number(commper.value))/100);
    plannerfeehdn.value = plannerfee.value;
    finalrolloverprice.value = RoundValue(Number(rolloverprice.value) -  Number(plannerfeehdn.value));
}
else
{
finalrolloverprice.value = RoundValue(Number(rolloverprice.value))
}
}
</script>
<cc:CslaDataSource ID="WarantEventDS" runat="server" TypeAssemblyName="BTIABLL"
        TypeName="BTIABLL.ApplicationEvent" OnSelectObject="WarantEventDS_SelectObject" OnUpdateObject="WarantEventDS_UpdateObject">
 </cc:CslaDataSource>
<asp:FormView ID="FormView1" runat="server" DataSourceID="WarantEventDS" DefaultMode="Edit" Width="100%" >
<EditItemTemplate>
            <table cellspacing="2" cellpadding="2" width="100%" border="0">
             <tr>
                 <td align="right" style="width: 125px; height: 28px;">
                 </td>
            <td  align="right" style="width: 146px; height: 28px;">
            Election Date
            </td> 
            <td style="height: 28px" > 
            <%--<asp:TextBox ID="txtElectionDate" runat="server" Text='<%# Convert.Tostring(Bind("EventDate")) %>' ReadOnly="false" CssClass="flat" >
            </asp:TextBox>--%>
            <SWC:DateControl ID="txtElectionDate" runat="server" Text = '<%# Bind("EventDate", "{0}") %>' AutoPostBack="true" OnTextChanged="txtElectionDate_TextChanged" TextBoxWidth="" CssClass="flat" Width="220px" ></SWC:DateControl>
            </td>
            </tr>
             <tr>
                 <td align="right">
                 </td>
            <td  align="right" style="width: 146px">
            RollOver Acc Num
            </td>
            <td style="width: 125px">
            <asp:DropDownList ID="ddlRollOverAccNum" AppendDataBoundItems="True"  runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlRollOverAccNum_SelectedIndexChanged" >
            <asp:ListItem Value="">--Please select--</asp:ListItem>
            </asp:DropDownList></td>
                </tr>
            <tr>
                 <td align="right">
                 </td>
            <td  align="right" style="width: 146px">
           Commission Pct(%)
            </td>
            <td style="width: 125px"  >
            <asp:TextBox ID="txtcommissionpt" runat="server" Text='<%# Bind("CommRatePct") %>' AutoPostBack ="true" OnTextChanged="txtcommissionpt_TextChanged" ></asp:TextBox>
            </td>
            </tr> 
    
            <tr>
            <td align="right">
                &nbsp;</td> 
            <td style="width: 146px" > 
                Please Select Options</td>
                <td style="width: 125px">
            <asp:RadioButton ID="rbSameUnits"  runat="server" AutoPostBack="true" Text="Same Units" GroupName="ElectionOption" OnCheckedChanged="rbSameUnits_CheckedChanged"/>
            <asp:RadioButton ID="rbAdjustUnits"  runat="server" AutoPostBack="true" Text="Adjust Units" GroupName="ElectionOption" OnCheckedChanged="rbAdjustUnits_CheckedChanged" /></td>
            </tr>
            <tr>
                <td align="right">
                </td>
            <td  align="right" style="width: 146px">
           Defered Price
            </td> 
            <td style="width: 125px"> 
            <asp:TextBox ID="txtDeferedOverPrice" runat="server" Text='<%# Bind("ReinvestApplPrice") %>' Enabled="false" ></asp:TextBox>
            </td>
            </tr>
            <tr>
                <td align="right">
                </td>
            <td align="right" style="width: 146px">
           Elected Qty
            </td>
            <td style="width: 125px" >
            <asp:TextBox ID="txtElectedQuantity" runat="server"  Text='<%# Bind("UnitQty", "{0:0}") %>' ></asp:TextBox>
            </td>
            </tr>
            <tr>
                <td align="right">
                </td>
            <td  align="right" style="width: 146px">
            Rollover Price
            </td> 
            <td style="width: 125px" > 
            <asp:TextBox ID="txtRolloverPrice"  runat="server" Enabled="false" Text='<%# Bind("UnitPrice") %>' ></asp:TextBox>
            </td>
            </tr>
                    <tr>
                <td align="right">
                </td>
                <td align="right" style="width: 146px">Strike Rate</td>
                        <td style="width: 125px">
                    <asp:TextBox ID="txtStrikerate" runat="server"  Enabled="false" ></asp:TextBox></td>
            </tr> 
            <tr>
                <td align="right">
                </td>
            <td  align="right" style="width: 146px">
         Placement Fee
            </td> 
            <td style="width: 125px" > 
            <asp:TextBox ID="txtPlannerFee"  runat="server" Enabled="true" ></asp:TextBox>
            </td>
            </tr>
            <tr>
                <td align="right">
                </td>
            <td  align="right" style="width: 146px">
         Final Rollover Price
            </td> 
            <td style="width: 125px" > 
            <asp:TextBox ID="txtFinalRolloverPrice"  runat="server" Enabled="true" Text='<%# Bind("UnitPrice") %>'  onfocus="blur();" ></asp:TextBox>
            </td>
            </tr>
            <tr>
                <td align="right">
                </td>
            <td  align="right" style="width: 146px">
        New Warrants Value($)
            </td> 
            <td style="width: 125px" > 
            <asp:TextBox ID="txtValNewWarrants"  runat="server" Enabled="false" ></asp:TextBox>
            </td>
            </tr>
            
            <tr>
                <td align="right">
                </td>
            <td align="right" style="width: 146px" >
           <asp:Label ID="lblClientPaysReceives" runat="server" Text="Client Pays/Receives"  ></asp:Label>
            </td> 
            <td style="width: 125px" > 
            <asp:TextBox ID="txtClientPaysReceives"  runat="server" Enabled="true" onfocus="blur();"></asp:TextBox>
            </td>
            </tr>
            
            <tr>
                <td align="right">
                </td>
            <td align="right" style="width: 146px">
           <asp:Label ID="lblShareClientReceives" runat="server" Text="Warrants Client Receive"></asp:Label>
            </td> 
            <td style="width: 125px" > 
            <asp:TextBox ID="txtShareClientReceives"  runat="server" Enabled="false"></asp:TextBox>
            </td>
            </tr>
            </table>
            <asp:HiddenField id="RollOverType" runat="server"></asp:HiddenField>
            <asp:HiddenField id="ShareReceived" runat="server"></asp:HiddenField>
            <asp:HiddenField id="ResidualAmount" runat="server"></asp:HiddenField>
      
        </EditItemTemplate>
    </asp:FormView> 
<asp:HiddenField ID="hdnStrikeRate" runat="server" />
<asp:HiddenField ID="hdnPlannerFee" runat="server" />
<asp:HiddenField ID="hdnRollOverAccNum" runat="server" />
<asp:HiddenField id="ExceptionDetails" runat="server"></asp:HiddenField>
<%--<asp:HiddenField id="RollOverType" runat="server"></asp:HiddenField>
<asp:HiddenField id="ShareReceived" runat="server"></asp:HiddenField>--%>
  <asp:Literal id="ShowScript" runat="server"></asp:Literal>
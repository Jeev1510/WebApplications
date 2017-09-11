<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WarrantElectionView.aspx.cs" EnableEventValidation="false" MasterPageFile="~/Shared/DetailPage.master" Inherits="WebApplication.ApplicationModule.WarrantElectionView" %>


<asp:Content ID="Content1" ContentPlaceHolderID="DetailContentPlaceHolder" runat="server">

<script>
function refreshParent() {
  window.opener.location.href = window.opener.location.href;
  window.close();
}

function ConfApprove()
{

var _hdnfldControl = '<%=HiddenField2.UniqueID %>';
var _hdnRetvalue = '<%=hdnRetvalue.UniqueID %>';
var _txtElectedQty = '<%=ElectionPlaceHolder.Controls[0].FindControl("FormView1").FindControl("txtelectedQuantity").ClientID %>';
var _btnSave = '<%=btnSave.UniqueID%>';
var qty = document.getElementById(_txtElectedQty).value;
var AvailableQty = document.getElementById(_hdnfldControl).value;
Returnvalue = document.getElementById(_hdnRetvalue)
var SaveButton = document.getElementById(_btnSave);
Returnvalue.value = 'true';
if(Number(qty) > Number(AvailableQty))
{
var resp = window.confirm ('Elected Quantity is higher than available quantity provided by Computer Share Registry. Please Press OK if you are sure that Computer Share balance is correct.Or press cancel to correct the quantity.');


            if (resp == true)
            {
              Returnvalue.value = 'true';
            }
            else
            {
             Returnvalue.value = 'false';
            }
            

}
}


</script>

 <SWC:FormHeader Title="Election - " Description="" ID="FormHeader1" runat='server'>
        <%--<AH:ApplicationHeader ID="ApplicationHeader" runat="server"></AH:ApplicationHeader>--%>
 </SWC:FormHeader>
 <table cellspacing="1" cellpadding="0" width="100%" border="1" >
 <tr>
 <td>
 </td>
 </tr>
<tr height="25" >
    <td colspan="1" style="width: 318px" align="right">
        Portfolio Number</td>
    <td colspan="1" style="width: 324px">
        &nbsp;<asp:Label ID="PortfolioNumberLabel" runat="server" Text="Sample"  Font-Bold="True" ></asp:Label></td>
    <td colspan="1" style="width: 382px" align="right">
        Portfolio Name</td>
    <td colspan="1" style="width: 382px" align="left">
        &nbsp;<asp:Label ID="PortfolioNameLabel" runat="server" Text="Label" Width="239px" Font-Bold="True"></asp:Label></td>
    <td colspan="1">
    </td>

</tr>
    <tr height="25">
        <td colspan="1" style="width: 318px; height: 25px" align="right">
            Application Number</td>
        <td colspan="1" style="width: 324px; height: 25px">
            &nbsp;<asp:Label ID="ApplicationNumberLabel" runat="server" Text="Label"  Font-Bold="True"></asp:Label></td>
        <td align="right" colspan="1" style="width: 382px; height: 25px">
            Application Received Date</td>
        <td align="left" colspan="1" style="width: 382px; height: 25px">
            &nbsp;<asp:Label ID="AppReceivedDateLabel" runat="server"  Font-Bold="True"></asp:Label></td>
        <td colspan="1" style="height: 25px">
        </td>
    </tr>
    <tr height="25">
        <td colspan="1" style="width: 318px; height: 25px" align="right">
            Warrant Code</td>
        <td colspan="1" style="width: 324px; height: 25px">
            &nbsp;<asp:Label ID="WarrantCodeLabel" runat="server" Text="Label"  Font-Bold="True"></asp:Label></td>
        <td align="right" colspan="1" style="width: 382px; height: 25px">
            Reset Date</td>
        <td align="left" colspan="1" style="width: 382px; height: 25px">
            &nbsp;<asp:Label ID="ResetDateLabel" runat="server" Text="Label"  Font-Bold="True"></asp:Label></td>
        <td colspan="1" style="height: 25px">
        </td>
    </tr>
    <tr height="25">
        <td colspan="1" style="width: 318px; height: 25px" align="right">
            Available Qty</td>
        <td colspan="1" style="width: 324px; height: 25px">
            &nbsp;<asp:Label ID="AvailableQtyLabel" runat="server" Text="Label" Width="149px" Font-Bold="True"></asp:Label></td>
        <td align="right" colspan="1" style="width: 382px; height: 25px">
            <asp:Label ID="lblPlanner" runat="server" Visible="false" Text="Planner"></asp:Label></td>
        <td align="left" colspan="1" style="width: 382px; height: 25px">
            <asp:Label ID="lblPlannerText" runat="server" ToolTip="To change the planner go to the application detail tab"  Visible="false"></asp:Label></td>
        <td colspan="1" style="height: 25px">
        </td>
    </tr>
</table>
    <table>
    <tr>
    <td>
    <div>
    <asp:PlaceHolder ID="ElectionPlaceHolder" runat="server"></asp:PlaceHolder>
    </div>
     </td>
    </tr>
    </table>
<table width="100%">
<tr >
    <td   align="right" style="width: 309px; height: 21px;">
      <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="ConfApprove();" OnClick="btnSave_Click" Width="55px" /></td>
    <td align="left" style="width: 60px; height: 21px;" >
<asp:Button ID="btnCancel" runat="server" OnClientClick="window.close();" Text="Cancel" /></td>
<td align="left" style="width: 53px; height: 21px" >
<asp:Button ID="btnVerify" runat="server" Text="Verify" OnClick="btnVerify_Click"  /></td>
<td align="left" style="height: 21px; width: 100px;" >
<asp:Button ID="btnundoVerify" runat="server" Text="Undo Verify" OnClick="btnundoVerify_Click" /></td>
<td align="left" style="height: 21px" >
<asp:Button ID="btnPushToWias" runat="server" Text="Push To Wias" OnClick="btnPushToWias_Click"/></td>
</tr>
</table>
<asp:HiddenField id="ExceptionDetails" runat="server"></asp:HiddenField>
  <asp:Literal id="ShowScript" runat="server"></asp:Literal>
  <asp:HiddenField id="HiddenField2" runat="server"></asp:HiddenField>
  <asp:HiddenField id="hdnRetvalue" runat="server"></asp:HiddenField>

</asp:Content>

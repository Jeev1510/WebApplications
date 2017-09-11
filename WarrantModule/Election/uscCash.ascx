<%@ Control Language="C#" AutoEventWireup="true" Codebehind="uscCash.ascx.cs" Inherits="WebApplication.ApplicationModule.uscCash" %>
 <cc:CslaDataSource ID="WarantEventDS" runat="server" TypeAssemblyName="BTIABLL"
        TypeName="BTIABLL.ApplicationEvent" OnSelectObject="WarantEventDS_SelectObject" OnUpdateObject="WarantEventDS_UpdateObject">
 </cc:CslaDataSource>
<asp:FormView ID="FormView1" runat="server" DataSourceID="WarantEventDS" DefaultMode="Edit" Width="100%" >
<EditItemTemplate>
    <table cellspacing="2" cellpadding="0" width="100%">
        <colgroup>
            <col style="padding-left: 20px" width="275" />
            <col style="padding-left: 3px" />
        </colgroup>
        <tr height="10"><td colspan="2"/></tr>
        <tr>
            <td align="right">Event Date</td>
            <td>
                <SWC:DateControl ID="txtElectionDate" runat="server" Text = '<%# Bind("EventDate") %>'  CssClass="flat" TextBoxWidth="" Width="190px" ></SWC:DateControl>  
            </td>
        </tr>
        <tr>
            <td align="right">Elected Qty</td>                            
            <td>
                <asp:TextBox ID="txtElectedQuantity" runat="server" Text='<%# Bind("UnitQty", "{0:0}")%>'
                    Width="180px" ReadOnly="false" CssClass="flat"></asp:TextBox><br />
            </td>
        </tr>
    </table>
</EditItemTemplate>
</asp:FormView>


<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowMaster.master" AutoEventWireup="true" CodeFile="ServiceProviderHome.aspx.cs" Inherits="Default2" Theme="LetsPortNowTheme"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
    }
    .style3
    {
        width: 136px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
                       <table style="width: 100%; height: 0px">
                                <tr>
                                    <td colspan="3">
                                        <br />
                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                        <asp:LinkButton ID="lnkUpdateMyProfile" runat="server" 
                                            onclick="lnkUpdateMyProfile_Click" 
                                            ToolTip="Click this link to update your profile" CausesValidation="False">UpdateMyProfile</asp:LinkButton>
                                        <br />
                                        <asp:Label ID="lblErrorMessage" runat="server" Text="ErrorMessage" 
                                            Visible="False"></asp:Label>
                                        &nbsp;&nbsp;<asp:UpdatePanel 
                                            ID="pnlUpdateProfile" runat="server">
                                            <ContentTemplate>
                                             <asp:Panel ID="pnlUpdate" runat="server" Visible="False">
                                                <table class="style1">
                                                    <tr>
                                                        <td class="style3">
                                                            Address</td>
                                                        <td>
                                                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" 
                                                                ToolTip="Enter Address"></asp:TextBox>
                                                            &nbsp;<asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                                                                ControlToValidate="txtAddress" ErrorMessage="Please provide address"></asp:RequiredFieldValidator>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">
                                                            Contact Number</td>
                                                        <td>
                                                            <asp:TextBox ID="txtContactNumber" runat="server" 
                                                                ToolTip="Enter 10 digit contact number"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvContactNumber" runat="server" 
                                                                ControlToValidate="txtContactNumber" 
                                                                ErrorMessage="Please Provide 10 digit Contact Number"></asp:RequiredFieldValidator>
                                                            <br />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:RegularExpressionValidator ID="revContactNumber" runat="server" 
                                                                ControlToValidate="txtContactNumber" 
                                                                ErrorMessage="Invalid ContactNumber! should contain 10 digits  only" 
                                                                ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">
                                                            Porting Charge</td>
                                                        <td>
                                                            <asp:TextBox ID="txtPortingCharge" runat="server" 
                                                                ToolTip="Enter porting charge within 0 to 50" 
                                                                ontextchanged="txtPortingCharge_TextChanged"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvPortingCharge" runat="server" 
                                                                ControlToValidate="txtPortingCharge" 
                                                                ErrorMessage="Porting charge field is mandatory"></asp:RequiredFieldValidator>
                                                            <br />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:RangeValidator ID="rngPortingCharge" runat="server" 
                                                                ControlToValidate="txtPortingCharge" 
                                                                ErrorMessage="Invalid Porting  charge!Value should be between 0 and 50" MaximumValue="50.0" 
                                                                MinimumValue="0.0" Type="Double"></asp:RangeValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style2" colspan="2">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
                                                                Text="Update" ToolTip="Click here to update your profile" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Button ID="btnCancel" runat="server" 
                                                                Text="Cancel" CausesValidation="False" Height="26px" 
                                                                onclick="btnCancel_Click" />
                                                            <br />
                                                            <br />
                                                            <asp:Label ID="lblUpdateStatus" runat="server" Text="lblUpdateStatus" 
                                                                Visible="False"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkClose" runat="server" onclick="lnkClose_Click" 
                                                                ToolTip="Click here to close the update window" Visible="False">Ok</asp:LinkButton>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:LinkButton ID="lnkModify" runat="server" onclick="lnkModify_Click" 
                                                                ToolTip="Click here to modify the data again" Visible="False">Modify</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                                 </asp:Panel>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 495px">
                                        &nbsp;</td>
                                    <td style="width: 26px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 495px">
                                        Number of customers ported to you:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblNoOfCustPortedTo" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td style="width: 26px">
                                        &nbsp;</td>
                                    <td rowspan="2">
                                        Customer&#39;s feedback for you:</td>
                                </tr>
                                <tr>
                                    <td style="width: 495px">
                                        Number of customers ported away from you:&nbsp;
                                        <asp:Label ID="lblNoOfCustPortedAway" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td style="width: 26px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 495px">
                                        &nbsp;</td>
                                    <td style="width: 26px">
                                        &nbsp;</td>
                                    <td rowspan="2">
                                        <asp:GridView ID="gvCustomerFeedback" runat="server" CellPadding="4" 
                                            DataSourceID="ObjectDataSource4" EmptyDataText="No Feedbacks available for you" 
                                            EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                            SkinID="skGridView">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <EditRowStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        </asp:GridView>
                                        <br />
                                        <asp:LinkButton ID="lnkViewMore" runat="server" 
                                            ToolTip="Click this link to view all feedbacks" CausesValidation="False" 
                                            onclick="lnkViewMore_Click">ViewMore&gt;&gt;</asp:LinkButton>
                                        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" 
                                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetFeedback" 
                                            TypeName="ServiceProviderBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DefaultValue="" Name="serviceProviderId" 
                                                    SessionField="ServiceProviderId" Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 495px">
                                        Your most popular prepaid plan is:<br />
                                        <asp:GridView ID="gvMostPopularPrepaidPlan" runat="server" CellPadding="4" 
                                            DataSourceID="ObjectDataSource1" EmptyDataText="No Data Found" 
                                            EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                            SkinID="skGridView">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <EditRowStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                            OldValuesParameterFormatString="original_{0}" 
                                            SelectMethod="GetMostPopularPrepaidPlan" TypeName="ServiceProviderBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DefaultValue="" Name="serviceProviderId" 
                                                    SessionField="ServiceProviderId" Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                    <td style="width: 26px">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 495px">
                                        &nbsp;</td>
                                    <td style="width: 26px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 495px">
                                        Your most popular postpaid plan is:<br />
                                        <asp:GridView ID="gvMostPopularPostpaidPlan" runat="server" CellPadding="4" 
                                            DataSourceID="ObjectDataSource2" EmptyDataText="No Data Found" 
                                            EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
                                            SkinID="skGridView">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <EditRowStyle BackColor="#999999" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                            OldValuesParameterFormatString="original_{0}" 
                                            SelectMethod="GetMostPopularPostpaidPlan" TypeName="ServiceProviderBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DefaultValue="" Name="serviceProviderId" 
                                                    SessionField="ServiceProviderId" Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                    <td style="width: 26px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 495px">
                                    </td>
                                    <td style="width: 26px">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 495px">
                                        Pending Payments:<br />
                                        <asp:GridView ID="gvPendingPayment" runat="server" AutoGenerateColumns="False" 
                                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                            CellPadding="3" EnableModelValidation="True" 
                                            onselectedindexchanged="gvPendingPayment_SelectedIndexChanged" 
                                            DataSourceID="ObjectDataSource3" EmptyDataText="No Pending payments for you" 
                                            onrowcommand="gvPendingPayment_RowCommand" SkinID="skGridView">
                                            <Columns>
                                                <asp:BoundField HeaderText="Porting Id" DataField="PortingId" />
                                                <asp:BoundField HeaderText="UPC" DataField="UniquePortingCode" />
                                                <asp:BoundField HeaderText="Application Date" DataField="ApplicationDate" />
                                                <asp:BoundField HeaderText="Plan Name" DataField="PlanName" />
                                                <asp:ButtonField CommandName="MakePayment" Text="Make Payment" />
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        </asp:GridView>
                                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                                            OldValuesParameterFormatString="original_{0}" 
                                            SelectMethod="GetPendingPaymentDetails" TypeName="ServiceProviderBL">
                                            <SelectParameters>
                                                <asp:SessionParameter DefaultValue="" Name="serviceProviderId" 
                                                    SessionField="ServiceProviderId" Type="String" />
                                            </SelectParameters>
                                        </asp:ObjectDataSource>
                                    </td>
                                    <td style="width: 26px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        
    <br />

<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
</asp:Content>


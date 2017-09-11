<%@ Page Title="" Language="C#" MasterPageFile="~/TrainingMaster.master" Theme="TrainingTheme" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="List" %>

<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl"
    TagPrefix="ASPP" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style="background-color: #E4E4E4;width:100%; height: 415px;">
                <marquee behavior="scroll" direction="left" onmouseover="this.stop();" 
                    onmouseleave="this.start();" 
                    style="height: 17px; width: 99%; margin-left: 8px; font-size: 12px;"> 
                        <asp:Label runat="server" ID="lblReg" Text="To nominate for the programs, please register in "></asp:Label>
                        <asp:LinkButton ID="lbtnreg" runat="server" 
                             onclick="lbtnreg_Click" Font-Size="12px">Infosys Training System (iLearn)</asp:LinkButton>
                        <asp:Label runat="server" ID="lblRegScroll" Text="->Navigate to Training Catalogue -> Select Start and End Date -> Select Location -> Select the Course -> Click on view details -> Register"></asp:Label></marquee> 

        <asp:UpdatePanel ID="upnlList" runat="server" width="100%">
            <ContentTemplate>
                <asp:Panel ID="pnlList" runat="server" Height="83px" >
                
                    <h2 style=" width: 100%; height: 30px;">
                        Program Details</h2>
                            <table>
                                <tr style="height: 25px">
                                    <td style="width: 398px">
                                       <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="true " 
                                            Height="28px" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged" 
                                            Width="195px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 670px" align="right">
                                        <asp:ImageButton ID="ImageButton2" runat="server" BorderStyle="Outset" 
                                            CausesValidation="False" Height="34px" ImageUrl="~/ELFinal.gif" 
                                            onclick="ImageButton2_Click" Width="158px" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                      
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    <td align="right" style="padding-right:15px">
                                        <asp:ImageButton ID="ImageButton1" runat="server" BorderStyle="Outset" 
                                            CausesValidation="False" Height="33px" ImageUrl="~/Credit-points.gif" 
                                            Width="154px" onclick="ImageButton1_Click" />
                                     
                                    
                                    
                                    </td>
                                </tr>
                    </table>
         
                                                                                      
                    
                    <table align="center" style="width: 98%; height: 160px;">
                        <tr>
                            <td align="center">
                                <asp:GridView ID="gvProducts" runat="server" SkinID="skGridView" 
                                    ToolTip="Program Details" AutoGenerateColumns="False" Font-Size="Medium" 
                                    RowHeaderColumn="ProgramID" onrowcreated="gvProducts_RowCreated" 
                                    Width="99%" onselectedindexchanged="gvProducts_SelectedIndexChanged" 
                                    AllowSorting="True" BorderColor="#000066" onsorting="gvProducts_Sorting">
                                    <Columns>
                                        <asp:TemplateField AccessibleHeaderText="Program ID" HeaderText="Program ID">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ProgramID") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("ProgramID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField AccessibleHeaderText="Date" HeaderText="Date" 
                                            SortExpression="Date">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Date") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Date", "{0:d}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField AccessibleHeaderText="Program" DataField="Program" 
                                            HeaderText="Program" SortExpression="program">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField AccessibleHeaderText="Day" DataField="Day" HeaderText="Day">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField AccessibleHeaderText="Type" DataField="Type" HeaderText="Type">
                                        <HeaderStyle Font-Strikeout="False" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField AccessibleHeaderText="Unit" DataField="Unit" HeaderText="Unit">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField AccessibleHeaderText="Location" DataField="Location" 
                                            HeaderText="Location">
                                        <HeaderStyle Font-Strikeout="False" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField AccessibleHeaderText="Job Level" DataField="JobLevel" 
                                            HeaderText="Job Level">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField AccessibleHeaderText="Duration" DataField="Duration" 
                                            HeaderText="Duration">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField AccessibleHeaderText="Time" DataField="Time" 
                                            DataFormatString="{0:t}" HeaderText="Time">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <HeaderStyle Font-Bold="True" Font-Strikeout="False" ForeColor="Black" 
                                        HorizontalAlign="Center" Wrap="True" VerticalAlign="Middle" />
                                    <RowStyle HorizontalAlign="Center" />
                                </asp:GridView>
                                <br />
                            </td>
                        </tr>
                    </table>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                                                                                      
                    
                    <br />
                                                                                      
                    
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

 
 
   
    

 </asp:Content>




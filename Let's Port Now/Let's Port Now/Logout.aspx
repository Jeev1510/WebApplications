<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowCommonMaster.master" AutoEventWireup="true" CodeFile="Logout.aspx.cs" Inherits="Logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

 p.MsoNormal
	{margin-bottom:.0001pt;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	    margin-left: 0in;
        margin-right: 0in;
        margin-top: 0in;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <p class="MsoNormal">
    You have successfully logged out.
    <asp:LinkButton ID="lbtnClickHere" runat="server" 
        onclick="lbtnClickHere_Click1">Click Here</asp:LinkButton>
&nbsp;&nbsp;to login again<o:p></o:p></p>
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pop.aspx.cs" Inherits="Pop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: medium;
        }
        .style2
        {
            height: 41px;
        }
        .style3
        {
            height: 37px;
        }
        .style4
        {
            font-size: 16px;
            font-style: italic;
        }
        .style5
        {
            font-size: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 331px; width: 649px">
   
            <h2 style=" width: 100%; height: 24px;">
                        &nbsp;Credit Points
                        </h2>
            <span style="color:#000000; " class="style4">
                &nbsp;CDP Training has one Non Assessment Credit Point per program. </span>
                      <br />
            <br />
    <table align="left" style="font-size: medium; ">
        <tr>
            <td align="left" class="style3">
                <i><span style="color:#000000; font-size: 17px;">
                &nbsp;</span><span style="color:#000000; " class="style5">Please go through the below 
                links to know more about the HMM credit system:</span></i></td>
        </tr>
        <tr>
            <td align="left" class="style2">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Italic="True" 
                    onclick="LinkButton1_Click" CssClass="style1">http://sparsh/departments/psd/hmm/doc/learning_credit_point_system.pdf</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="left">
                <br />
                <asp:LinkButton ID="LinkButton2" runat="server" Font-Italic="True" 
                    Font-Size="Medium" 
                    onclick="LinkButton2_Click" CssClass="style1">http://sparshv2/portals/LnD/Documents/HMM/index.html</asp:LinkButton>
                </td>
        </tr>
        </table>
            <br />
            <br />
    </div>
    </form>
</body>
</html>

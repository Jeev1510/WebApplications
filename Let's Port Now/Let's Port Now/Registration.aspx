<%@ Page Title="" Language="C#" MasterPageFile="~/LetsPortNowCommonMaster.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style2
    {
        width: 100%;
    }
    .style3
    {
    }
    .style4
    {
        width: 248px;
    }
    .style5
    {
        width: 299px;
    }
    .style6
    {
        width: 251px;
    }
    .style7
    {
        width: 296px;
    }
        .style8
        {
            width: 251px;
            height: 25px;
        }
        .style9
        {
            width: 296px;
            height: 25px;
        }
        .style10
        {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <asp:Panel ID="PanelRegisterAs" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <table class="style2">
        <tr>
            <td class="style3">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Register As &nbsp;</td>
            <td>
                <asp:RadioButtonList ID="rblRegister" runat="server" AutoPostBack="True" 
                    CellPadding="10" CellSpacing="5" RepeatDirection="Horizontal">
                    <asp:ListItem>Service Provider</asp:ListItem>
                    <asp:ListItem>Customer</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="2">
                <br />
                <asp:ScriptManager ID="scmCustomerPanel" runat="server">
                </asp:ScriptManager>
                <asp:Panel ID="PanelServiceProvider" runat="server" Enabled="False" 
                    Visible="False">
                    &nbsp;<table class="style2">
                        <tr>
                            <td class="style4">
                                &nbsp;&nbsp;&nbsp;&nbsp; Name&nbsp;</td>
                            <td class="style5">
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                                    ControlToValidate="txtName" ErrorMessage="Name Is Mandatory">*</asp:RequiredFieldValidator>
                                &nbsp; 
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                    ControlToValidate="txtName" 
                                    ErrorMessage="Name can contain only Alphabets and spaces" 
                                    ValidationExpression="[A-Za-z\s]*">*</asp:RegularExpressionValidator>
                                <asp:CustomValidator ID="cvName" runat="server" 
                                    ClientValidationFunction="CheckName" ControlToValidate="txtName" 
                                    ErrorMessage="Name Length can't be more than 25 characters">*</asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;&nbsp;&nbsp;&nbsp; Mobile Number&nbsp;</td>
                            <td class="style5">
                                +91-<asp:TextBox ID="txtMobileNumber" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvMobilenumber" runat="server" 
                                    ControlToValidate="txtMobileNumber" 
                                    ErrorMessage="Please Enter Your Mobile Number">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revMobileNumber" runat="server" 
                                    ControlToValidate="txtMobileNumber" ErrorMessage="Mobile Number Should Only be Digits" 
                                    ValidationExpression="[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]">*</asp:RegularExpressionValidator>
                                <br />
                                <asp:CustomValidator ID="cvMobileNum" runat="server" 
                                    ClientValidationFunction=" CheckPhone" ControlToValidate="txtMobileNumber" 
                                    ErrorMessage="phone number should have exactly 10 characters">*</asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;&nbsp;&nbsp;&nbsp; Porting Charge&nbsp;</td>
                            <td class="style5">
                                <asp:TextBox ID="txtPortingCharges" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvPorting" runat="server" 
                                    ControlToValidate="txtPortingCharges" 
                                    ErrorMessage="Please Provide Porting Charges">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rgvPorting" runat="server" 
                                    ControlToValidate="txtPortingCharges" ErrorMessage="Porting Charges must be between 0-50" 
                                    MaximumValue="50" MinimumValue="0" Type="Integer">*</asp:RangeValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;&nbsp;&nbsp;&nbsp; Address&nbsp;</td>
                            <td class="style5">
                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                                    ControlToValidate="txtAddress" ErrorMessage="Address is Mandatory">*</asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="CustomValidator3" runat="server" 
                                    ClientValidationFunction=" CheckAdd" ControlToValidate="txtAddress" 
                                    ErrorMessage="Address can't be more than 50 characters ">*</asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;&nbsp;&nbsp;&nbsp; Licence Number&nbsp;</td>
                            <td class="style5">
                                <asp:TextBox ID="txtLicenceNumber" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RrfvLicence" runat="server" 
                                    ControlToValidate="txtLicenceNumber" 
                                    ErrorMessage="Licence Number is Mandatory">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;&nbsp;&nbsp;&nbsp; Password&nbsp;</td>
                            <td class="style5">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                                    ControlToValidate="txtPassword" ErrorMessage="Password is Mandatory">*</asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="CustomValidator8" runat="server" 
                                    ClientValidationFunction="CheckPassword" ControlToValidate="txtPassword" 
                                    ErrorMessage="Password length should be atleast 6 characters">*</asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;&nbsp;&nbsp;&nbsp; Re-Type Password&nbsp;</td>
                            <td class="style5">
                                <asp:TextBox ID="txtRepassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CompareValidator ID="cmvRepassword" runat="server" 
                                    ControlToCompare="txtPassword" ControlToValidate="txtRepassword" 
                                    ErrorMessage="Password Doesnt Match">*</asp:CompareValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                    ControlToValidate="txtPassword" 
                                    ErrorMessage="Password should have one Character and one Number" 
                                    ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,20})$">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;&nbsp;&nbsp;&nbsp; Security Question&nbsp;</td>
                            <td class="style5" rowspan="2">
                                <asp:UpdatePanel ID="UpServiceProvider" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSecurityQuestion" runat="server" AutoPostBack="True">
                                            <asp:ListItem>Select Your Question</asp:ListItem>
                                            <asp:ListItem>What is your Favourite Food?</asp:ListItem>
                                            <asp:ListItem>What is your Favourite Place</asp:ListItem>
                                            <asp:ListItem>What is your Pet&#39;s Name?</asp:ListItem>
                                            <asp:ListItem>Which is your First School?</asp:ListItem>
                                            <asp:ListItem>Add my own Question</asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <asp:TextBox ID="txtSecurityq" runat="server" Visible="False"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvSecurityQuestion" runat="server" 
                                    ControlToValidate="ddlSecurityQuestion" 
                                    ErrorMessage="Select Some Valid Question" InitialValue="Select Your Question">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;&nbsp;&nbsp;&nbsp; Security Answer&nbsp;</td>
                            <td class="style5">
                                <asp:TextBox ID="txtSecurityAnswer" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvAnswer" runat="server" 
                                    ControlToValidate="txtSecurityAnswer" 
                                    ErrorMessage="Provide answer for your Question">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                            <td class="style5">
                                <asp:Button ID="btnRegister" runat="server" Text="Register" 
                                    onclick="btnRegister_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" Text="Reset" CausesValidation="False" 
                                    onclick="btnReset_Click" />
                                <br />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblResult" runat="server" ForeColor="Green" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:ValidationSummary ID="vsService" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="PanelCustomer" runat="server" Enabled="False" Visible="False">
                    <table class="style2">
                        <tr>
                            <td class="style6">
                                &nbsp;&nbsp;&nbsp; Name&nbsp;</td>
                            <td class="style7">
                                <asp:TextBox ID="txtCusName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvCusName" runat="server" 
                                    ControlToValidate="txtCusName" 
                                    ErrorMessage="Mandatory,Please Enter your Name">*</asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvCusName" runat="server" 
                                    ClientValidationFunction="CheckName" ControlToValidate="txtCusName" 
                                    ErrorMessage="Name Length can't be more than 25 characters">*</asp:CustomValidator>
                                <asp:RegularExpressionValidator ID="revCusName" runat="server" 
                                    ControlToValidate="txtCusName" 
                                    ErrorMessage="Name can contain only Alphabets and spaces" 
                                    ValidationExpression="[A-Za-z\s]*">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;&nbsp;&nbsp;&nbsp; Address Line1</td>
                            <td class="style7">
                                <asp:TextBox ID="txtCusAdd1" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CustomValidator ID="CustomValidator5" runat="server" 
                                    ClientValidationFunction=" CheckAddress" ControlToValidate="txtCusAdd1" 
                                    ErrorMessage="Address can't be more than 25 characters ">*</asp:CustomValidator>
                                <asp:RequiredFieldValidator ID="rfvAddCus1" runat="server" 
                                    ControlToValidate="txtCusAdd1" ErrorMessage="Address is Mandatory">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;&nbsp;&nbsp; Address Line2&nbsp;</td>
                            <td class="style7">
                                <asp:TextBox ID="txtCusAdd2" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CustomValidator ID="CustomValidator6" runat="server" 
                                    ClientValidationFunction=" CheckAddress" ControlToValidate="txtCusAdd2" 
                                    ErrorMessage="Address can't be more than 25 characters ">*</asp:CustomValidator>
                                <asp:RequiredFieldValidator ID="rfvAddCus2" runat="server" 
                                    ControlToValidate="txtCusAdd2" ErrorMessage="Addressline2  is Mandatory">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;&nbsp;&nbsp; State&nbsp;</td>
                            <td class="style7">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCusState" runat="server" AppendDataBoundItems="True" 
                                            AutoPostBack="True" DataSourceID="odsStates" DataTextField="State" 
                                            DataValueField="State">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:ObjectDataSource ID="odsStates" runat="server" SelectMethod="GetStates" 
                                    TypeName="Common"></asp:ObjectDataSource>
                                <asp:RequiredFieldValidator ID="rfvStatesCus" runat="server" 
                                    ControlToValidate="ddlCusState" ErrorMessage="Select Any State" 
                                    InitialValue="--Select--">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;&nbsp;&nbsp; ZipCode&nbsp;</td>
                            <td class="style7">
                                <asp:TextBox ID="txtCzipcode" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" 
                                    ControlToValidate="txtCzipcode" ErrorMessage="Zipcode is Mandatory">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revZipcode" runat="server" 
                                    ControlToValidate="txtCzipcode" ErrorMessage="ZipCode cannot be greater than 6 digits" 
                                    ValidationExpression="[0-9][0-9][0-9][0-9][0-9][0-9]">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;&nbsp;&nbsp; Mobile Number&nbsp;</td>
                            <td class="style7">
                                +91-<asp:TextBox ID="txtCusMobileNumber" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CustomValidator ID="cusmobileNum" runat="server" 
                                    ClientValidationFunction=" CheckPhone" 
                                    ControlToValidate="txtCusMobileNumber" 
                                    ErrorMessage="phone number should have exactly 10 characters">*</asp:CustomValidator>
                                <asp:RequiredFieldValidator ID="rfvMobile" runat="server" 
                                    ControlToValidate="txtCusMobileNumber" 
                                    ErrorMessage="Mobile number is Mandatory">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revMobileNumberCus" runat="server" 
                                    ControlToValidate="txtCusMobileNumber" ErrorMessage="Mobile Number Should Only be Digits" 
                                    ValidationExpression="[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;&nbsp;&nbsp; Current Plan Type&nbsp;</td>
                            <td class="style7">
                                <asp:RadioButtonList ID="rblPlantype" runat="server" AutoPostBack="True" 
                                    CellPadding="4" RepeatDirection="Horizontal" onselectedindexchanged="rblPlantype_SelectedIndexChanged1" 
                                    >
                                    <asp:ListItem>Prepaid</asp:ListItem>
                                    <asp:ListItem Value="Postpaid">Postpaid</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;&nbsp;&nbsp; Current Service Provider&nbsp;</td>
                            <td class="style7">
                                <asp:DropDownList ID="ddlServiceProvider" runat="server" AutoPostBack="True" 
                                    DataSourceID="ObjectDataSource1" DataTextField="ServiceProviderName" 
                                    DataValueField="ServiceProviderId" 
                                    onselectedindexchanged="ddlServiceProvider_SelectedIndexChanged" 
                                    AppendDataBoundItems="True">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                    SelectMethod="GetProviderId" TypeName="ServiceProviderDAL" 
                                    OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="rblPlantype" DefaultValue="" 
                                            Name="PlanType" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                &nbsp;&nbsp;&nbsp; Current Plan&nbsp;</td>
                            <td class="style9">
                                <asp:DropDownList ID="ddlCurrentPlan" runat="server" AutoPostBack="True" 
                                    DataSourceID="ObjectDataSource2" DataTextField="PlanName" 
                                    DataValueField="PlanId" AppendDataBoundItems="True">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="style10">
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                    SelectMethod="GetPlan" TypeName="ServiceProviderBL" 
                                    OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlCusState" Name="state" 
                                            PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="rblPlantype" DefaultValue="Prepaid" 
                                            Name="PlanType" PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="ddlServiceProvider" DefaultValue="" 
                                            Name="ServiceProviderId" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;&nbsp;&nbsp;&nbsp; Password</td>
                            <td class="style7">
                                <asp:TextBox ID="txtCusPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvCPassword" runat="server" 
                                    ControlToValidate="txtCusPassword" ErrorMessage="Password is Mandatory">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                    ControlToValidate="txtCusPassword" 
                                    ErrorMessage="Password should have one Character and one Number" 
                                    ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,20})$">*</asp:RegularExpressionValidator>
                                <asp:CustomValidator ID="cvCusPassword" runat="server" 
                                    ClientValidationFunction="CheckPassword" ControlToValidate="txtCusPassword" 
                                    ErrorMessage="Password length should be atleast 6 characters">*</asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;&nbsp;&nbsp; Retype Password</td>
                            <td class="style7">
                                <asp:TextBox ID="txtCusRepassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                            <td>
                                <asp:CompareValidator ID="cmvCRepassword" runat="server" 
                                    ControlToCompare="txtCusPassword" ControlToValidate="txtCusRepassword" 
                                    ErrorMessage="Password is Not same as above">*</asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;&nbsp; &nbsp;Security Question&nbsp;</td>
                            <td class="style7" rowspan="2">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCusSecurityQues" runat="server" AutoPostBack="True">
                                            <asp:ListItem>Select Your Question</asp:ListItem>
                                            <asp:ListItem>What is your Favourite Place?</asp:ListItem>
                                            <asp:ListItem>What is your Favourite Food?</asp:ListItem>
                                            <asp:ListItem>What is your Pet&#39;s Name?</asp:ListItem>
                                            <asp:ListItem>Which is your First School?</asp:ListItem>
                                            <asp:ListItem>Add my own Question</asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <asp:TextBox ID="txtCusSecurityQuestion" runat="server" Visible="False"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvCusSecurityQuestion" runat="server" 
                                    ControlToValidate="ddlCusSecurityQues" 
                                    ErrorMessage="Select Some Valid Question" InitialValue="Select Your Question">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;&nbsp;&nbsp; &nbsp;Security Answer&nbsp;</td>
                            <td class="style7">
                                <asp:TextBox ID="txtCusSecurityAnswer" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvCusAnswer" runat="server" 
                                    ControlToValidate="txtCusSecurityAnswer" 
                                    ErrorMessage="Answer is Mandatory">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style6">
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
                            </td>
                            <td class="style7">
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnRegisterCustomer" runat="server" Text="Register" 
                                    onclick="btnRegisterCustomer_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnResertC" runat="server" Text="Reset" 
                                    CausesValidation="False" onclick="btnResertC_Click" />
                                <br />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblCusResult" runat="server" ForeColor="Green" Text="Label" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:ValidationSummary ID="vsCustomer" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbLogin" runat="server" Visible="False" 
                    CausesValidation="False" onclick="lbLogin_Click">Click here to Login</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
    </table>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</asp:Panel>
</asp:Content>


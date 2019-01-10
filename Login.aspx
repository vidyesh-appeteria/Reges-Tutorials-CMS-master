<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<meta http-equiv="X-UA-Compatible" content="IE=7" />
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Panel runat="server">
            <br />
            <br />
            <center>
                <asp:Label Text="Rege's Tutorials CMS" runat="server" SkinID="LabelTitle" />
            </center>
        </asp:Panel>
        <div>
            <center>
                <asp:Label Text="" ID="lblError" runat="server" SkinID="LabelError" />
                <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" runat="server" />
                <br />
                <asp:Image ImageUrl="~/images/logo.jpg"  AlternateText="Rege's Tutorials" runat="server"
                    Width="150px" />
                <br /><br />
                <table>
                   
                    <tr>
                        <td>
                            <asp:Label ID="lblUserName" runat="server" Text="User Name" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" AutoCompleteType="disabled" MaxLength="10" />
                            <asp:RequiredFieldValidator ErrorMessage="Enter User Name" ControlToValidate="txtUserName"
                                Display="None" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPassword" runat="server" Text="Password" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="password" AutoCompleteType="disabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ErrorMessage="Enter Password" ControlToValidate="txtPassword"
                                Display="None" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <center>
                                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                                <asp:Button ID="btnSignUp" Text="Sign Up" runat="server" OnClick="btnSignUp_Click" SkinID="ButtonSecond" CausesValidation="false" />
                            </center>
                        </td>
                    </tr>
                </table>


                <br />
                <br />
                <br />
                <br />
                <hr />
                <asp:Label Text="Developed by : Appeteria Technologies" runat="server" Font-Bold="true" />
            </center>



        </div>


    </form>
</body>
</html>
<%--  <asp:DropDownList runat="server" ID="ddlTheme" AutoPostBack="true" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged">
                <asp:ListItem Text="Sky Blue" Value="SkyBlue" />
                <asp:ListItem Text="Green" Value="Green" />
                <asp:ListItem Text="Red" Value="Red" />
            </asp:DropDownList>--%>
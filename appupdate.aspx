<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="appupdate.aspx.cs" Inherits="appupdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<center>
    <div>
        <br /><br />
        <asp:Label ID="lblErrorMsg" runat="server" Text="" SkinID="LabelError"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" />
        <table>
            <tr>

                <td>
                    <asp:Label runat="server" Text="Latest App Version"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <%--MinAmountForPayment--%>
                    <asp:TextBox ID="txtAppVersion" runat="server" MaxLength="2"></asp:TextBox>
                    <asp:RequiredFieldValidator  runat="server" ErrorMessage="Enter App Version" ControlToValidate="txtAppVersion"
                        Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
                  </tr>


            <tr>
                <td>
                    <asp:Label  runat="server" Text="Force Update"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:CheckBox Text="" ID="chkForceUpdate" runat="server" />

                </td>
            </tr>


            <tr>
                <td>
                    <asp:Label ID="lblWhatsNew" runat="server" Text="What's New"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:TextBox ID="txtWhatsNew" runat="server" MaxLength="2000" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Enter What's New" ControlToValidate="txtWhatsNew" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <center>
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></center>
                </td>
            </tr>
        </table>
    </div>
    </center>
</asp:Content>


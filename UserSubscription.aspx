<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="UserSubscription.aspx.cs" Inherits="UserSubscription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <center>
    <br />
    <input type="button" id="btnAdd" value="Search" style="display: none; width: 120px" class="button" />
    <div style="width: 60%; position: relative;">
        <input type="button" id="btnClose" value="X" class="buttonSecond" style="position: absolute; right: 10px; top: 10px;" />
    </div>
    <br />
    <div id="effect" class="ui-widget-content ui-corner-all" style="width: 60%">
        <br />
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label Text="Name" runat="server" /></td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" MaxLength="50" /></td>
                <td>
                    <asp:Label Text="Mobile No" runat="server" /></td>
                <td>
                    <asp:TextBox ID="txtMobile" MaxLenght="10" runat="server" />


                </td>
                <td>
                    <asp:Button Text="Search" runat="server" ID="btnSearch" OnClick="btnSearch_Click" />

                    <asp:Button Text="Clear" ID="btnClear" OnClick="btnClear_Click" runat="server" />
                    <asp:HiddenField ID="hdnUserID" runat="server" Value="0" />
                </td>

            </tr>
        </table>
    </div>
    <asp:Label ID="lblError" runat="server" SkinID="LabelError" />
    <asp:ValidationSummary runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="RENEW" />
    <asp:Panel runat="server" ID="pnlRenew" Visible="false" Style="background-color: white;">
        <table>
            <tr>
                <td>
                    <asp:Label Text="Renew for" runat="server" /></td>
                <td>
                    <asp:TextBox ID="txtDays" runat="server" MaxLength="3" />
                    <asp:RequiredFieldValidator ID="rfvDays" runat="server"
                        ErrorMessage="Enter Days for renewal" ControlToValidate="txtDays"
                        Display="None" ForeColor="Red" ValidationGroup="RENEW"></asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:Label Text="Days" runat="server" /></td>
                <td>
                    <asp:Button Text="Renew" runat="server" ID="btnRenew" OnClick="btnRenew_Click"
                        ValidationGroup="RENEW" />

                    <asp:Button Text="Cancel" ID="btnCancel" OnClick="btnCancel_Click" runat="server" />
                </td>

            </tr>
        </table>
    </asp:Panel>
   <div style="overflow: auto; height: 480px;">
        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="true" Width="98%"
            EmptyDataText="No records found" OnRowCommand="gvUsers_RowCommand" >
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnRenew" Text="Renew" CommandName="RENEW" runat="server"
                            CommandArgument='<%# Eval("userid") %>'></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
    </center>
</asp:Content>


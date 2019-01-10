<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="MediumMaster.aspx.cs" Inherits="MediumMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
    <div id="dvMain" runat="server">
        <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" />
        <br />
        <fieldset style="width: 28%">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblMedium" runat="server" Text="Medium"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtMedium" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMedium" runat="server" ErrorMessage="Enter Medium" ControlToValidate="txtMedium"
                            Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <center>
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                 <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" SkinID="ButtonSecond" />
                </center>
                    </td>
                </tr>
            </table>
        </fieldset>
    
    <asp:GridView ID="gvMedium" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gvMedium_PageIndexChanging" Width="30%"
        OnRowEditing="gvMedium_RowEditing" OnRowCancelingEdit="gvMedium_RowCancelingEdit" OnRowUpdating="gvMedium_RowUpdating"
        OnRowDeleting="gvMedium_RowDeleting" EmptyDataText="No records found" AllowPaging="true" PageSize="5"
        AllowSorting="true" ValidationGroup="gv">
        <Columns>
<asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hdnMediumId" runat="server" Value='<%# Eval("medium_id") %>'></asp:HiddenField>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Height="40px" HeaderText="Medium">
                <ItemTemplate>
                    <asp:Label ID="lblMedium" runat="server" Text='<%# Eval("Medium") %>' ForeColor="Black"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtMedium" runat="server" Text='<%# Eval("Medium") %>' />
                    <asp:RequiredFieldValidator ID="rfvMedium" runat="server"
                        ErrorMessage="Enter Medium" ControlToValidate="txtMedium"
                        Display="None" ForeColor="Red" ValidationGroup="gv"></asp:RequiredFieldValidator>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowCancelButton="true" ShowDeleteButton="true" CausesValidation="false" HeaderText="Action" ControlStyle-Height="30px" ControlStyle-Width="80px" />
        </Columns>
        <PagerSettings Mode="Numeric" Position="Bottom" />
    </asp:GridView>
    <asp:HiddenField ID="hdnSort" runat="server" Value="ASC" />
        </div>
          <asp:LinkButton Text=" Trash" ID="lnkTrash" Visible="false" runat="server"
              OnClick="lnkTrash_Click" CausesValidation="false" />
    <asp:Panel runat="server" ScrollBars="Vertical" Height="450px" SkinID="none" ID="pnlMediumTrash">
        <asp:GridView ID="gvMediumTrash" runat="server" AutoGenerateColumns="false" Width="30%" OnRowCommand="gvMediumTrash_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Medium" DataField="medium" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnRestore" Text="Restore" CommandName="RESTORE" runat="server" CommandArgument='<%# Eval("medium_id") %>'></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    </center>

    <asp:HiddenField ID="hdnUserid" runat="server" Value="0"></asp:HiddenField>
    <input type="hidden" id="hdnClose" value="1" />
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="BatchMaster.aspx.cs" Inherits="BatchMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
    
    <div id="dvMain" runat="server">
        <asp:HiddenField ID="hdnBatchId" runat="server" Value="0"></asp:HiddenField>
        <asp:Label ID="lblErrorMsg" runat="server" Text="" SkinID="LabelError"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" />
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblBatchName" runat="server" Text="Batch Name"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:TextBox ID="txtBatchName" runat="server" MaxLength="60"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvBatchName" runat="server" ErrorMessage="Enter Batch Name" ControlToValidate="txtBatchName"
                        Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:Label ID="lblMedium" runat="server" Text="Medium"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlMedium" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvMedium" runat="server" ErrorMessage="Select Medium" ControlToValidate="ddlMedium"
                        Display="None" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBoard" runat="server" Text="Board"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlBoard" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBoard_SelectedIndexChanged" />
                    <asp:RequiredFieldValidator ID="rfvBoard" runat="server" ErrorMessage="Select Board" ControlToValidate="ddlBoard"
                        Display="None" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                </td>

                <td>
                    <asp:Label ID="lblStandard" runat="server" Text="Standard"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlStandard" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvStandard" runat="server" ErrorMessage="Select Standard" ControlToValidate="ddlStandard"
                        Display="None" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <center>
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                 <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" SkinID="ButtonSecond" />
            </center>
                </td>
            </tr>

        </table>


        <asp:GridView ID="gvBatch" runat="server" AutoGenerateColumns="false"
            OnPageIndexChanging="gvBatch_PageIndexChanging" Width="60%"
            EmptyDataText="No records found" AllowPaging="true" PageSize="10"
            AllowSorting="true" OnRowCommand="gvBatch_RowCommand">
            <Columns>


                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EDT" CommandArgument='<%# Eval("batch_id") %>' CausesValidation="false" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DEL" CommandArgument='<%# Eval("batch_id") %>' 
                            CausesValidation="false"
                            OnClientClick="return confirm('Do you really want to delete this record?');"
                            
                            />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Batch" DataField="batch_name" />
                <asp:BoundField HeaderText="Board" DataField="board" />
                <asp:BoundField HeaderText="Standard" DataField="standard" />
                <asp:BoundField HeaderText="Medium" DataField="medium" />
            </Columns>
            <PagerSettings Mode="Numeric" Position="Bottom" />
        </asp:GridView>
        <asp:HiddenField ID="hdnSort" runat="server" Value="ASC" />

    </div>

    <asp:LinkButton Text=" Trash" ID="lnkTrash" Visible="false" runat="server"
        OnClick="lnkTrash_Click" CausesValidation="false" />

    <asp:GridView ID="gvBatchTrash" runat="server" AutoGenerateColumns="false" Width="60%"
        OnRowCommand="gvBatchTrash_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnRestore" runat="server"
                        CommandName="RESTORE" Text="Restore" CausesValidation="false"
                        CommandArgument='<%# Eval("batch_id") %>'></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Batch" DataField="batch_name" />
            <asp:BoundField HeaderText="Board" DataField="board" />
            <asp:BoundField HeaderText="Standard" DataField="standard" />
            <asp:BoundField HeaderText="Medium" DataField="medium" />



        </Columns>
    </asp:GridView>

    </center>

</asp:Content>


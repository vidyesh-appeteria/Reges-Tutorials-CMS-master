<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="TTTypeMaster.aspx.cs" Inherits="TTTypeMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server" />
    <center>

    <div id="dvMain" runat="server">
        <asp:HiddenField ID="hdnTTTypeId" runat="server" Value="0"></asp:HiddenField>
        <asp:Label ID="lblErrorMsg" runat="server" Text="" SkinID="LabelError"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" />
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblBatchName" runat="server" Text="Type"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:TextBox ID="txtType" runat="server" MaxLength="60"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvType" runat="server" ErrorMessage="Enter Type" ControlToValidate="txtType"
                        Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:Label ID="lblColor" runat="server" Text="Color"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                   
                    <asp:DropDownList ID="ddlColor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlColor_SelectedIndexChanged">
                        <asp:ListItem Text="Select" Value="0" />
                        <asp:ListItem Text="Red" Value="#EF5350" />
                        <asp:ListItem Text="PINK" Value="#EC407A" />
                        <asp:ListItem Text="PURPLE" Value="#AB47BC" />
                        <asp:ListItem Text="TEAL" Value="#26A69A" />
                        <asp:ListItem Text="Indigo" Value="#5C6BC0" />
                        <asp:ListItem Text="Blue" Value="#42A5F5" />
                        <asp:ListItem Text="Light Blue" Value="#29B6F6" />
                        <asp:ListItem Text="Cyan" Value="#26C6DA" />
                        <asp:ListItem Text="Green" Value="#66BB6A" />
                        <asp:ListItem Text="Light Green" Value="#9CCC65" />
                        <asp:ListItem Text="Lime" Value="#D4E157" />
                        <asp:ListItem Text="Yellow" Value="#FFEB3B" />
                        <asp:ListItem Text="Orange" Value="#FFA726" />
                        <asp:ListItem Text="Brown" Value="#8D6E63" />
                        <asp:ListItem Text="Grey" Value="#BDBDBD" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvColor" runat="server" ErrorMessage="Select Color" ControlToValidate="ddlColor"
                        Display="None" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <br />
                             <asp:updatepanel runat="server">
    <contenttemplate>
                    <asp:Panel ID="pnnlColor" runat="server" Style="width: 30px; height: 30px"  BackColor="White" />
                             </contenttemplate>
                                 <Triggers>
                                     <asp:AsyncPostBackTrigger ControlID="ddlColor" EventName="SelectedIndexChanged" />
                                     
                                 </Triggers>
</asp:updatepanel>
                    </td>
               
            </tr>
            <tr>
                <td colspan="7">
                    <center>
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                 <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" SkinID="ButtonSecond" />
            </center>
                </td>
            </tr>

        </table>


        <asp:GridView ID="gvTypes" runat="server" AutoGenerateColumns="false"
            OnPageIndexChanging="gvTypes_PageIndexChanging" Width="30%"
            EmptyDataText="No records found" AllowPaging="true" PageSize="10"
            AllowSorting="true" OnRowCommand="gvTypes_RowCommand">
            <Columns>


                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EDT" CommandArgument='<%# Eval("tt_type_id") %>' CausesValidation="false" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DEL" CommandArgument='<%# Eval("tt_type_id") %>'
                            CausesValidation="false"
                            OnClientClick="return confirm('Do you really want to delete this record?');" />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Type" DataField="tt_type" />
                <asp:TemplateField HeaderText="Color">
                    <ItemTemplate>
                        <asp:Panel ID="pnnlColor" runat="server" Style="width: 30px; height: 30px" BackColor='<%# System.Drawing.Color.FromName(Convert.ToString(Eval("tt_type_color"))) %>'  />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <PagerSettings Mode="Numeric" Position="Bottom" />
        </asp:GridView>
        <asp:HiddenField ID="hdnSort" runat="server" Value="ASC" />

    </div>

    <asp:LinkButton Text=" Trash" ID="lnkTrash" Visible="false" runat="server"
        OnClick="lnkTrash_Click" CausesValidation="false" />

    <asp:GridView ID="gvTypesTrash" runat="server" AutoGenerateColumns="false" Width="30%"
        OnRowCommand="gvTypesTrash_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnRestore" runat="server"
                        CommandName="RESTORE" Text="Restore" CausesValidation="false"
                        CommandArgument='<%# Eval("tt_type_id") %>'></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Type" DataField="tt_type" />
            <asp:TemplateField HeaderText="Color">
                <ItemTemplate>
                    <asp:Panel ID="pnnlColor" runat="server" Style="width: 30px; height: 30px" BackColor='<%# System.Drawing.Color.FromName(Convert.ToString(Eval("tt_type_color"))) %>'  />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
   
    </center>
</asp:Content>


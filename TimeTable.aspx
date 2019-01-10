<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="TimeTable.aspx.cs" Inherits="TimeTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {        
            $('#<%= txtDate.ClientID %>').datepicker({ dateFormat: 'dd-M-yy' });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
    
    <div id="dvMain" runat="server">
        <asp:HiddenField ID="hdnttId" runat="server" Value="0"></asp:HiddenField>
        <asp:Label ID="lblErrorMsg" runat="server" Text="" SkinID="LabelError"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false" />
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" MaxLength="15"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDate" runat="server" ErrorMessage="Select Date" ControlToValidate="txtDate"
                        Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
                 <td>
                    <asp:Label ID="lblType" runat="server" Text="Type"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" />
                    <asp:RequiredFieldValidator ID="rfType" runat="server" ErrorMessage="Select Type" ControlToValidate="ddlType"
                        Display="None" ForeColor="Red" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
                 <td>
                    <asp:Label ID="lblMedium" runat="server" Text="Medium"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged"
                        />
                   
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
                
                </td>

                <td>
                    <asp:Label ID="lblStandard" runat="server" Text="Standard"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlStandard" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStandard_SelectedIndexChanged" />
                   
                </td>

                        <td>
                    <asp:Label ID="lblBatch" runat="server" Text="Batch"></asp:Label>
                </td>
                <td>:
                </td>
                <td>
                    <asp:DropDownList ID="ddlBatch" runat="server" />
               
                </td>
            </tr>
              <tr>
                  <td>  <asp:Label runat="server" Text="Description"></asp:Label></td>
                  <td>:
                </td>
                
                <td colspan="7">

                    <asp:textbox runat="server" ID="txtDesc" Rows="2" TextMode="MultiLine" Width="98%" />
                      <asp:RequiredFieldValidator ID="rfvDesc" runat="server" ErrorMessage="Enter Description" ControlToValidate="txtDesc"
                        Display="None" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                  </tr>
            <tr>
                <td colspan="9">
                    <center>
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                 <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" SkinID="ButtonSecond" />
            </center>
                </td>
            </tr>

        </table>


        <asp:GridView ID="gvTimeTable" runat="server" AutoGenerateColumns="false"
            OnPageIndexChanging="gvTimeTable_PageIndexChanging" Width="60%"
            EmptyDataText="No records found" AllowPaging="true" PageSize="10"
            AllowSorting="true" OnRowCommand="gvTimeTable_RowCommand">
            <Columns>


                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EDT" CommandArgument='<%# Eval("tt_id") %>' CausesValidation="false" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DEL" CommandArgument='<%# Eval("tt_id") %>' 
                            CausesValidation="false"
                            OnClientClick="return confirm('Do you really want to delete this record?');"
                            
                            />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Date" DataField="tt_date" />
                <asp:BoundField HeaderText="Description" DataField="tt_desc" />
                <asp:BoundField HeaderText="Type" DataField="tt_type" />
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

    <asp:GridView ID="gvTimeTableTrash" runat="server" AutoGenerateColumns="false" Width="60%"
        OnRowCommand="gvTimeTableTrash_RowCommand">
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


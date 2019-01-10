<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="BoardMaster.aspx.cs" Inherits="BoardMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
               
        <div id="dvMain" runat="server">
             
            <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false"  /><br />
            <fieldset style="width:28%">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblBoardName" runat="server" Text="Board Name"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtBoardName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvBoardName" runat="server" ErrorMessage="Enter Board Name" ControlToValidate="txtBoardName" Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

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

            <asp:GridView ID="gvBoard" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gvBoard_PageIndexChanging"  Width="30%"
                 OnRowEditing="gvBoard_RowEditing" OnRowCancelingEdit="gvBoard_RowCancelingEdit" OnRowUpdating="gvBoard_RowUpdating" OnRowDeleting="gvBoard_RowDeleting" EmptyDataText="No records found" AllowPaging="true" PageSize="5" 
                AllowSorting="true" ValidationGroup="gv">
                <Columns>

                           
                         <asp:TemplateField>
                        <ItemTemplate>
                                         
                    
                          <asp:HiddenField ID="hdnBoardId" runat="server" Value='<%# Eval("board_id") %>'></asp:HiddenField>
                            </ItemTemplate>
                             </asp:TemplateField>

                    <asp:TemplateField ItemStyle-Height="40px" HeaderText="Board Name">
                        <ItemTemplate>
                           <asp:Label ID="lblBoard" runat="server" Text='<%# Eval("board") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtBoard" runat="server"  Text='<%# Eval("board") %>' />
                                  <asp:RequiredFieldValidator ID="rfvBoardName" runat="server" 
                                      ErrorMessage="Enter Board Name" ControlToValidate="txtBoard"
                                       Display="None" ForeColor="Red" ValidationGroup="gv"></asp:RequiredFieldValidator>

                        </EditItemTemplate>
                    </asp:TemplateField>                   


                   <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowCancelButton="true" ShowDeleteButton ="true" CausesValidation="false" HeaderText="Action"  ControlStyle-Height="30px" ControlStyle-Width="80px"/>
                                    </Columns>
                <PagerSettings Mode="Numeric" Position="Bottom" />
            </asp:GridView>
            <asp:HiddenField    id="hdnSort" runat="server" Value="ASC" />
          
        </div>

          <asp:LinkButton Text=" Trash" ID="lnkTrash" Visible="false" runat="server"
        OnClick="lnkTrash_Click" CausesValidation="false"  />
          <asp:panel runat="server" ScrollBars="Vertical" Height="450px" SkinID="none" ID="pnlTrash">
          <asp:GridView ID="gvBoardTrash" runat="server" AutoGenerateColumns="false" Width="30%" OnRowCommand="gvBoardTrash_RowCommand" >
                <Columns>
                    <asp:BoundField HeaderText="Board" DataField="board" />
                    <asp:TemplateField>
                        <ItemTemplate>
                          <asp:Button ID="btnRestore" Text="Restore" CommandName="RESTORE" runat="server" CommandArgument='<%# Eval("board_id") %>'></asp:Button>
                            </ItemTemplate>
                             </asp:TemplateField>
</Columns>
            </asp:GridView>
         </asp:panel>
            </center>

    <asp:HiddenField ID="hdnUserid" runat="server" Value="0"></asp:HiddenField>
    <input type="hidden" id="hdnClose" value="1" />
</asp:Content>


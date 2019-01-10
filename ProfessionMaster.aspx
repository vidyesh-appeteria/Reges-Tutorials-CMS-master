<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPg.master" AutoEventWireup="true" CodeFile="ProfessionMaster.aspx.cs" Inherits="ProfessionMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        $(function () {
            var control = '#<%= txtProfession.ClientID%>';
            $("#btnClear").on("click", function () {
                $(control).val("");

            });
        });
    </script>
    <center>
        <div id="dvMain" runat="server">
             
            <asp:Label ID="lblErrorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="true" ShowSummary="false"  /><br />
             <input type="button" id="btnAdd" value="Add New" style="display: none;width:120px" class="button" />
            <div style="width:45%;position: relative;">
              <input type="button" id="btnClose" value="X" class="buttonSecond"  style=" position: absolute;right: 10px; top:10px;" /></div><br />
  <div id="effect" class="ui-widget-content ui-corner-all" style="width:45%">
  
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblProfession" runat="server" Text="Profession"></asp:Label>
                    </td>
                    <td>:
                    </td>
                    <td>
                        <asp:TextBox ID="txtProfession" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvProfession" runat="server" ErrorMessage="Enter Profession" ControlToValidate="txtProfession"
                             Display="None" ForeColor="Red"></asp:RequiredFieldValidator>

                    </td>
                </tr>

              <tr>
         <td colspan="3">
              <center>
                 <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <input type="button" id="btnClear" value="Clear" class="buttonSecond"  />
                 <%--<asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" CausesValidation="False" SkinID="ButtonSecond" />--%>
                </center>
         </td>
                </tr>

            </table>

         

      </div>
            <asp:GridView ID="gvProfession" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gvProfession_PageIndexChanging"
                  Width="60%"
                 OnRowEditing="gvProfession_RowEditing" OnRowCancelingEdit="gvProfession_RowCancelingEdit" OnRowUpdating="gvProfession_RowUpdating"
                 OnRowDeleting="gvProfession_RowDeleting" EmptyDataText="No records found" AllowPaging="true" PageSize="5" 
                AllowSorting="true" ValidationGroup="gv">
                <Columns>

                           
                         <asp:TemplateField>
                        <ItemTemplate>
                                         
                    
                          <asp:HiddenField ID="hdnProfessionId" runat="server" Value='<%# Eval("profession_id") %>'></asp:HiddenField>
                            </ItemTemplate>
                             </asp:TemplateField>

                    <asp:TemplateField ItemStyle-Height="40px" HeaderText="Board Name">
                        <ItemTemplate>
                           <asp:Label ID="lblBoard" runat="server" Text='<%# Eval("profession") %>' ForeColor="Black"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProfession" runat="server"  Text='<%# Eval("profession") %>' />
                                  <asp:RequiredFieldValidator ID="rfvProfession" runat="server" 
                                      ErrorMessage="Enter Profession" ControlToValidate="txtProfession"
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
          <asp:panel runat="server" ScrollBars="Vertical" Height="450px" SkinID="none">
          <asp:GridView ID="gvProfessionTrash" runat="server" AutoGenerateColumns="false" Width="30%" OnRowCommand="gvProfessionTrash_RowCommand" >
                <Columns>
                    <asp:BoundField HeaderText="Profession" DataField="profession" />
                    <asp:TemplateField>
                        <ItemTemplate>
                          <asp:Button ID="btnRestore" Text="Restore" CommandName="RESTORE" runat="server" CommandArgument='<%# Eval("profession_id") %>'></asp:Button>
                            </ItemTemplate>
                             </asp:TemplateField>
</Columns>
            </asp:GridView>
         </asp:panel>
            </center>
    <input type="hidden" id="hdnClose" value="1" />
</asp:Content>

